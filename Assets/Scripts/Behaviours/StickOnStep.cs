using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickOnStep : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.GetContact(0).normal == Vector2.down)
            collision.collider.transform.parent = transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.collider.transform.parent = null;
    }
}
