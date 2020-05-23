using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject startScene;
    public GameObject[] scenes;
    public Animator transition;
    GameObject crrScene;
    bool ready;
    void Start()
    {
        crrScene = Instantiate(startScene, transform.position, Quaternion.identity);
        ready = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!MainValue.Instance.sceneToLoad.Equals("") && ready)
        {
            transition.SetTrigger("fadeIn");
            while (!MainValue.Instance.canDestroy)
            {
                //spin wait
            }
            ready = false;
        }
    }

    public void LoadScene()
    {
        Destroy(crrScene);
        Debug.Log(MainValue.Instance.sceneToLoad);
        Debug.Log(MainValue.Instance.SceneIndex);
        Instantiate(scenes[MainValue.Instance.SceneIndex[MainValue.Instance.sceneToLoad]], transform.position, Quaternion.identity);
        MainValue.Instance.sceneToLoad = "";
        ready = true;
    }
}
