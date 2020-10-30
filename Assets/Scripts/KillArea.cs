using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillArea : MonoBehaviour
{
    public static event EventHandler OnKill;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnKill?.Invoke(this, null);
    }
}
