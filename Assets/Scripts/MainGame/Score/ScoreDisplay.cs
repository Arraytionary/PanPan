using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    TextMeshPro tmp;
    Animator animator;
    void Start()
    {
        tmp = GetComponent<TextMeshPro>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetTrigger("bounce");
        tmp.text = MainValue.Instance.score.ToString();

    }
}
