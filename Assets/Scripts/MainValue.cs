using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainValue : Singleton<MainValue>
{
    public IDictionary<string, Vector3> CameraPostion = new Dictionary<string, Vector3>()
    {
        { "mainGame", new Vector3(0,0,-10) },
        { "mainMenu", new Vector3(-22, 0, -10) }
    };
    public IDictionary<string, float> FloatValue = new Dictionary<string, float>()
    {
        { "left", 0f},
        {"right", 0f }
    };
    public IDictionary<string, Object> SongListValue = new Dictionary<string, Object>()
    {
    };
    public IDictionary<string, int> SceneIndex = new Dictionary<string, int>()
    {
        { "SongList", 0},
        {"MainGame", 1}
    };
    public string selectedMenu = "all song";
    public string crrScene = "mainGame";
    public AudioClip mainClip;
    public bool canDestroy;
    public string sceneToLoad = "";
    public float crrSecPerBeat = 0f;
    public int combo;
    public int score;
    public Song mainSong;
}
