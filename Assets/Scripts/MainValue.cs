using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainValue : Singleton<MainValue>
{
    public IDictionary<string, Vector3> CameraPostion = new Dictionary<string, Vector3>()
    {
        { "mainGame", new Vector3(0,0,-10)}
    };
    public IDictionary<string, float> FloatValue = new Dictionary<string, float>()
    {
        { "left", 0f},
        {"right", 0f }
    };
    public string selectedMenu = "all song";
}
