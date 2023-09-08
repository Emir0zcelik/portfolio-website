using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AboutMe : MonoBehaviour
{
    private SpriteRenderer sprite;

    [SerializeField] private GameObject[] Letters;

    private bool isTriggered;
    private float coolDown = 0;
    private Vector4 originalColor;

    private float time = 0;


    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        originalColor = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
        isTriggered = true;
    }

    void Update()
    {
        if (!isTriggered) 
        {
            time += Time.deltaTime;
            
            if(time > 15)
            {
                foreach (var l in Letters)
                {
                    l.GetComponent<SpriteRenderer>().color = originalColor;
                }
                time = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isTriggered = true;
            foreach (var l in Letters)
            {
                l.GetComponent<SpriteRenderer>().color = new Vector4(Random.Range(0, 165), Random.Range(0, 70), Random.Range(0, 125), 255.0f).normalized;
            }
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
