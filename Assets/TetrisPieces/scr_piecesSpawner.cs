using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_piecesSpawner : MonoBehaviour
{
    public GameObject[] Pieces;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnPiece();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPiece() {

        
        int randomPos = Random.Range(0, 6);
        Instantiate(Pieces[Random.Range(0, Pieces.Length)], new Vector3(transform.position.x+randomPos,transform.position.y,0), Quaternion.identity);
    }
}
