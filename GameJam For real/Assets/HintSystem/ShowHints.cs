using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHints : MonoBehaviour
{
    public GameObject hint_start, hint_1, hint_2;

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;  
    }

    private void GameManagerOnGameStateChanged(GameState state)
    {
        hint_start.SetActive(state == GameState.Start);
        hint_1.SetActive(state == GameState.Death_1);
        hint_2.SetActive(state == GameState.Death_2);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
