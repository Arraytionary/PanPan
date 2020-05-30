using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject bloom;
    public GameObject flash;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        collision.gameObject.transform.position = gameObject.transform.position;
        Instantiate(bloom, gameObject.transform.position, Quaternion.identity);
        Instantiate(flash, gameObject.transform.position, Quaternion.identity);
        collision.gameObject.GetComponent<Rigidbody2D>().MovePosition(gameObject.transform.position);
        collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        Destroy(collision.gameObject, 0.5f);
    }
}
