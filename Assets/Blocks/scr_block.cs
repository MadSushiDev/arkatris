using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_block : MonoBehaviour
{
    public float lifePoints = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ball") {
            Hit();
        }
    }

    void Hit() {
        lifePoints -= 1;
        if (lifePoints <= 0) {
            Destroy(gameObject);
        }
    }
}
