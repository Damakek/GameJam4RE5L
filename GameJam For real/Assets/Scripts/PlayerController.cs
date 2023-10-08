using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform movePoint;

    public LayerMask whatStopsMovement;
    private bool hasMovedThisInput = false;

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
        
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.UpdateGameState(GameState.Start);
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (!hasMovedThisInput)
            {


                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
                {

                    GameManager.Instance.UpdateGameState(GameState.Playing);

                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopsMovement))
                    {
                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                        hasMovedThisInput = true;
                    }
                }
                else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
                {
                    //make it so that player has to move multiple times to delete
                    GameManager.Instance.UpdateGameState(GameState.Playing);

                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopsMovement))
                    {
                        movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                        hasMovedThisInput = true;
                    }
                }
            }
            if (Input.GetAxisRaw("Horizontal") == 0f && Input.GetAxisRaw("Vertical") == 0f)
            {
                hasMovedThisInput = false;
            }
        }
    }
}
