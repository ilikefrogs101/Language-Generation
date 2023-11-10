using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EampleWordDisplay : MonoBehaviour
{
    public Alphabet alphabet;
    public TMP_Text display;
    public void GenerateWord()
    {
        display.text = WordGenerator.GenerateWord(alphabet);
    }
}
