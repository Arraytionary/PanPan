using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public MenuItem[] items;
    int index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoRight()
    {
        index++;
        if (index >= items.Length) index = 0;
        MenuItem selected = items[index];
        SetSelectedMenu(selected.name);
    }

    public void GoLeft()
    {
        index--;
        if (index < 0) index = items.Length - 1;
        MenuItem selected = items[index];
        SetSelectedMenu(selected.name);

    }

    void SetSelectedMenu(string selected)
    {
        MainValue.Instance.selectedMenu = selected;
    }
}
