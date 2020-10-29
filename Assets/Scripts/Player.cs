using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    Rigidbody2D body;
    bool onGround = false;
    int score;
    [SerializeField] private Text scoreHUD;


    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerMove();
    }

    void PlayerMove(){  
        body.velocity = new Vector2(moveSpeed * Time.fixedDeltaTime * Input.GetAxisRaw("Horizontal"),
                                                body.velocity.y);
        if (Input.GetKeyDown(KeyCode.UpArrow) && onGround)
        {
            // Implementar pulo do personagem
            var newVelocity = body.velocity;
            newVelocity.y += jumpForce;
            body.velocity = newVelocity;
        }
    }

    public void SetOnGround(bool grounded){
        if (grounded){
            onGround = true;
        } else{
            onGround = false;
        }
    }

// Completar o script abaixo
    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Coin"){
            score ++;
        }
    }
    
void OnCollisionEnter2D(Collision2D col)
{
    if (col.gameObject.tag == "Ground")
    {
        SetOnGround(true);
    }
}

void OnCollisionExit2D(Collision2D col)
{
    if (col.gameObject.tag == "Ground")
    { 
        SetOnGround(false);
    } 
}

}
