using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class ActionProcesser : MonoBehaviour
{
    //Input action
    DefaultControl inputAction;
    string debug;
    public Animator animatorRI;
    public Animator animatorRO;
    public Animator animatorLI;
    public Animator animatorLO;

    public Animator hitAccuracy;
    public GameObject hitParticle; 

    GameObject note;

    bool entered;

    bool lI;
    bool lO;
    bool rI;
    bool rO;

    //last pressed time
    float lastLI;
    float lastLO;
    float lastRI;
    float lastRO;

    public float allowDuration;

    Utility.Projectile projectile;
    public GameObject target;

    AudioSource audioSource;
    public AudioClip center;
    public AudioClip rim;

    public GameObject hitText;
    
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        inputAction = new DefaultControl();
        inputAction.Gameplay.rightInner.performed += ctx => HitRI();
        inputAction.Gameplay.rightOuter.performed += ctx => HitRO();
        inputAction.Gameplay.leftInner.performed += ctx => HitLI();
        inputAction.Gameplay.leftOuter.performed += ctx => HitLO();
        //inputAction.Gameplay.DoubleInner.performed += ctx => HitQuality(note.GetComponent<Note>().collideTime);

        lI = false;
        lO = false;
        rI = false;
        rO = false;

        projectile = new Utility.Projectile(target.transform, 1.5f);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        entered = true;
        if(collision.gameObject.layer == 9)
        {
            collision.gameObject.GetComponent<Note>().StampTime();
            note = collision.gameObject;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        entered = false;
    }

    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("hmmmmm");
    //    if (rI)
    //    {
    //        Destroy(collision.gameObject);
    //    }
    //}

    // Update is called once per frame

    public void HitQuality(float time)
    {
        //goodHit
        if (Time.time - time <= MainValue.Instance.crrSecPerBeat / 3)
        {
            hitText.GetComponent<TextMeshPro>().text = "GOOD";
            hitText.GetComponent<Animator>().SetTrigger("good");
        }
        else {
            hitText.GetComponent<TextMeshPro>().text = "OK";
            hitText.GetComponent<Animator>().SetTrigger("ok");
        }
        hitAccuracy.SetTrigger("Good");
        Instantiate(hitParticle, hitAccuracy.transform.position, Quaternion.identity);
    }

    public void ReportMiss()
    {
        hitText.GetComponent<TextMeshPro>().text = "BAD";
        hitText.GetComponent<Animator>().SetTrigger("bad");
    }
    public void HitRI()
    {

        audioSource.PlayOneShot(center);
        //animator.SetTrigger("pressed");
        PlayAnim(animatorRI);
        lastRI = Time.time;
        if (entered && note.GetComponent<Note>().type.Equals("0"))
        {
            HitQuality(note.GetComponent<Note>().collideTime);
            //note.GetComponent<Note>().Decrease();
            projectile.Throw(note.transform, note);
        }
        if (entered && note.GetComponent<Note>().type.Equals("2") && Time.time - lastLI <= allowDuration)
        {
            HitQuality(note.GetComponent<Note>().collideTime);
            projectile.Throw(note.transform, note);
        }
        if (entered && note.GetComponent<Note>().type.Equals("4") || entered && note.GetComponent<Note>().type.Equals("5") || entered && note.GetComponent<Note>().type.Equals("6"))
        {
            HitQuality(note.GetComponent<Note>().collideTime);
            projectile.Throw(note.transform, note);
        }
        //Debug.Log("right inner");
        //if (!ctx.performed)
        //    return;
        //animator.SetBool("Pressed", false);
    }

    public void HitRO()
    {

        audioSource.PlayOneShot(rim);
        PlayAnim(animatorRO);
        lastRO = Time.time;
        if (entered && note.GetComponent<Note>().type.Equals("1"))
        {
            //note.GetComponent<Note>().Decrease();
            HitQuality(note.GetComponent<Note>().collideTime);
            projectile.Throw(note.transform, note);
        }
        if (entered && note.GetComponent<Note>().type.Equals("3") && Time.time - lastLO <= allowDuration)
        {
            HitQuality(note.GetComponent<Note>().collideTime);
            projectile.Throw(note.transform, note);
        }
        //Debug.Log("right outer");
    }

    public void HitLI()
    {
  
        audioSource.PlayOneShot(center);
        PlayAnim(animatorLI);
        lastLI = Time.time;
        if (entered && note.GetComponent<Note>().type.Equals("0"))
        {
            //note.GetComponent<Note>().Decrease();
            projectile.Throw(note.transform, note);
        }
        if (entered && note.GetComponent<Note>().type.Equals("2") && Time.time - lastRI <= allowDuration)
        {
            projectile.Throw(note.transform, note);
        }
        //Debug.Log("left inner");
    }

    public void HitLO()
    {

        audioSource.PlayOneShot(rim);
        PlayAnim(animatorLO);
        lastLO = Time.time;
        if (entered && note.GetComponent<Note>().type.Equals("1"))
        {
            //note.GetComponent<Note>().Decrease();
            projectile.Throw(note.transform, note);
        }
        if (entered && note.GetComponent<Note>().type.Equals("3") && Time.time - lastRO <= allowDuration)
        {
            projectile.Throw(note.transform, note);
        }
        //Debug.Log("left outer");
    }

    private void PlayAnim(Animator anim)
    {
        anim.SetTrigger("Hitted");
    }

    IEnumerator Trigger(bool position)
    {
        position = true;
        yield return new WaitForSeconds(0.2f);
        position = false;
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
