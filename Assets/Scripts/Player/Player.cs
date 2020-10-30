using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    Rigidbody2D body;
    bool onGround = false;
    
    int score;
    [SerializeField] private Text scoreHUD;

    Vector2 moveInput;

    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(
            moveInput.x * moveSpeed * Time.fixedDeltaTime,
            body.velocity.y
        );
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump()
    {
        if (onGround)
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
            scoreHUD.text = "Score: " + score.ToString();
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
