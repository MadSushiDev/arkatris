using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_gameManager : MonoBehaviour
{
    public GameObject startText;
    public GameObject ballRef;
    public GameObject playerRef;
    public bool gameStarted = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)&& !gameStarted) {
            gameStarted = true;
            BeginPlay();
           
        }
    }

    void BeginPlay() {
        startText.SetActive(false);
        FindObjectOfType<scr_piecesSpawner>().SpawnPiece();
        Instantiate(ballRef, playerRef.transform.position, Quaternion.identity);
    }

    public void GameOver() {
        startText.SetActive(true);
        gameStarted = false;
        //Elimina las instancias de los bloques en pantalla
        var instances = GameObject.FindGameObjectsWithTag("Block");
        foreach (var obj in instances) {
            Destroy(obj);
        }
        //Elimina la instancia de la bola
        var ballInstances = GameObject.FindGameObjectsWithTag("Ball");
        foreach (var ball in ballInstances) {
            Destroy(ball);
        }
    }
}
