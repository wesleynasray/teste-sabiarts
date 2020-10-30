using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTo : MonoBehaviour
{
    public Transform target;
    public float speed;

    private void FixedUpdate()
    {
        var position = Vector2.Lerp(transform.position, target.position, speed * Time.deltaTime);
        transform.position = new Vector3(position.x, position.y, transform.position.z);
    }
}
