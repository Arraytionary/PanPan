using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionProcesser : MonoBehaviour
{
    //Input action
    DefaultControl inputAction;
    string debug;
    public Animator animatorRI;
    public Animator animatorRO;
    public Animator animatorLI;
    public Animator animatorLO;

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
    // Start is called before the first frame update
    void Awake()
    {
        inputAction = new DefaultControl();
        inputAction.Gameplay.rightInner.performed += ctx => HitRI();
        inputAction.Gameplay.rightOuter.performed += ctx => HitRO();
        inputAction.Gameplay.leftInner.performed += ctx => HitLI();
        inputAction.Gameplay.leftOuter.performed += ctx => HitLO();
        inputAction.Gameplay.DoubleInner.performed += ctx => HitDI();

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

    public void HitDI()
    {
        Debug.Log("success");
    }
    public void HitRI()
    {
        //animator.SetTrigger("pressed");
        PlayAnim(animatorRI);
        lastRI = Time.time;
        if (entered && note.GetComponent<Note>().type.Equals("0"))
        {
            //note.GetComponent<Note>().Decrease();
            projectile.Throw(note.transform, note);
        }
        if (entered && note.GetComponent<Note>().type.Equals("2") && Time.time - lastLI <= allowDuration)
        {
            projectile.Throw(note.transform, note);
        }
        if (entered && note.GetComponent<Note>().type.Equals("4") || entered && note.GetComponent<Note>().type.Equals("5") || entered && note.GetComponent<Note>().type.Equals("6"))
        {
            projectile.Throw(note.transform, note);
        }
        //Debug.Log("right inner");
        //if (!ctx.performed)
        //    return;
        //animator.SetBool("Pressed", false);
    }

    public void HitRO()
    {
        PlayAnim(animatorRO);
        lastRO = Time.time;
        if (entered && note.GetComponent<Note>().type.Equals("1"))
        {
            //note.GetComponent<Note>().Decrease();
            projectile.Throw(note.transform, note);
        }
        if (entered && note.GetComponent<Note>().type.Equals("3") && Time.time - lastLO <= allowDuration)
        {
            projectile.Throw(note.transform, note);
        }
        //Debug.Log("right outer");
    }

    public void HitLI()
    {
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
