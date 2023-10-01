using UnityEngine;
using TMPro;

public class INTTEXT : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    void Update()
    {
        float INT = PlayerPrefs.GetFloat("INT");
        textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.text = $"INT {INT}";
    }
}
