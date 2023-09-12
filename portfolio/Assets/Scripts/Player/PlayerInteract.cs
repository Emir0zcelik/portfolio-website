using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] GameObject interactText;
    private bool isTriggered;
    void Start()
    {
        isTriggered = false;
    }

    void Update()
    {
        if (isTriggered) 
        {
            interactText.SetActive(true);
        }
        else
        {
            interactText.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable")) 
        {
            isTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            isTriggered = false;
        }
    }
}
