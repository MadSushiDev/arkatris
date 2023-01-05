using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_PlayerMovement : MonoBehaviour
{

    public scr_gameManager gameManagerRef;
    public Rigidbody2D rb;
    private float inputValue;
    public float speed = 25;
    private Vector2 direction;
    private bool invulnerable = false;

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        inputValue = Input.GetAxisRaw("Horizontal");

        if (inputValue == 1) {
            direction = Vector2.right;
        } else if (inputValue == -1) {
            direction = Vector2.left;
        } else {
            direction = Vector2.zero;
        }

        rb.AddForce(direction*speed*Time.deltaTime*100);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Block") {
            if (!invulnerable) {
                gameManagerRef.Damage(1);
                invulnerable = true;
                Invoke("ReturnVulnerable", 3);
            }
            if (gameManagerRef.lives > 0) {

            } else gameManagerRef.GameOver();


        }
    }

    private void ReturnVulnerable() {
        invulnerable = false;
    }
}
