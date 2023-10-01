using UnityEngine;
using TMPro;

public class STRTEXT : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    void Update()
    {
        float STR = PlayerPrefs.GetFloat("STR");
        textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.text = $"STR {STR}";
    }
}
