using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itchio : MonoBehaviour
{
    private bool isTriggered = false;
    private void Update()
    {
        if (isTriggered)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                Application.OpenURL("https://joyjacksoon.itch.io");
            }
        }
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
        }
    }
}
