using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItem : MonoBehaviour
{
    public string name;
    public float speed;
    bool selected;
    Vector3 originalScale;
    Vector3 selectedScale;
    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
        selectedScale = transform.localScale += new Vector3(0.2f, 0.2f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (name == MainValue.Instance.selectedMenu)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, selectedScale, speed*Time.deltaTime);
        }
        else
            transform.localScale = originalScale;
    }


}
