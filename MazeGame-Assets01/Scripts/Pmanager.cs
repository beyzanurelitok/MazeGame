using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pmanager : MonoBehaviour
{
    public GameObject player;
    public Transform spawnPoint;


    private void Start()
    {
        
        player.transform.position = spawnPoint.position;

    }
}
