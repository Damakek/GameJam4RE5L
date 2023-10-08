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
        hint_1.SetActive(GameManager.Instance.playerDeaths == 1 && state == GameState.Death);
        hint_2.SetActive(GameManager.Instance.playerDeaths > 1 && state == GameState.Death);
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
