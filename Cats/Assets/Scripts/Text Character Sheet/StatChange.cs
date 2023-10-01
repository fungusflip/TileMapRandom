using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatChange : MonoBehaviour
{
    [SerializeField] private CharacterSheet characterSheet;
    [SerializeField] private string Stat;
    

    public void UpStat()
    {
        // Create an instance of the CharacterSheet class
        CharacterSheet sheetInstance = characterSheet;

        // Call the instance methods to parse and adjust the stat
        sheetInstance.AdjustStat(Stat, 1.0f);
    }
    
    public void DownStat()
    {
        // Create an instance of the CharacterSheet class
        CharacterSheet sheetInstance = characterSheet;

        // Call the instance methods to parse and adjust the stat
        sheetInstance.AdjustStat(Stat,-1.0f);
    }
    
}
