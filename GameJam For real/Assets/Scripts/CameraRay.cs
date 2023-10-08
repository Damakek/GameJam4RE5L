using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class CameraRay : MonoBehaviour
{

    public Tilemap tilemap;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPosition = Camera.main.transform.position;

        Vector3 directionToPlayer = player.position - cameraPosition;

        RaycastHit2D hit = Physics2D.Raycast(cameraPosition, directionToPlayer);

        if(hit.collider != null &&  hit.collider.gameObject != gameObject)
        {
            //Debug.Log("Ray Hit the Player");
        }
    }
}

