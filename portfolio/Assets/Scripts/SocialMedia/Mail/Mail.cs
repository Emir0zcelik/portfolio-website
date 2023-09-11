using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mail : MonoBehaviour
{
    [SerializeField] GameObject Panel;
    private bool isTriggered = false;
    private void Update()
    {
        if (isTriggered)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                Panel.SetActive(true);
            }
        }
    }

    public void ClosePanel()
    {
        Panel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTriggered = false;
            Panel.SetActive(false);
        }
    }
}
