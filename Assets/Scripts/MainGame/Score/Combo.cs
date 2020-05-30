using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Combo : MonoBehaviour
{
    public Animator comboAnimation;
    int comboAmount;
    TextMeshPro tmp;
    public MeshRenderer comboText;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        int newComboAmount = MainValue.Instance.combo;
        if(newComboAmount < 10)
        {
            //not display combo
            tmp.text = "";
            comboText.enabled = false;
        }
        else if(newComboAmount != comboAmount)
        {
            tmp.text = newComboAmount.ToString();
            //play animation
            comboAnimation.SetTrigger("bounce");
            comboText.enabled = true;
        }
        comboAmount = newComboAmount;
    }
}
