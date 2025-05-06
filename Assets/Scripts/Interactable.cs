using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent interactEvent;
    public UnityEvent interactEventSecond;
    private bool playerStays;
    private bool firstPressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (playerStays)
            {
                if (!firstPressed)
                {
                    interactEvent.Invoke();
                    firstPressed = true;
                }
                else
                {
                    interactEventSecond.Invoke();
                    firstPressed = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerStays = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerStays = false;
        }  
    }
}
