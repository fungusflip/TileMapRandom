using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterSheet : MonoBehaviour
{
// Where the stats start :D
    private string UsrName = "";
    private float STR = 0;
    private float CON = 0;
    private float INT = 0;
    private float WIS = 0;
    private float CHA = 10;
    private float DEX = 50;


    // Start is called before the first frame update

    //maybe define Stats

    // Update is called once per frame

    //add 



    
    void Update()
    {
        PlayerPrefs.SetFloat("STR", STR);
        PlayerPrefs.SetFloat("CON", CON);
        PlayerPrefs.SetFloat("INT", INT);
        PlayerPrefs.SetFloat("WIS", WIS);
        PlayerPrefs.SetFloat("CHA", CHA);
        PlayerPrefs.SetFloat("DEX", DEX);

    }
 
}
