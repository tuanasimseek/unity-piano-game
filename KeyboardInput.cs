using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public AudioSource c4AudioSource;
    public AudioSource d4AudioSource;
    public AudioSource e4AudioSource;
    public AudioSource f4AudioSource;
    public AudioSource g4AudioSource;
    public AudioSource a4AudioSource;
    public AudioSource b4AudioSource;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            c4AudioSource.Play();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            d4AudioSource.Play();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            e4AudioSource.Play();
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            f4AudioSource.Play();
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            g4AudioSource.Play();
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            a4AudioSource.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            b4AudioSource.Play();
        }
    }
}
