using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public GameObject asteroid;
    public GameObject collectible;
    public GameObject pill;
    
    float collectibleTime = 1f;
    float asteroidTime = 3f;
    float pillTime = 30f;
    //float startingTime = 30;

    private void Update()
    {
        asteroidTime -= 1 * Time.deltaTime;
        collectibleTime -= 1 * Time.deltaTime;
        pillTime -= 1 * Time.deltaTime;

        if (asteroidTime <= 0)
        {
            Instantiate(asteroid, new Vector3(Random.Range(-Screen.width, Screen.width), Random.Range(-Screen.height, Screen.height)), Quaternion.identity);
            asteroidTime = 3f;
        }

        if (collectibleTime <= 0)
        {
            Instantiate(collectible, new Vector3(Random.Range(-Screen.width, Screen.width), Random.Range(-Screen.height, Screen.height)), Quaternion.identity);
            collectibleTime = 1f;
        }
        
        if (pillTime <= 0)
        {
            Instantiate(pill, new Vector3(Random.Range(-Screen.width, Screen.width), Random.Range(-Screen.height, Screen.height)), Quaternion.identity);
            pillTime = 30f;
        }
    }
}
