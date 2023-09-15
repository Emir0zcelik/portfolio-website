using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkillsTable : MonoBehaviour
{
    [SerializeField] private GameObject SkillsPanel;
    [SerializeField] private IsButtonPressed press;
    [SerializeField] private InteractButton interactButton;

    private bool isSkillsPanel = false;
    private void Update()
    {
        if(isSkillsPanel)
        {
            if (press.isPressed())
            {
                SkillsPanel.SetActive(true);
                Cursor.visible = true;
                interactButton.SetIsButtonPressed(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isSkillsPanel = true;
        }
    }

    public void CloseSkillsTable()
    {
        SkillsPanel.SetActive(false);
        Cursor.visible = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isSkillsPanel = false;
            SkillsPanel.SetActive(false);
            Cursor.visible = false;
            interactButton.SetIsButtonPressed(false);
        }
    }
}
