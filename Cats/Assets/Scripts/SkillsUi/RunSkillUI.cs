using UnityEngine;

public class RunSkillUI : MonoBehaviour
{
    [SerializeField]
    private GameObject RunSheet;
    // Start is called before the first frame update
    private void Start()
    {
        float Dex = PlayerPrefs.GetFloat("DEX");
        if (Dex >= 3){

            RunSheet.SetActive(true);
        }
        else 
        {
            RunSheet.SetActive(false);

        }
        
    }

}
