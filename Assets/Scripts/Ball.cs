using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D selfRigidBody;
    void Start()
    {
        selfRigidBody = GetComponent<Rigidbody2D>();
    }

    void OnBecameInvisible()
    {
        if(GameManager.Instance)
            GameManager.Instance.CheckBalls();
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bounds")
        {
            selfRigidBody.AddForce(new Vector2(0,-1));
        }
    }
}
