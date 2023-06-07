using UnityEngine;
using TMPro;

public class CHATEXT : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    void Update()
    {
        float CHA = PlayerPrefs.GetFloat("CHA");
        textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.text = $"CHARISMA {CHA}";
    }
}
