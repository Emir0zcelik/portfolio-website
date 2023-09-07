using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AboutMe : MonoBehaviour
{
    private SpriteRenderer sprite;

    private bool isTriggered;
    private bool isTime;
    private Vector4 originalColor;

    private float time;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        originalColor = sprite.color;
        isTriggered = true;
    }

    void Update()
    {
        if (!isTriggered) 
        {
            time += Time.deltaTime;
            if(time > 30)
            {
                sprite.color = originalColor;
                time = 0;
                isTriggered = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isTriggered = true;
            sprite.color = new Vector4(Random.Range(0, 150), Random.Range(0, 150), Random.Range(0, 150), 255.0f).normalized;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isTriggered = false;
        }
    }


}
