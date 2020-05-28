using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour
{
    public class Projectile
    {

        public Transform target;
        public Transform throwingPoint;
        public GameObject obj;
        public float timeTilHit;

        public Projectile(Transform tar, float time)
        {
            target = tar;
            timeTilHit = time;
        }
        public void Throw(Transform thr, GameObject ob)
        {
            throwingPoint = thr;
            obj = ob;

            float xDis = target.position.x - throwingPoint.position.x;
            float yDis = target.position.y - throwingPoint.position.y;
            float throwAngle = Mathf.Atan((yDis + 4.905f) / xDis);

            float totalV = xDis / Mathf.Cos(throwAngle);
            float xV = totalV * Mathf.Cos(throwAngle);
            float yV = totalV * Mathf.Sin(throwAngle);

            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            rb.gravityScale = 1f;
            rb.velocity = new Vector2(xV, yV);
        }
    }
}
