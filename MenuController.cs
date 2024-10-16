using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenu; // O painel do menu principal
    public GameObject optionsMenu; // O painel de opções
    public Button startButton; // Botão para iniciar o jogo
    public Button optionsButton; // Botão para abrir o menu de opções
    public Button exitButton; // Botão para sair do jogo
    public Button backButton; // Botão para voltar ao menu principal

    private void Start()
    {
        // Adiciona listeners aos botões
        startButton.onClick.AddListener(StartGame);
        optionsButton.onClick.AddListener(OpenOptions);
        exitButton.onClick.AddListener(ExitGame);
        backButton.onClick.AddListener(BackToMainMenu);

        // Mostra o menu principal no início
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    private void StartGame()
    {
        // Carrega a cena do jogo
        SceneManager.LoadScene("GameScene");
    }

    private void OpenOptions()
    {
        // Esconde o menu principal e mostra o menu de opções
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    private void BackToMainMenu()
    {
        // Esconde o menu de opções e mostra o menu principal
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    private void ExitGame()
    {
        // Fecha o aplicativo
        Application.Quit();
    }
}
