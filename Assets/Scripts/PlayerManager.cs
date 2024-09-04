using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public Slider healthDisplay;
    public TMP_Text scoreDisplay;
    public TMP_Text timerDisplay;
    public TMP_Text powerUpTimerDisplay;
    public TMP_Text finalScoreDisplay;
    public GameObject gameOverUI;
    public float score = 0;
    
    
    float currentTime = 30f;
    float scoreMultiplier = 1f;
    float powerUpTime = 11f;


    [SerializeField]
    int health = 100;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        powerUpTime -= 1 * Time.deltaTime;

        healthDisplay.value = health;
        scoreDisplay.text = "Score: " + Mathf.Ceil(score).ToString();
        timerDisplay.text = ((int)currentTime).ToString();
        powerUpTimerDisplay.text = ((int)powerUpTime).ToString();

        if (health <= 0 || currentTime <= 0)
        {
            Time.timeScale = 0f;
            gameOverUI.SetActive(true);
            finalScoreDisplay.text = scoreDisplay.text;
        }

        if (powerUpTime <= 0)
        {
            powerUpTime = 11f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            health -= 10;

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Collectible"))
        {
            score += scoreMultiplier * gameObject.transform.localScale.x;
            currentTime += .25f * gameObject.transform.localScale.x;


            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Pill"))
        {
            powerUpTime = 11f;
            StartCoroutine(PillEffect());

            Destroy(collision.gameObject);
        }
    }

    IEnumerator PillEffect()
    {
        powerUpTime = 11f;
        powerUpTimerDisplay.gameObject.SetActive(true);
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        foreach (GameObject asteroid in asteroids)
        {
            if (asteroid.gameObject == null)
                continue;
            else
                asteroid.tag = "Collectible";
        }
        scoreMultiplier = 2f;
        yield return new WaitForSeconds(10f);
        foreach (GameObject asteroid in asteroids)
        {
            if (asteroid.gameObject == null)
                continue;
            else
                asteroid.tag = "Asteroid";
        }
        scoreMultiplier = 1f; 
        powerUpTimerDisplay.gameObject.SetActive(false);
    }
}
