using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" 
            && collision.GetContact(0).normal == Vector2.down)
        {
            collision.collider.attachedRigidbody.AddForce(Vector2.up * 300);
            Destroy(gameObject);
        }
    }
}
