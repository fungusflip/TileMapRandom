using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAKEMEHOME : MonoBehaviour
{
    [SerializeField]
    private GameObject sheet;
    [SerializeField]
    private GameObject Spawn;

    public void TakeMeHome(){

        sheet.SetActive(false);
        Spawn.SetActive(true);
    }
    
}
