using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public GameObject plane;

    // Start is called before the first frame update
    void Start()
    {
        plane = GameObject.Find("Plane");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        // Save distance from target center
        ContactPoint contact = collision.contacts[0];
        float localX = transform.position.x - contact.point.x;
        float localY = transform.position.y - contact.point.y;
        float distance = Mathf.Sqrt(Mathf.Pow(localX, 2) + Mathf.Pow(localY, 2));

        // Stop plane
        plane.GetComponent<Rigidbody>().isKinematic = true;
        
        if (distance < 1.0f) {
            plane.GetComponent<PlaneController>().score += 500;
        }
        else if (distance >= 1.0f && distance < 5.0f) {
            plane.GetComponent<PlaneController>().score += 300;
        }
        else if (distance >= 5.0f && distance < 7.0f) {
            plane.GetComponent<PlaneController>().score += 200;
        }
        else if (distance >= 7.0f && distance < 8.0f) {
            plane.GetComponent<PlaneController>().score += 100;
        }
        else {
            plane.GetComponent<PlaneController>().score += 50;
        }
    }

}
