using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovent : MonoBehaviour
{

    public GameObject player;

    private Vector3 offset = new Vector3(0, 1.5f, -12);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CameraFollow();
    }

    void CameraFollow()
    {
        transform.position = player.transform.position + offset;
    }

}
