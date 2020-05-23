using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using TMPro;

public class SongListManager : MonoBehaviour
{
    DefaultControl inputAction;

    List<Song> songList;

    public SongHolder[] songs;
    Vector3[] positions;
    Vector3[] oldPos;
    float lastPress;
    int rightEdge;
    int leftEdge;
    public float speed;

    public int center;

    int firstSong;
    int lastSong;
    int songsCount;
    bool isLock;

    public float songPosition;
    public float dspSongTime;

    AudioSource aS;

    void Awake()
    {
        Debug.Log("Awake");
        inputAction = new DefaultControl();
        inputAction.Gameplay.rightInner.performed += ctx => Select();
        inputAction.Gameplay.rightOuter.performed += ctx => GoLeft();
        //inputAction.Gameplay.leftInner.performed += ctx => HitLI();
        inputAction.Gameplay.leftOuter.performed += ctx => GoRight();
        //inputAction.Gameplay.DoubleInner.performed += ctx => HitDI();
    }

    void Start()
    {
        aS = GetComponent<AudioSource>();

        //set up default position for each song label
        positions = new Vector3[songs.Length];
        oldPos = new Vector3[songs.Length];
        for (int i = 0; i < songs.Length; i++)
        {
            positions[i] = songs[i].transform.position;
            oldPos[i] = positions[i];
        }
        leftEdge = 0;
        rightEdge = songs.Length - 1;

        //Load up song data
        string json = Resources.Load<TextAsset>("List").ToString();
        songList = JsonConvert.DeserializeObject<List<Song>>(json);
        //sort songs by song name
        songList.Sort((x, y) => string.Compare(x.songName, y.songName));
        firstSong = songList.Count - 1;
        lastSong = songs.Length/2;
        songsCount = songList.Count;
        for (int i=center; i < songs.Length; i++)
        {
            songs[i].song = songList[i-center];
        }
        for (int i = 0; i < center; i++)
        {
            songs[i].song = songList[songsCount - center + i];
        }
        //play first song
        StartCoroutine(PlaySample(songs[center].song.fileName, songs[center].song.startAt));

    }

    // Update is called once per frame
    void Update()
    {
        songPosition = (float)(AudioSettings.dspTime - dspSongTime);
        if(songPosition < 3f)
        {
            aS.volume += 0.003f;
            //aS.volume += Mathf.Lerp(0, 1, songPosition / 3);
            //Debug.Log(Mathf.Lerp(0, 1, songPosition / 3));
        }
        if (songPosition > 8f)
        {
            aS.volume -= 0.003f;
        }
        float now = Time.time;
        int c = 0;
        for (int i = 0; i < songs.Length; i++)
        {
            if (songs[i].transform.position != positions[i])
            {
                songs[i].transform.position = Vector3.Lerp(songs[i].transform.position, positions[i], Mathf.Min((now - lastPress) * speed, 1f));
                c++;
            }
        }
        isLock = c != 0;
    }

    public void GoLeft()
    {
        if (!isLock)
        {
            center = center + 1 < songs.Length ? center + 1 : 0;
            //aS.Stop();
            //dspSongTime = (float)AudioSettings.dspTime;
            //aS.PlayOneShot(Resources.Load<AudioClip>(songs[center].song.fileName));
            //aS.volume = 0;
            StopAllCoroutines();
            StartCoroutine(PlaySample(songs[center].song.fileName, songs[center].song.startAt));
            Vector3 pos = songs[rightEdge].transform.position;

            for (int i = 0; i < songs.Length; i++)
            {
                if (i != leftEdge)
                {
                    oldPos[i] = positions[i];
                    positions[i] = songs[i - 1 >= 0 ? i - 1 : songs.Length - 1].transform.position;
                    if (positions[i] == positions[leftEdge])
                    {
                        songs[leftEdge].transform.position = pos;
                        songs[leftEdge].song = songList[(lastSong + 1) % songsCount];
                        lastSong++;
                        positions[leftEdge] = pos;
                        oldPos[leftEdge] = pos;
                        rightEdge = leftEdge;
                        leftEdge = i;
                    }
                }
            }

            lastPress = Time.time;
        }
    }

    public void Select()
    {
        MainValue.Instance.mainClip = aS.clip;
        MainValue.Instance.canDestroy = true;
        MainValue.Instance.sceneToLoad = "MainGame";
    }

    public void GoRight()
    {
        Debug.Log("right");
        if (!isLock)
        {
            center = center - 1 >= 0 ? center - 1 : songs.Length - 1;
            StopAllCoroutines();
            StartCoroutine(PlaySample(songs[center].song.fileName, songs[center].song.startAt));
            Vector3 pos = songs[leftEdge].transform.position;

            for (int i = 0; i < songs.Length; i++)
            {
                if (i != rightEdge)
                {
                    oldPos[i] = positions[i];
                    positions[i] = songs[i + 1 <= songs.Length - 1 ? i + 1 : 0].transform.position;
                    if (positions[i] == positions[rightEdge])
                    {
                        songs[rightEdge].transform.position = pos;
                        firstSong = firstSong - 1 >= 0 ? firstSong - 1 : songsCount - 1;
                        songs[rightEdge].song = songList[firstSong];
                        positions[rightEdge] = pos;
                        oldPos[rightEdge] = pos;
                        leftEdge = rightEdge;
                        rightEdge = i;
                    }
                }
            }
            lastPress = Time.time;
        }
    }

    IEnumerator PlaySample(string song, double startAt)
    {
        yield return new WaitForSeconds(0.1f);
        MainValue.Instance.canDestroy = false;
        //stop what is currently playing
        aS.Stop();
        dspSongTime = (float)AudioSettings.dspTime;
        //load audio
        aS.clip = Resources.Load<AudioClip>(song);
        //play audio at given position
        aS.PlayScheduled(startAt);
        //aS.PlayOneShot(Resources.Load<AudioClip>(song));
        aS.time = (float)startAt;
        aS.volume = 0;
    }

    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }
}