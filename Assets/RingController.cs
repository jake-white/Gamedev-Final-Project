using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : MonoBehaviour
{
    public GameObject plane;
    public Collider coll;
    public bool planeHit;

    // Start is called before the first frame update
    void Start()
    {
        plane = GameObject.Find("Plane");
        coll = GetComponent<Collider>();
        planeHit = false;
        // rend.enabled = false;
    }

    // Update is called once per frame
    void Update()
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
        Debug.Log("test");
    }
}
