using UnityEngine;

public class End : MonoBehaviour {

    void Start() {
        Invoke("ToTitle", 2f);
    }

    public void ToTitle() {
        SceneLoader.LoadLevel("Title Screen");
    }
}
