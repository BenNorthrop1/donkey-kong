using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonkeyKongManager : MonoBehaviour
{
    public Animator playerAnim;
    public GameObject barrelPrefab;
    public Transform spawnPos;

    public Rigidbody2D rb;
    BoxCollider2D dKCol;

    public LevelEnd levelEnd;

    int randomNum;


    private void Start() 
    {
        playerAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        dKCol = GetComponent<BoxCollider2D>();
        levelEnd = FindObjectOfType<LevelEnd>();
        dKCol.isTrigger = false;
        HandleAnimate();
    }

    private void Update() 
    {
        if (levelEnd.isEnd == true)
        {
            CancelInvoke(nameof(HandleAnimate));
            playerAnim.Play("DonkeyKongDeath");
            dKCol.isTrigger = true;
            rb.AddForce(Vector2.down * .5f , ForceMode2D.Impulse);
        }        
    }

    public void HandleAnimate()
    {
        
        playerAnim.Play("DonkeyKongThrow");
        Invoke(nameof(HandleAnimate), Random.Range(5 , 8));

    }
    
    public void HandleSpawn()
    {
        Instantiate(barrelPrefab, spawnPos.position, Quaternion.identity);
    }

}
