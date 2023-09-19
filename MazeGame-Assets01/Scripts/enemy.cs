using Unity.VisualScripting;
using UnityEngine;

public class enemy : MonoBehaviour
{
    Animator anim;
   
    Collider coll;
    float speed = 5f;
    private GameObject Player;
    public int HP,damage;
    public bool range;
    public bool isenemy;
    public playerMove player;


    void Start()
    {
        HP = 100;
        damage=20;
      
        Player = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.FindObjectOfType<playerMove>();
        anim = GetComponent<Animator>();
        coll= GetComponent<Collider>();


    }
    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        

    }
    public int GetCurrentHP()
    {
        return HP;
    }


    void Update()
    {
        if (HP > 0 && Player != null && Player.activeSelf)
        {
            float distance = Vector3.Distance(transform.position, Player.transform.position);

            if (distance < 50f)
            {
                transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
            }

            anim.SetBool("range", distance < 50f);
        }
        else
        {
            
            anim.SetBool("range", false);
        }

        
        
    }

    public void applyDamage()
    {
        player.hp -= damage;

    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("isenemy", true);

            applyDamage();
        }

    }

    

}
