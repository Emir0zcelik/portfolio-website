using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSurvivalPlay : MonoBehaviour
{
    [SerializeField] private IsButtonPressed press;
    [SerializeField] private InteractButton interactButton;
    private bool isTriggered = false;
    private void Update()
    {
        if (isTriggered)
        {
            if (press.isPressed())
            {
                Application.OpenURL("https://joyjacksoon.itch.io/apple-survivor");
                interactButton.SetIsButtonPressed(false);
            }
        }
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
            interactButton.SetIsButtonPressed(false);
        }
    }
}
