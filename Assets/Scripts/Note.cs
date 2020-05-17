using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    SpriteRenderer sr;
    public string type;
    Rigidbody2D rb;
    public float health;
    public float dec;
    public Sprite image;
    public float velocity;
    public string text;

    ////class constructure
    //public  Note(string _type)
    //{
    //    type = _type;
    //}
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(8, 9);
        Physics2D.IgnoreLayerCollision(8, 0);
        //Physics2D.IgnoreLayerCollision(9, 9);
        rb.velocity = new Vector2(-velocity, 0f);
    }
    public void Decrease()
    {
        health -= dec;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
