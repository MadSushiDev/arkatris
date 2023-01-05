using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float ballSpeed = 25;


    private Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        InitiateBall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void InitiateBall() {
        rb.velocity = new Vector2 (0,0);
        transform.position = new Vector2(5, 5);
        velocity.x = Random.Range(-1, 1);
        velocity.y = 1;
        rb.AddForce(velocity * ballSpeed);
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "DeadEnd") {
            FindObjectOfType<scr_gameManager>().GameOver();
            //InitiateBall();
        }
        if (collision.gameObject.name == "obj_Player") {
            float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth) { return (ballPos.x - racketPos.x) / racketWidth; }
            float x = hitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.x);
            Vector2 dir = new Vector2(x, 1).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * ballSpeed/2;
        }

    }
}
