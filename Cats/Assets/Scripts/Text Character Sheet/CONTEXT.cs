using UnityEngine;
using TMPro;

public class CONTEXT : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    void Update()
    {
        float CON = PlayerPrefs.GetFloat("CON");
        textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.text = $"CONSTITUTION {CON}";
    }
}
