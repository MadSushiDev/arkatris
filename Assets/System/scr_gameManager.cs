using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_gameManager : MonoBehaviour
{
    public GameObject startText;
    public GameObject ballRef;
    public GameObject playerRef;
    public Text scoreText;
    public Text livesText;
    public bool gameStarted = false;
    public int score;
    public int lives = 3;
    public AudioSource audioSrc;
    public AudioClip damageClip;
    
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
            UpdateScore();
        }
    }

    void BeginPlay() {
        startText.SetActive(false);
        FindObjectOfType<scr_piecesSpawner>().SpawnPiece();
        Instantiate(ballRef, playerRef.transform.position, Quaternion.identity);
        score = 0;
        lives = 3;
        
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

    public void AddScore(int points) {
        score += points;
        UpdateScore();
    }

    public void Damage(int points) {
        audioSrc.PlayOneShot(damageClip);
        lives -= points;
        if (lives < 0) {
            lives = 0;
        }
        UpdateScore();

    }
    void UpdateScore() {
        scoreText.text = "SCORE: " + score;
        livesText.text = "LIVES: " + lives;
    }
}
