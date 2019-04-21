using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : MonoBehaviour
{
    public GameObject plane;
    public bool planeHit;

    // Start is called before the first frame update
    void Start()
    {
        plane = GameObject.Find("Plane");
        planeHit = false;
    }

    void FixedUpdate()
    {
        if (planeHit) {
            transform.localScale -= new Vector3(20, 20, 10);
            if (transform.localScale.x == 0) {
                Destroy(this);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        planeHit = true;
        plane.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -75), ForceMode.Impulse);
        plane.GetComponent<PlaneController>().score += 200;
    }
}
