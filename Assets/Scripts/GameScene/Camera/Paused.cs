using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Додайте цей рядок для доступу до UI-елементів

public class Paused : MonoBehaviour
{
    [SerializeField]
    GameObject pause;
    public Button pauseButton;

    void Start()
    {
        pause.SetActive(false);
        pauseButton.onClick.AddListener(OnPauseButtonClicked);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void PauseOff()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
    
    void OnPauseButtonClicked()
    {
        pause.SetActive(true);
        Time.timeScale = 0;
    }
}

