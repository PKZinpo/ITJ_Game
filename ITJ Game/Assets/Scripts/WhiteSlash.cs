using UnityEngine;

public class WhiteSlash : MonoBehaviour {

    public AudioManager audioManager;

    public void WhiteFadeLevelOne() {
        audioManager.Play("Boom");
        SceneLoader.DoWhiteFadeLevelOne();
    }
}
