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

    public GameObject[] enemies;
    public UnityEvent ifEnemiesDead;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        triggerEvent.Invoke();
        if (CheckEnemies())
        {
            ifEnemiesDead.Invoke();
        }
    }

    public void DestroyObject(GameObject obj)
    {
        Destroy(obj);
    }
    
    public bool CheckEnemies()
    {
        foreach (var enemy in enemies)
        {
            if (enemy != null)
            {
                return false;
            }
        }

        return true;
    }
}
