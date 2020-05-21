using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SongHolder : MonoBehaviour
{
    public Song song;

    private void Update()
    {
        if (song != null)
        {
            GetComponentInChildren<TextMeshPro>().text = song.songName;
        }

    }
}
