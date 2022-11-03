using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelMove : MonoBehaviour
{
    public float moveSpeed;
    
    public Rigidbody2D playerRigidbody;

    private void Start() 
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        Vector2 velocity = playerRigidbody.velocity;

        velocity.x = 0;
        


    }
}
