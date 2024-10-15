using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Colisor : MonoBehaviour
{
    float DelayControler = 10f;
    

    [SerializeField] AudioClip win;
    [SerializeField] AudioClip death;

    [SerializeField] ParticleSystem winEfect;
    [SerializeField] ParticleSystem deathEfect;

    AudioSource audioSource;

    Renderer playerRender;

    bool isTransitioning = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerRender = GetComponent<Renderer>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning == false)
        {
            switch (other.gameObject.tag)
            {
                case "Inicio":
                Debug.Log("You Started From... Start");
                break;

                case "Final":
                audioSource.Stop();
                audioSource.PlayOneShot(win);
                winEfect.Play();
                Invoke("nextLevel", 3.8f * Time.deltaTime * DelayControler);
                break;

                case "Fuel":
                Destroy(other.gameObject);
                break;

                case "Destruct":
                Invoke("restart", 2f * Time.deltaTime * DelayControler);
                audioSource.Stop();
                audioSource.PlayOneShot(death);
                deathEfect.Play(deathEfect);
                playerRender.enabled = false;
                GetComponent<MovimentoFoguete>().enabled = false;
                    break;

            }

        }
    }

    void restart()
    {
        isTransitioning = true;
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    void nextLevel()
    {
        isTransitioning = true;
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;
        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }
        SceneManager.LoadScene(nextScene);
    }
}