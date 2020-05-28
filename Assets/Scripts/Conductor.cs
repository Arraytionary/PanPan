using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    //Song beats per minute
    //This is determined by the song you're trying to sync up to
    public float songBpm;

    //The number of seconds for each song beat
    public float secPerBeat;

    //Current song position, in seconds
    public float songPosition;

    //Current song position, in beats
    public float songPositionInBeats;

    //How many seconds have passed since the song started
    public float dspSongTime;

    public float startOffset;

    public float offset;

    float lastPos;

    float lp2;

    public float db;

    public Spawner spawner;

    public GameObject register;

    bool spawned;

    //int[,] sample;
    int[] sample;

    int idx;

    int id2;

    //
    float toto = 0.5f;
    //

    //distance btween spawner and register 
    public float distance;

    //an AudioSource attached to this GameObject that will play the music.
    public AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {
        //Load the AudioSource attached to the Conductor GameObject
        musicSource = GetComponent<AudioSource>();

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;
        MainValue.Instance.crrSecPerBeat = secPerBeat;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        //load music clip from MainValue
        //musicSource.clip = MainValue.Instance.mainClip;

        //Start the music
        musicSource.Play();

        lastPos = -offset;

        lp2 = -2*offset;

        spawned = false;

        //sample = new int[,] { { 0,0}, { 1,0}, { 1,0}, { 1,2}, { 1,0} };
        sample = new int[] { -1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,
        0,-1,-1,0,-1,-1,0,-1,-1,0,-1,-1,0,0,-1,-1,0,-1,0,-1,0,1,0,1,0,1,-1,1,-1,1,0,-1,-1,-1,-1,-1
        ,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1
        ,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1
        ,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1
        ,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1
        ,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1
        ,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1
        ,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};

        distance = Mathf.Abs(register.transform.position.x - spawner.gameObject.transform.position.x);
        Debug.Log(distance);

    }

    // Update is called once per frame
    void Update()
    {
        //determine how many seconds since the song started
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - startOffset);

        //determine how many beats since the song started
        //songPositionInBeats = (songPosition / secPerBeat) - offset;
        songPositionInBeats = (songPosition / secPerBeat);
        //if ((int)songPositionInBeats % 4 == 0 && (int)songPositionInBeats - lp2 > 1)
        //{
        //    spawner.SpawnNorm();
        //    lp2 = songPositionInBeats;
        //    //spawner.SpawnNote();
        //}
        if (songPositionInBeats >= -offset)
        {
            if (songPositionInBeats - lastPos > toto)
            {
                if(idx%8 == 0) spawner.SpawnNorm();
                //lastPos = songPositionInBeats;

                //else
                //{
                if (sample[idx] != -1)
                {
                    spawner.SpawnNote(sample[idx]);
                }
                idx++;

                //}

                db += 1;
                lastPos = songPositionInBeats;
            }
            
        }
    }
    public float GetVelocity()
    {
        return distance/(offset*secPerBeat);
    }
}
