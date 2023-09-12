using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    [SerializeField] GameObject ChatBox;
    [SerializeField] GameObject[] texts;
    [SerializeField] GameObject exclamationMark;

    private Animator animator;

    private bool isTriggered;
    private bool isPressed;
    private int count;
    private float time;
    private float coolDown;

    private void Start()
    {
        animator = GetComponent<Animator>();

        isTriggered = false;
        isPressed = false;
        count = 0;
        time = 0;
        coolDown = 0;
    }

    private void Update()
    {
        if (isTriggered)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                isPressed = true;
            }
        }

        if (count > texts.Length)
        {
            animator.SetBool("isTalk", false);

            ChatBox.SetActive(false);
            isPressed = false;

            foreach (var text in texts)
            {
                text.SetActive(false);
            }
        }

        if (isPressed && count != texts.Length + 1) 
        {
            if (time < 5)
            {
                animator.SetBool("isTalk", true);

                time += Time.deltaTime;
                coolDown -= Time.deltaTime;
                ChatBox.SetActive(true);
                exclamationMark.SetActive(false);

                if (coolDown <= 0)
                {
                    texts[count++].SetActive(true);
                    coolDown = 5;
                }
            }
            else
            {
                animator.SetBool("isTalk", false);

                time = 0;
                isPressed =  false;
                ChatBox.SetActive(false);
                if (count != texts.Length)
                    exclamationMark.SetActive(true);

                foreach (var text in texts)
                {
                    text.SetActive(false);
                }
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
        isTriggered = false;
    }
}
