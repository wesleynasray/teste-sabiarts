using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public Player player;

    void Start(){
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.gameObject.GetComponent<Collider2D>());
    }

    void FixedUpdate(){
        transform.position = new Vector2(player.gameObject.transform.position.x, player.gameObject.transform.position.y);
    }
    
    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Ground"){
            player.SetOnGround(true);
        }
    }
    
    void OnTriggerExit2D(Collider2D col){
        if (col.gameObject.tag == "Ground"){
            player.SetOnGround(false);
        }
    }

}

// Encontrar o que está faltando neste script
