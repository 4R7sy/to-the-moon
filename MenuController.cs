using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public Button startButton;
    public Button optionsButton;
    public Button exitButton;
    public Button backButton;

    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
        optionsButton.onClick.AddListener(OpenOptions);
        exitButton.onClick.AddListener(ExitGame);
        backButton.onClick.AddListener(BackToMainMenu);

        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    private void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void OpenOptions()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    private void BackToMainMenu()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
