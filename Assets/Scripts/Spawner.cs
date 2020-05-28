using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject norm;
    public GameObject note;
    public GameObject[] notes;
    public Conductor cd;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnNorm", 0f, 2f);
        //InvokeRepeating("SpawnNote", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnNorm()
    {
        norm.GetComponentInChildren<Note>().velocity = cd.GetVelocity();
        Instantiate(norm, transform.position, Quaternion.identity);
        //yield return new WaitForSeconds(2);
        //StartCoroutine(SpawnNorm());
    }
    public void SpawnNote(int idx)
    {
        //int idx = Random.Range(0, 4);
        //Debug.Log(idx);
        GameObject n = notes[idx];
        //may have to change this to singleton
        n.GetComponent<Note>().velocity = cd.GetVelocity();
        //n.GetComponent<Note>().velocity = 2f;
        Instantiate(n, transform.position, Quaternion.identity);
        //yield return new WaitForSeconds(0.5f);
        //StartCoroutine(SpawnNote());
    }

    public void SpawnNotek()
    {
        int idx = Random.Range(0, 4);
        //Debug.Log(idx);
        GameObject n = notes[idx];
        //may have to change this to singleton
        n.GetComponent<Note>().velocity = cd.GetVelocity();
        //n.GetComponent<Note>().velocity = 2f;
        Instantiate(n, transform.position, Quaternion.identity);
        //yield return new WaitForSeconds(0.5f);
        //StartCoroutine(SpawnNote());
    }
}
