using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private int damageAmount = 10;

    private void OnTriggerEnter(Collider other)
    {
        enemy enemy = other.GetComponent<enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damageAmount);

            if (enemy.GetCurrentHP() <= 0) 
            {
                Destroy(other.gameObject); 
            }
        }
    }


}
