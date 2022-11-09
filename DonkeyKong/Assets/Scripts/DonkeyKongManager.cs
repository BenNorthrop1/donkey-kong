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
        spawn();
    }


    public void spawn()
    {
        playerAnim.Play("DonkeyKongThrow");
        Instantiate(barrelPrefab, transform.position, Quaternion.identity);
        Invoke(nameof(spawn), Random.Range(2f, 20f));
    }


}
