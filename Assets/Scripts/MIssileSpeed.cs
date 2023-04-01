using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIssileSpeed : MonoBehaviour
{

    private Rigidbody missileRb;

    private float speed = 40;
    private float zBound = 20;

    // Start is called before the first frame update
    void Start()
    {
        missileRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (transform.position.z > zBound)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        missileRb.AddForce(Vector3.forward * speed);
    }
}
