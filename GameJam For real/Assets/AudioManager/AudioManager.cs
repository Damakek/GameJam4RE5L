using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;

    public AudioSource src;
    public AudioClip explosion, gunShot;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }


}
