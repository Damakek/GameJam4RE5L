using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        AudioManager.Instance.src.clip = AudioManager.Instance.gunShot;
        AudioManager.Instance.src.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        AudioManager.Instance.src.clip = AudioManager.Instance.gunShot;
        AudioManager.Instance.src.Play();
        Application.Quit();
    }
}
