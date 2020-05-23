using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{   
    public SceneManager sm;

    public void Ready()
    {
        sm.LoadScene();
    }
}
