using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private Rigidbody objectRb;
    private GameManager gameManager;

    public ParticleSystem enemyExplosion;

    private float zDestroy = -10.0f;

    public float speed = 5.0f;
    public int scorePoint;

    // Start is called before the first frame update
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();        
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        objectRb.AddForce(Vector3.forward * -speed);

        if (transform.position.z < zDestroy)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ammo"))
        {
            gameManager.AudioPlay = true;
            gameManager.UpdateScore(scorePoint);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Instantiate(enemyExplosion, transform.position, enemyExplosion.transform.rotation);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Instantiate(enemyExplosion, transform.position, enemyExplosion.transform.rotation);
        }
    }
}
