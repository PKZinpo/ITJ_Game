using UnityEngine;

public class BigSamurai : MonoBehaviour {

    public GameObject screenSlashPreFab;
    public Animator samuraiAnim;
    public Transform bottomLeft;
    public Transform topRight;
    public LayerMask whatIsPlayer;
    public Vector3 offSet;

    public static bool isTouching = false;

    private bool touchSwitch = false;
    private AudioManager audioManager;
    void Start() {
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update() {

        isTouching = Physics2D.OverlapArea(bottomLeft.transform.position, topRight.transform.position, whatIsPlayer);
        samuraiAnim.SetBool("IsTouching", isTouching);
        if (isTouching && !touchSwitch) {
            Time.timeScale = 0.1f;
            touchSwitch = true;
        }
    }
    public void SpawnScreenSlash() {
        GameObject slash = Instantiate(screenSlashPreFab, transform.position, Quaternion.identity, transform);
        slash.transform.position += offSet;
        audioManager.Play("Slash");
    }
    public void SetTimeScale() {
        Time.timeScale = 0f;
    }
    public void WhiteFade() {
        SceneLoader.DoWhiteFade();
    }
    public void PlayBoom() {
        audioManager.Play("Boom");
    }
}
