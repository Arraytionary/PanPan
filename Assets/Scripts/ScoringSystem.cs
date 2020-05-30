using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    public ScorePill pill;
    public ScorePill[] bar = new ScorePill[50];
    public int number;
    public Color color1;
    public Color color2;
    public ParticleSystem particle;
    int combo;
    int score;
    float barProgress;
    // Start is called before the first frame update
    void Start()
    {
        //Vector3 pos = gameObject.transform.position;
        //for (int i = 0; i < number; i++)
        //{
        //    bar[i] = Instantiate(pill, new Vector3(pos.x + i * pill.gameObject.GetComponent<SpriteRenderer>().bounds.size.x, pos.y, pos.z), Quaternion.identity);
        //    if(i < 34)
        //    {
        //        bar[i].baseColor = color1;
        //    }
        //    else bar[i].baseColor = color2;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if(barProgress == number - 1)
        {
            //enable mask mode
        }
        else
        {
            for (int i = 0; i < number; i++)
            {
                if(i < barProgress)
                {
                    bar[i].dim = false;
                }
                else
                {
                    bar[i].dim = true;
                }
            }
        }
    }

    public void SubmitScore(float score)
    {
        if(score < 0)
        {
            combo = 0;
            barProgress = Mathf.Max(barProgress + score, -1);
        }
        else
        {
            combo++;
            MainValue.Instance.score += (int)(2 * combo * score);
            float newProgress = Mathf.Min(barProgress + score, number - 1);
            if (barProgress + score - (int)(barProgress) >= 1)
            {
                //spawn spark effect on pill
                ParticleSystem spark = particle;
                ParticleSystem.MainModule sparkSettings = spark.main;
                sparkSettings.startColor = new ParticleSystem.MinMaxGradient(bar[(int)newProgress].baseColor);
                Instantiate(spark, 
                    new Vector3(bar[(int)newProgress].transform.position.x + bar[(int)newProgress].gameObject.GetComponent<SpriteRenderer>().bounds.size.x/2, 
                    bar[(int)newProgress].transform.position.y, 
                    bar[(int)newProgress].transform.position.z), 
                    Quaternion.identity);

            }
            barProgress = newProgress;
        }
        MainValue.Instance.combo = combo;
    }
}
