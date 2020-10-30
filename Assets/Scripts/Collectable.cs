using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public class OnCollectArgs { public Collectable collectable; public GameObject collector; }
    public static event EventHandler<OnCollectArgs> OnCollect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnCollect?.Invoke(this, new OnCollectArgs() { collectable = this, collector = collision.gameObject });
        Destroy(gameObject);
    }
}
