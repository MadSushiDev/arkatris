using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_tetrisPiece : MonoBehaviour
{
    public Vector3 rotationPoint;
    private float previousTime;
    public float fallTime = 0.2f;
    public static int height = 20;
    public static int width = 10;
    private static Transform[,] grid = new Transform[width, height];
    private int lifePoints = 4;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       /* if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            transform.position += new Vector3(-1, 0, 0);
            if (!ValidMove()) {
                transform.position -= new Vector3(-1, 0, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            transform.position += new Vector3(1, 0, 0);
            if (!ValidMove()) {
                transform.position -= new Vector3(1, 0, 0);
            }
        }*/

        if (Time.time - previousTime > fallTime) {
            transform.position += new Vector3(0, -1, 0);
            if (!ValidMove()) {
                transform.position -= new Vector3(0, -1, 0);
                AddToGrid();
                CheckLines();
                this.enabled = false;
                FindObjectOfType<scr_piecesSpawner>().SpawnPiece();
            }
            previousTime = Time.time;
        }
    }

    void CheckLines() {
        for (int i = height-1; i >= 0; i--) {
            if (HasLine(i)) {
                DeleteLine(i);
                RowDown(i);
            }
        }
    }
    
    bool HasLine(int i) {
        for(int j = 0; j<width; j++) {
            if (grid[j, i] == null)
                return false;
        }
        return true;
    }

    void DeleteLine(int i) {
        for (int j = 0; j < width; j++) {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
        }

    void RowDown(int i) {
        for (int y = i; y < height; y++) {
            for (int j = 0; j < width; j++) {
                if (grid[j,y] != null) {
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }
    void AddToGrid() {
        foreach (Transform children in transform) {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);
            grid[roundedX, roundedY] = children;
        }
    }
    bool ValidMove() {
        foreach (Transform children in transform) {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if(roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height) {
                return false;
            }

            if(grid[roundedX,roundedY] != null) {
                return false;
            }
        }
        return true;
    }
   public void Hit() {
        FindObjectOfType<scr_gameManager>().AddScore(100);
        if (ValidMove()) { 
           lifePoints -= 1;
            if (lifePoints <= 0) {
                FindObjectOfType<scr_piecesSpawner>().SpawnPiece();
                Destroy(gameObject);
            }
        }
   }
    
}
