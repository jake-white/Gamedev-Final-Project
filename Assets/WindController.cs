using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    public GameObject plane;
    public Renderer rend;
    public Collider coll;
    public bool enter = true;

    // Start is called before the first frame update
    void Start()
    {
        plane = GameObject.Find("Plane");
        rend = GetComponent<Renderer>();
        coll = GetComponent<Collider>();
        // rend.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Rigidbody planeRb = plane.GetComponent<Rigidbody>();
        planeRb.AddForce(0, 10, 0, ForceMode.Impulse);
    }
}
