using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    private GameManager gameManager;

    public GameObject missileFire;
    public GameObject mainRotor;
    public GameObject altRotor;
    public Transform missileSpawnPoint;
    public ParticleSystem deathExplosion;
    public ParticleSystem fireParticle;

    private float rotorSpeed = 20;

    private float zBound = 7.5f;

    private float moveSpeed = 200;
    private float horizontalInput;
    private float verticalInput;
    private float atkCooldown = 1.0f;

    private bool gameOver = false;
    private bool canAttack = true;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        //GamePlay();
        if (!gameOver)
        {
            PlayerAttack();
        }

        PlayerConstrains();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!gameOver)
        {
            PlayerMovement();
            RotorForce();
        }
    }

    void GamePlay()
    {
        if (gameManager.Health <= 0)
        {
            Debug.Log("GAME OVER!!");
            GameOver();
            
        }
    }

    void PlayerMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.right * moveSpeed * horizontalInput);
        playerRb.AddForce(Vector3.forward * moveSpeed * verticalInput);
    }

    void PlayerAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canAttack)
        {
            Instantiate(missileFire, missileSpawnPoint.position, missileFire.transform.rotation);
            canAttack = false;
            StartCoroutine(attackCooldown());
        }
    }

    IEnumerator attackCooldown()
    {
        yield return new WaitForSeconds(atkCooldown);
        canAttack = true;
    }

    void PlayerConstrains()
    {
        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }

        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
    }

    void RotorForce()
    {
        mainRotor.transform.Rotate(Vector3.up * rotorSpeed);
        altRotor.transform.Rotate(Vector3.right * rotorSpeed);
    }

    void GameOver()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {       
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameManager.UpdateHealth(1);
            Debug.Log("Player collider with enemy");

            if (true)
            {
                if (gameManager.Health <= 0)
                {
                    Debug.Log("GAME OVER!!");
                    GameOver();
                    deathExplosion.Play();
                    fireParticle.Play();
                    gameOver = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Debug.Log("Power UP!");
            if (gameManager.Health < 3)
            {
                gameManager.UpdateHealth(-1);
            }            
            Destroy(other.gameObject);
        }
    }
}
