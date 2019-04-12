using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlane : MonoBehaviour
{
    public Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("TurnLeft")) {
            transform.Rotate(0, -1, 0, Space.Self);
            print(transform.rotation.eulerAngles.y);
            if (transform.rotation.eulerAngles.y <= -45) {
                transform.localRotation = Quaternion.Euler(0, -45, 0);
            }
        }

        if (Input.GetButton("TurnRight")) {
            transform.Rotate(0, 1, 0, Space.Self);
            if (transform.rotation.eulerAngles.y >= 45) {
                transform.localRotation = Quaternion.Euler(0, 45, 0);
            }
        }
    }
}
