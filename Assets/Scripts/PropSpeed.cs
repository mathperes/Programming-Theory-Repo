using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropSpeed : MonoBehaviour
{

    public GameObject propObj;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        propObj.transform.Rotate(Vector3.forward * speed);
    }
}
