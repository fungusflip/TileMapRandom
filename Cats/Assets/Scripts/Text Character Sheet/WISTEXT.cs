using UnityEngine;
using TMPro;

public class WISTEXT : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    void Update()
    {
        float WIS = PlayerPrefs.GetFloat("WIS");
        textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.text = $"WISDOM{WIS}";
    }
}
