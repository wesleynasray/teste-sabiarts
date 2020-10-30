using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMove : MonoBehaviour
{
    public Transform[] points = { };
    
    [SerializeField] float speed = 1;
    
    int currentPointIndex;

    private void Update()
    {
        if (points.Length == 0)
            return;

        transform.position = Vector3.MoveTowards(transform.position, points[currentPointIndex].position, speed * Time.deltaTime);

        if (transform.position == points[currentPointIndex].position)
            currentPointIndex = (currentPointIndex + 1) % points.Length;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        for (int i = 0; i < points.Length; i++)
        {
            Gizmos.DrawWireSphere(points[i].position, .25f);

            if (i > 0)
                Gizmos.DrawLine(points[i].position, points[i - 1].position);
        }
    }
}
