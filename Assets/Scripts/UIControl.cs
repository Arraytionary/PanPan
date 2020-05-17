using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public Image[] menues;
    Vector3[] positions;
    Vector3[] oldPos;
    float lastPress;
    int rightEdge;
    int leftEdge;
    // Start is called before the first frame update
    void Start()
    {
        positions = new Vector3[12];
        oldPos = new Vector3[12];
        for (int i=0;i<12;i++)
        {
            positions[i] = menues[i].transform.position;
            oldPos[i] = positions[i];
        }
        leftEdge = 0;
        rightEdge = 11;
    }

    // Update is called once per frame
    void Update()
    {
        float now = Time.time;
        for (int i=0; i < 12; i++)
        {
            if(menues[i].transform.position != positions[i])
            {
                menues[i].transform.position = Vector3.Lerp(oldPos[i], positions[i], Mathf.Min((now - lastPress)*4f, 1f));
            }
        }
        
    }

    public void GoLeft()
    {
        Vector3 pos = menues[rightEdge].transform.position;
        
        for(int i = 0; i < 12; i++)
        {
            if (i != leftEdge)
            {
                oldPos[i] = positions[i];
                positions[i] = menues[i - 1 >= 0?i-1:11].transform.position;
                if(positions[i] == positions[leftEdge])
                {
                    menues[leftEdge].transform.position = pos;
                    positions[leftEdge] = pos;
                    oldPos[leftEdge] = pos;
                    rightEdge = leftEdge;
                    leftEdge = i;
                }
            }
        }
        
        lastPress = Time.time;
    }

    public void GoRight()
    {
        Vector3 pos = menues[leftEdge].transform.position;
        
        for (int i = 0; i < 12; i++)
        {
            if (i != rightEdge)
            {
                oldPos[i] = positions[i];
                positions[i] = menues[i + 1 <= 11?i+1:0].transform.position;
                if (positions[i] == positions[rightEdge])
                {
                    menues[rightEdge].transform.position = pos;
                    positions[rightEdge] = pos;
                    oldPos[rightEdge] = pos;
                    leftEdge = rightEdge;
                    rightEdge = i;
                }
            }
        }
        
        lastPress = Time.time;
    }
}
