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
        rb.AddForce(Vector2.down * ballSpeed * Time.deltaTime * 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
