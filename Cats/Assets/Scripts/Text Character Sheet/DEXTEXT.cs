using UnityEngine;
using TMPro;

public class DEXTEXT : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    void Update()
    {
        float DEX = PlayerPrefs.GetFloat("DEX");
        textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.text = $"DEXTERITY {DEX}";
    }
}
