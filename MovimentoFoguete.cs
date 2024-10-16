using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimentoFoguete : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] AudioClip soundEfect;

    AudioSource audioSource;

    [SerializeField]float RotationController = 100f;
    [SerializeField]float FlyController = -1000f;

    [SerializeField]ParticleSystem flyEfect;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rocketFly();
        rotation();
    }

    void rocketFly()
    {

        if (Input.GetKey(KeyCode.Space))
        {

            rb.AddRelativeForce(Vector3.up * FlyController * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(soundEfect);
                flyEfect.Play();
            }
            else
            {
                flyEfect.Stop();
            }
            
        }

    }

    void rotationMethod(float rotateThisFrame)
    {
        transform.Rotate(Vector3.left * rotateThisFrame * Time.deltaTime);
    }

    void rotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rotationMethod(RotationController);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotationMethod(-RotationController);
        }

    } 

}
