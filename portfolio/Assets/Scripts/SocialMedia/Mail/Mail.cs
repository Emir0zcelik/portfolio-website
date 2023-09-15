using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mail : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    [SerializeField] private IsButtonPressed press;
    [SerializeField] private InteractButton interactButton;

    private bool isTriggered = false;

    private void Update()
    {
        if (isTriggered)
        {
            if (press.isPressed())
            {
                Panel.SetActive(true);
                Cursor.visible = true;
                interactButton.SetIsButtonPressed(false);
            }
        }
    }

    public void ClosePanel()
    {
        Panel.SetActive(false);
        Cursor.visible = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTriggered = true;
            interactButton.SetIsButtonPressed(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTriggered = false;
            Panel.SetActive(false);
            Cursor.visible = false;
            interactButton.SetIsButtonPressed(false);
        }
    }
}
