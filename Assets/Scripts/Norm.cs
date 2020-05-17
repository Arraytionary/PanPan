using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Norm : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(8, 9);
        Physics2D.IgnoreLayerCollision(8, 0);
    }
    private void Start()
    {
        rb.velocity = new Vector2(-4.5f, 0f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("ouch!!");
            
    }
}
