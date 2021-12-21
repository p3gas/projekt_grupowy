using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject balloonPrefab;
    public Vector3 balloonSpawnLocation;
    public PinController leftPin;
    public PinController rightPin;
    public Text time;
    public Text score;
    public Text wrongHits;

    private float balloonSpawnInterval = 5.0f;
    private float timePassed = 0.0f;
    private float balloonSpawnCd = 0.0f;
    private int leftPinColor;
    private int rightPinColor;
    private int totalBalloonsToBeHit = 0;
    private int correctBalloonsHit = 0;
    private int incorrectBalloonsHit = 0;

    // Start is called before the first frame update
    void Start()
    {
        // balloonSpawnInterval = ?
        rightPinColor = Random.Range(0, 8);
        rightPin.SetColor(rightPinColor);
        leftPinColor = Random.Range(0, 8);
        leftPin.SetColor(leftPinColor);
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        balloonSpawnCd += Time.deltaTime;
        if (timePassed >= 30)
        {
            // pass the score, compute difficulty level, exit scene
            Time.timeScale = 0f;
        }
        if (balloonSpawnCd >= balloonSpawnInterval)
        {
            SpawnBalloon();
            balloonSpawnCd = 0.0f;
        }

        time.text = "00:" + (int)(30 - timePassed);
        score.text = correctBalloonsHit + "/" + totalBalloonsToBeHit;
        wrongHits.text = "(" + incorrectBalloonsHit + ")";
    }

    public void SpawnBalloon()
    {
        int locationVersion = Random.Range(0, 2);
        if (locationVersion == 0)
        {
            locationVersion = -1;
        }
        Vector3 spawnLocation = new Vector3(balloonSpawnLocation.x * locationVersion * (-1), balloonSpawnLocation.y, balloonSpawnLocation.z);
        GameObject balloon = Instantiate(balloonPrefab, spawnLocation , balloonPrefab.transform.rotation);
        int balloonColor = Random.Range(0, 8); // based on difficulty level;
        balloon.SendMessage("SetDirection", locationVersion);
        balloon.SendMessage("SetColor", balloonColor);
        if (balloonColor == leftPinColor || balloonColor == rightPinColor)
        {
            totalBalloonsToBeHit++;
        }
    }

    public void NotifyAboutCorrectHit()
    {
        correctBalloonsHit++;
    }

    public void NotifyAboutIncorrectHit()
    {
        incorrectBalloonsHit++;
    }
}
