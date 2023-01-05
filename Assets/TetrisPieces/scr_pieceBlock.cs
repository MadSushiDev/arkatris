using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_pieceBlock : MonoBehaviour
{
    public scr_tetrisPiece piecefeRef;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ball") {
            piecefeRef.Hit();
            Destroy(gameObject);
        }
    }
}
