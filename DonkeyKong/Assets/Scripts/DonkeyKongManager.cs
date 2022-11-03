using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonkeyKongManager : MonoBehaviour
{
    public Animator playerAnim;

    public GameObject barrelPrefab;
    public Transform spawnPos;

    private void Start() 
    {
        playerAnim = GetComponent<Animator>();
    }

    private void Update() 
    {
       int throwChance = Random.Range(0, 6);

        Debug.Log(throwChance.ToString());

        if(throwChance == 5)
        {
            playerAnim.Play("DonkeyKongThrow");
        }
    }

    public void spawn()
    {
        var projectile = Instantiate(barrelPrefab, spawnPos);


    }


}
