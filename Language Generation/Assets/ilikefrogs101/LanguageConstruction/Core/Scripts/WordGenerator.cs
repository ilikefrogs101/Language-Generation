using UnityEngine;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public static class WordGenerator
{
    public static string GenerateWord(Alphabet alphabet)
    {
        int length = UnityEngine.Random.Range(alphabet.minimum, alphabet.maximum) + UnityEngine.Random.Range(0, alphabet.possibleIncrease);
        StringBuilder word = new StringBuilder();

        if (alphabet != null)
        {
            List<Sound> vowels = new List<Sound>();
            List<Sound> consonants = new List<Sound>();

            bool startWithVowel = (UnityEngine.Random.Range(0, 100) < alphabet.vowelStartChance);

            foreach (Sound sound in alphabet.sounds)
            {
                if (sound.vowel)
                    vowels.Add(sound);
                else
                    consonants.Add(sound);
            }

            if (vowels.Count == 0 || consonants.Count == 0)
            {
                Debug.LogError("Alphabet must contain both vowels and consonants.");
                return "FAILED";
            }

            System.Random random = new System.Random();

            for (int i = 0; i < length; i++)
            {
                if (i % 2 == 0 && vowels.Count > 0)
                {
                    if (startWithVowel)
                    {
                        double totalVowelFrequency = vowels.Sum(v => v.frequency); // Calculate total vowel frequency
                        double randomFrequency = random.NextDouble() * totalVowelFrequency; // Generate a random frequency value

                        int index = 0;
                        double cumulativeFrequency = 0;

                        // Find the vowel sound based on the random frequency
                        foreach (Sound vowel in vowels)
                        {
                            cumulativeFrequency += vowel.frequency;
                            if (randomFrequency < cumulativeFrequency)
                            {
                                word.Append(vowel.sound);
                                break;
                            }
                            index++;
                        }
                    }
                    else
                    {
                        double totalConsonantFrequency = consonants.Sum(c => c.frequency); // Calculate total consonant frequency
                        double randomFrequency = random.NextDouble() * totalConsonantFrequency; // Generate a random frequency value

                        int index = 0;
                        double cumulativeFrequency = 0;

                        // Find the consonant sound based on the random frequency
                        foreach (Sound consonant in consonants)
                        {
                            cumulativeFrequency += consonant.frequency;
                            if (randomFrequency < cumulativeFrequency)
                            {
                                word.Append(consonant.sound);
                                break;
                            }
                            index++;
                        }
                    }
                }
                else
                {
                    if (startWithVowel)
                    {
                        double totalConsonantFrequency = consonants.Sum(c => c.frequency); // Calculate total consonant frequency
                        double randomFrequency = random.NextDouble() * totalConsonantFrequency; // Generate a random frequency value

                        int index = 0;
                        double cumulativeFrequency = 0;

                        // Find the consonant sound based on the random frequency
                        foreach (Sound consonant in consonants)
                        {
                            cumulativeFrequency += consonant.frequency;
                            if (randomFrequency < cumulativeFrequency)
                            {
                                word.Append(consonant.sound);
                                break;
                            }
                            index++;
                        }
                    }
                    else
                    {
                        double totalVowelFrequency = vowels.Sum(v => v.frequency); // Calculate total vowel frequency
                        double randomFrequency = random.NextDouble() * totalVowelFrequency; // Generate a random frequency value

                        int index = 0;
                        double cumulativeFrequency = 0;

                        // Find the vowel sound based on the random frequency
                        foreach (Sound vowel in vowels)
                        {
                            cumulativeFrequency += vowel.frequency;
                            if (randomFrequency < cumulativeFrequency)
                            {
                                word.Append(vowel.sound);
                                break;
                            }
                            index++;
                        }
                    }
                }
            }
        }
        else
        {
            Debug.LogError("No Alphabet!");
            return "FAILED";
        }

        return word.ToString();
    }
}
