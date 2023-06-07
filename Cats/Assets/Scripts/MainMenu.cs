using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {
// first function changes scene
        public void GoToScene (string sceneName) {
            SceneManager.LoadScene(sceneName);
        }
//this exists app
        public void QuitApp(){
            Application.Quit();
            Debug.Log("Application has quit");
        }
    
}
