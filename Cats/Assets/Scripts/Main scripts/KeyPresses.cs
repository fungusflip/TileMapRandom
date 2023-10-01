using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyPresses : MonoBehaviour
{
    [SerializeField] private GameObject characterSheet;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Handle the Escape key press here
            SceneManager.LoadScene(0);

            // Add your code for pausing the game, opening a menu, or other actions.
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            characterSheet.SetActive(true);
        }
    }
}
