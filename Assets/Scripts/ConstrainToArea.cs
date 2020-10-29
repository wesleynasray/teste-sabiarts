using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrainToArea : MonoBehaviour
{
    [SerializeField] Vector2 center;
    [SerializeField] Vector2 extent;

    Rigidbody2D body;

    #region Borders
    float RightBorder
    {
        get { return center.x + extent.x * .5f; }
    }

    float LeftBorder
    {
        get { return center.x - extent.x * .5f; }
    }

    float TopBorder
    {
        get { return center.y + extent.y * .5f; }
    }

    float BottomBorder
    {
        get { return center.y - extent.y * .5f; }
    }
    #endregion

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(body != null)
        {
            var velocity = body.velocity;
            
            if (transform.position.x > RightBorder || transform.position.x < LeftBorder)
                velocity.x = 0;

            if (transform.position.y > TopBorder || transform.position.y < BottomBorder)
                velocity.y = 0;

            body.velocity = velocity;
        }

        transform.position = new Vector2()
        {
            x = Mathf.Clamp(transform.position.x, LeftBorder, RightBorder),
            y = Mathf.Clamp(transform.position.y, BottomBorder, TopBorder)
        };
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, extent);
    }
}
