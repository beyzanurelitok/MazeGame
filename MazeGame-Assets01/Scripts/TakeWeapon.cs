using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeWeapon : MonoBehaviour
{
    public Transform Player;
    public GameObject Weapon;
    public GameObject Weapon1;
    //public GameObject Weapon2;
    //public GameObject Weapon3;
    public bool dis;
    public GameObject Text;
    private playerMove playerMoveScript;

    private void Start()
    {
        playerMoveScript = Player.GetComponent<playerMove>(); 
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, Player.position) < 8)
        {
            dis = true;
            Text.SetActive(true);
        }
        else
        {
            dis = false;
            Text.SetActive(false);
        }

        if (dis ==true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                
                Weapon1.SetActive(false);
                Weapon.SetActive(true);
                Text.SetActive(false);
                playerMoveScript.SetGameStarted(true);
                

            }
            //else if (Input.GetKey(KeyCode.R))
            //{
                
            //    Weapon3.SetActive(false);
            //    Weapon2.SetActive(true);
               
            //    Text.SetActive(false);
            //    playerScript.SetGameStarted(true);
               
            //}
        }
        //else if (Input.GetKey(KeyCode.G))
        //{
        //    if (Weapon.activeSelf)
        //    {
        //        Weapon1.SetActive(true);
        //        Weapon.SetActive(false);
        //    }
        //    //else if (Weapon2.activeSelf)
        //    //{
        //    //    Weapon3.SetActive(true);
        //    //    Weapon2.SetActive(false);
        //    //}

        //    Text.SetActive(true);
        //}
    }
   
}
