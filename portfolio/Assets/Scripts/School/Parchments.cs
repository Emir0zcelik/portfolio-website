using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parchments : MonoBehaviour
{
    [SerializeField] private GameObject Panel;

    private bool isPanel = false;

    void Update()
    {
        if (isPanel)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Panel.SetActive(true);
                Cursor.visible = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPanel = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Panel.SetActive(false);
            isPanel = false;
            Cursor.visible = false;
        }
    }

    public void CloseParchment()
    {
        Panel.SetActive(false);
        Cursor.visible = false;
    }
}
