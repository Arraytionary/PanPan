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

    public float offset;

    float lastPos;

    float lp2;

    public float db;

    public Spawner spawner;

    public GameObject register;

    bool spawned;

    int[] sample;

    int idx;

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

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        musicSource.clip = MainValue.Instance.mainClip;

        //Start the music
        musicSource.Play();

        lastPos = -4f;

        lp2 = -9f;

        spawned = false;

        sample = new int[] { 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 6 };

        distance = Mathf.Abs(register.transform.position.x - spawner.gameObject.transform.position.x);

    }

    // Update is called once per frame
    void Update()
    {
        //determine how many seconds since the song started
        songPosition = (float)(AudioSettings.dspTime - dspSongTime);

        //determine how many beats since the song started
        songPositionInBeats = (int)(songPosition / secPerBeat) - offset;
        if (songPositionInBeats % 4 == 0 && songPositionInBeats - lp2 > 0)
        {
            spawner.SpawnNorm();
            lp2 = songPositionInBeats;
            //spawner.SpawnNote();
        }
        if (songPositionInBeats >= -3)
        {
            if (songPositionInBeats - lastPos > 0)
            {

                //lastPos = songPositionInBeats;

                //else
                //{

                    spawner.SpawnNote();

                //}

                db += 1;
            }
            lastPos = songPositionInBeats;
        }
    }
    public float GetVelocity()
    {
        return distance/(offset*secPerBeat);
    }
}
