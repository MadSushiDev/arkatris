using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_piecesSpawner : MonoBehaviour
{
    public GameObject[] Pieces;
    public scr_gameManager gameManagerRef;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPiece() {
        if (gameManagerRef.gameStarted) {
            int randomPos = Random.Range(0, 8);
            Instantiate(Pieces[Random.Range(0, Pieces.Length)], new Vector3(transform.position.x + randomPos, transform.position.y, 0), Quaternion.identity);
        }
        
    }
}
