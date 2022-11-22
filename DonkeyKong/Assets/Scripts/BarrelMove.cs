using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelMove : MonoBehaviour
{
    public float moveSpeed;
    
    public Rigidbody2D barrelRigidbody;
    
    public LevelEnd levelEnd;


    private void Start() 
    {
        barrelRigidbody = GetComponent<Rigidbody2D>();
        levelEnd = FindObjectOfType<LevelEnd>();
    }

    private void Update() 
    {
        if(levelEnd.isEnd == true)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            barrelRigidbody.AddForce(collision.transform.right * moveSpeed, ForceMode2D.Impulse);
        }
    }
    }
    

