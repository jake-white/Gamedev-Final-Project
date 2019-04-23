using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    public GameObject plane;
    public Collider coll;
    public bool enter = true;

    // Start is called before the first frame update
    void Start()
    {
        plane = GameObject.Find("Plane");
        coll = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Rigidbody planeRb = plane.GetComponent<Rigidbody>();
        planeRb.AddRelativeForce(0, 15, 0, ForceMode.Impulse);
    }
}
