using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TMP_Text text;
    public string[] phrases;

    private int currentPhrase;

    public void NextPhrase()
    {
        if (currentPhrase >= phrases.Length)
        {
            text.enabled = false;
            return;
        }
        text.text = phrases[currentPhrase];
        currentPhrase += 1;
    }
}
