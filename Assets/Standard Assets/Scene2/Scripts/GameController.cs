using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Camera cam;
    public GameObject pills;
    public float timeLeft;
    public Text timerText;
    public GameObject gameOver;
    public GameObject restart;
    public GameObject win;

    private float maxWidth;

    // Use this for initialization
    void Start()
    {
        // Get the mouse
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (cam == null)
        {
            cam = Camera.main;
        }

        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float pillsWidth = pills.GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - pillsWidth;

        StartCoroutine(Spawn());
        UpdateText();
    }

    void FixedUpdate()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            timeLeft = 0;
        }
        UpdateText();
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1.0f);

        while (timeLeft > 0)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-maxWidth, maxWidth), transform.position.y, 0.0f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(pills, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(0.5f, 1.2f));
        }

        if (FindObjectOfType<Score>().GetScore() >= 18) {
            yield return new WaitForSeconds(2.0f);
            win.SetActive(true);

            StartCoroutine(JumpScene());
        } 
        else 
        {
            yield return new WaitForSeconds(2.0f);
            gameOver.SetActive(true);
            yield return new WaitForSeconds(2.0f);
            restart.SetActive(true);
        }
    }

    void UpdateText()
    {
        timerText.text = "Time Left:\n" + Mathf.RoundToInt(timeLeft);
    }

    IEnumerator JumpScene()
    {
        yield return new WaitForSecondsRealtime(2);
        Initiate.Fade("Scene3", Color.white, 0.5f);

    }
}
