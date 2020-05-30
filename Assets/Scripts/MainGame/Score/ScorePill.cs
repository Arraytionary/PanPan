using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePill : MonoBehaviour
{
    // spire of inner pill
    public SpriteRenderer inner;
    //base color of pill
    public Color baseColor;
    
    //dim the base color
    public bool dim;
    //check wether to turn on mask mode
    public bool maskMode;
    void Start()
    {
        inner.color = baseColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (maskMode)
        {
            //enable masking
        }
        else
        {
            if (dim)
            {
                inner.color = new Color(baseColor.r -0.45f, baseColor.g - 0.25f, baseColor.b - 1.2f);
            }

            else
            {
                inner.color = baseColor;
            }
        }
    }
}
