using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Vector3 speed = Vector3.up * 300;

    private void Update()
    {
        transform.eulerAngles = transform.eulerAngles + speed * Time.deltaTime;
    }
}
