using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class playerMove : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    public float moveSpeed = 15f;
    public AudioSource audioSourceCollecting;
    public AudioSource audioSourceGate;
    private int collectableCount = 0;
    GameObject[] enemies;
    public GameObject bulletPrefab;
    public GameObject weapon;
    private bool gameStarted = false;
    private bool isFiring = false;
    public float jumpForce;
    public float backForth, leftRight;
    NavMeshAgent agent;
    public bool live, fire;
    private float sens;
    public float jumpTime;
    public int hp;
    public GameObject FinalGate;
    public GameObject mapCamera;
    public GameObject map;
    public int coinCount = 0;

    void Start()
    {
        hp = 150;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        //Cursor.lockState = CursorLockMode.Locked;
        live = true;
        sens = 100;
        jumpTime = 0;
        FinalGate.SetActive(true);
        mapCamera.SetActive(true);
        map.SetActive(true);
    }

    void Update()
    {
        //if (isActive && Time.timeSinceLevelLoad >= 15f)
        //{
        //    mapCamera.SetActive(false);
        //    map.SetActive(false);
        //    isActive = false;
        //}

        backForth = Input.GetAxis("Vertical");
        leftRight = Input.GetAxis("Horizontal");

        fire = Input.GetKeyDown(KeyCode.Mouse0);

        if (live)
        {
            transform.Translate(leftRight * moveSpeed * Time.deltaTime, 0, backForth * moveSpeed * Time.deltaTime);
            transform.Rotate(0, Input.GetAxis("Mouse X") * sens * Time.deltaTime, 0);

            if (gameStarted)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    UseWeapon();
                    isFiring = true;
                }
            }
        }

        if (hp <= 0)
        {
            anim.SetBool("islive", false);//death animation çalýþmaz.
            GameOver();
        }

        anim.SetFloat("vertical", backForth);
        anim.SetFloat("horizontal", leftRight);
        anim.SetBool("islive", live);
        anim.SetBool("fire", fire);

        if (Input.GetKeyDown(KeyCode.Space) && jumpTime < Time.time)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpTime = Time.time + 1;
        }
    }

    public void SetGameStarted(bool value)
    {
        gameStarted = value;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("health"))
        {
            audioSourceCollecting.Play();
            Destroy(collision.gameObject);
            hp += 20;
        }

        if (collision.gameObject.CompareTag("key"))
        {
            audioSourceCollecting.Play();
            Destroy(collision.gameObject);
            collectableCount++;

            if (collectableCount >= 3)
            {
                FinalGate.SetActive(false);
                audioSourceGate.Play();
            }
        }

        if (collision.gameObject.CompareTag("coin"))
        {
            audioSourceCollecting.Play();
            Destroy(collision.gameObject);
            coinCount++;

            if (coinCount >= 3)
            {
                mapCamera.SetActive(true);
                map.SetActive(true);
                
            }
        }
    }

    private void UseWeapon()
    {
        if (isFiring)
        {
            Vector3 offset = transform.forward * 2.4f + transform.up * 4f + transform.right * 1.6f;
            Vector3 playerRotation = transform.rotation.eulerAngles;
            GameObject bullet = Instantiate(bulletPrefab, weapon.transform.position, weapon.transform.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddForce(weapon.transform.forward * 2000f);
            }

            bullet.AddComponent<bullet>();
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
