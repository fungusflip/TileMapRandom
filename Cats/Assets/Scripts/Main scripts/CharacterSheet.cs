using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class CharacterSheet : MonoBehaviour
{
// Where the stats start :D


    [SerializeField] private string UsrName = "";
    [SerializeField] private float STR ;
    [SerializeField] private float CON ;
    [SerializeField] private float INT ;
    [SerializeField] private float WIS ;
    [SerializeField] private float CHA ;
    [SerializeField] private float DEX ;

    void Awake()
    {
        GetStats();
        SetStats();
    }

    public void GetStats()
    {
        STR = PlayerPrefs.GetFloat("STR");
        CON = PlayerPrefs.GetFloat("CON");
        INT = PlayerPrefs.GetFloat("INT");
        WIS = PlayerPrefs.GetFloat("WIS");
        CHA = PlayerPrefs.GetFloat("CHA");
        DEX = PlayerPrefs.GetFloat("DEX");
   
    }
    public void SetStats()
    {
        
        PlayerPrefs.Save();
        PlayerPrefs.SetFloat("STR", STR);
        PlayerPrefs.SetFloat("CON", CON);
        PlayerPrefs.SetFloat("INT", INT);
        PlayerPrefs.SetFloat("WIS", WIS);
        PlayerPrefs.SetFloat("CHA", CHA);
        PlayerPrefs.SetFloat("DEX", DEX);
        PlayerPrefs.Save();
    }
    
    public enum CharacterStat
    {
        STR,
        CON,
        INT,
        WIS,
        CHA,
        DEX
    }
    private CharacterStat ParseStat(string stat)
    {
        CharacterStat parsedStat;
        if (Enum.TryParse(stat, out parsedStat))
        {
            return parsedStat;
        }
        else
        {
            // Handle the case where the input string does not match any CharacterStat
            Debug.LogError("Invalid stat name: " + stat);
            return CharacterStat.STR; // You can choose a default stat here
        }
    }

    public void AdjustStat(string stat, float amount)
    {
        CharacterStat parsedStat = ParseStat(stat);

        switch (parsedStat)
        {
            case CharacterStat.STR:
                STR += amount;
                break;
            case CharacterStat.CON:
                CON += amount;
                break;
            case CharacterStat.INT:
                INT += amount;
                break;
            case CharacterStat.WIS:
                WIS += amount;
                break;
            case CharacterStat.CHA:
                CHA += amount;
                break;
            case CharacterStat.DEX:
                DEX += amount;
                break;
        }

        // Update PlayerPrefs after changing the stat
        SetStats();
    }

 
}
