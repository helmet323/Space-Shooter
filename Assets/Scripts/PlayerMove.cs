using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private float moveSpeed;
    public Rigidbody2D rb;

    // public Animator playerMovement;

    public Vector2 movement;

    void Update()
    {

        moveSpeed = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerStats>().playerSpeed;
        //movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
        // playerMovement.SetFloat("Horizontal", Mathf.Abs(movement.x));
        // playerMovement.SetFloat("Vertical", movement.y);

        if (movement.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (movement.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    
}
