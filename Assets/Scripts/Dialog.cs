using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Dialog : MonoBehaviour
{
    public TMP_Text text1;
    public TMP_Text text2;
    public UnityEvent onEnd;
    public string[] phrases;

    private int currentPhrase;
    private bool ended = false;

    public void NextPhrase()
    {
        
        if (currentPhrase >= phrases.Length && !ended)
        {
            ended = true;
            onEnd.Invoke();
            text1.enabled = false;
            text2.enabled = false;
            return;
        }

        if (phrases[currentPhrase] == "")
        {
            currentPhrase++;
        }

        var currentText = currentPhrase % 2 == 0 ? text1 : text2;
        currentText.enabled = true;
        var otherText = currentPhrase % 2 == 1 ? text1 : text2;
        otherText.enabled = false;
        currentText.text = phrases[currentPhrase];
        currentPhrase += 1;
    }
}
