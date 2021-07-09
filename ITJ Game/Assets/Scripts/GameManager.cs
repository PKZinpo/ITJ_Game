using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

    
    public static void ResetLevel() {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

}
