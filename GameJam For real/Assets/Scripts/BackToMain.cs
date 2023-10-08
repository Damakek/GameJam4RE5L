using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMain : MonoBehaviour
{
    public void btMain()
    {
        AudioManager.Instance.src.clip = AudioManager.Instance.gunShot;
        AudioManager.Instance.src.Play();
        SceneManager.LoadScene(0);        
    }
}
