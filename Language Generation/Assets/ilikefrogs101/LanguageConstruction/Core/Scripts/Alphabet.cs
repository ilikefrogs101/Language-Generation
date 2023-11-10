using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Alphabet", menuName = "ScriptableObjects/Alphabet", order = 1)]
public class Alphabet : ScriptableObject
{
    public string Name;

    public int minimum;
    public int maximum;

    public int possibleIncrease;

    [Range(0, 100)]
    public int vowelStartChance;

    public List<Sound> sounds = new List<Sound>();
}

[System.Serializable]
public class Sound
{
    public string sound;
    public bool vowel;
    
    [Range(0, 100)]
    public double frequency;
}