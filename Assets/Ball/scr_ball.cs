using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float ballSpeed = 10;

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
        transform.position = new Vector2(0, 0);
        rb.AddForce(Vector2.down * ballSpeed * Time.deltaTime * 100);
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "DeadEnd") {
            Debug.Log("Dead");
            InitiateBall();
        }

    }
}
