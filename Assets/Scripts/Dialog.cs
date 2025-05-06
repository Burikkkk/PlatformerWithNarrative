using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TMP_Text text1;
    public TMP_Text text2;
    public string[] phrases;

    private int currentPhrase;

    public void NextPhrase()
    {
        if (currentPhrase >= phrases.Length)
        {
            text1.enabled = false;
            text2.enabled = false;
            return;
        }

        var currentText = currentPhrase % 2 == 0 ? text1 : text2;
        currentText.text = phrases[currentPhrase];
        currentPhrase += 1;
    }
}
