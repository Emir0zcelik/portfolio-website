using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parchments : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    [SerializeField] private IsButtonPressed press;
    [SerializeField] private InteractButton interactButton;

    private bool isPanel = false;

    void Update()
    {
        if (isPanel)
        {
            if (press.isPressed())
            {
                Panel.SetActive(true);
                Cursor.visible = true;
                interactButton.SetIsButtonPressed(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPanel = true;
            interactButton.SetIsButtonPressed(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Panel.SetActive(false);
            isPanel = false;
            Cursor.visible = false;
            interactButton.SetIsButtonPressed(false);
        }
    }

    public void CloseParchment()
    {
        Panel.SetActive(false);
        Cursor.visible = false;
    }
}
