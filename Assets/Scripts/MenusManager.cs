using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusManager : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject mainMenuUI;
    public GameObject tutorialMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            OnPause();
    }

    public void OnQuit()
    {
        Debug.Log("Quit Game!");
        Application.Quit();
    }

    public void OnReplay()
    {
        SceneManager.LoadScene(0);
    }

    public void OnPause()
    {
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
    }

    public void OnResume()
    {
        Time.timeScale = 1.0f;
        pauseUI.SetActive(false);
    }

    public void OnPlay()
    {
        mainMenuUI.SetActive(false);
        tutorialMenuUI.SetActive(true);
    }

    public void OnTutorialExit()
    {
        tutorialMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

}
