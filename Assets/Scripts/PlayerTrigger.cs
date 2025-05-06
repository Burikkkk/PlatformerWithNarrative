using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerTrigger : MonoBehaviour
{
    public UnityEvent triggerEvent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        triggerEvent.Invoke();
    }

    public void DestroyObject(GameObject obj)
    {
        Destroy(obj);
    }
}
