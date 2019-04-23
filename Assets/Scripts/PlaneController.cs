using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaneController : MonoBehaviour
{
    public TextMeshProUGUI speedText;
    public PowerController power;
    float lift, drag;
    public int score;
    bool launched = false;
    Rigidbody body;
    

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        score = 0;
        body.isKinematic = true;
    }

    void FixedUpdate() {
        if(launched == true){            
            if(Input.GetAxis("Horizontal") > 0) {
                body.AddTorque(0,0,10);
            }
            else if(Input.GetAxis("Horizontal") < 0) {
                body.AddTorque(0,0,-10);
            }
            if(Input.GetAxis("Vertical") > 0) {
                body.AddTorque(-10,0,0);
            }
            else if(Input.GetAxis("Vertical") < 0) {
                body.AddTorque(10,0,0);
            }
        }

        float velocity = body.velocity.magnitude;
        //lift = 0.5 * (air density)(v^2)(wing area)(coefficient of lift)
        Vector3 localVelocity = transform.InverseTransformDirection(body.velocity);
        float angleOfAttack = Mathf.Atan2(-localVelocity.y, localVelocity.z);
        float lift = (0.5f * (velocity * velocity)) * angleOfAttack;
        float drag = .3f * (0.5f * (velocity * velocity));
        var dragDirection = -body.velocity.normalized;
        var liftDirection = Vector3.Cross(dragDirection, transform.right);
        Debug.DrawLine(transform.position, transform.position - transform.forward*10, Color.green);
        Debug.DrawLine(transform.position, transform.position + dragDirection*10, Color.blue);
        Debug.DrawLine(transform.position, transform.position + body.velocity, Color.red);

        //creating vectors
        Vector3 liftVector = liftDirection * lift;
        Vector3 dragVector = dragDirection * drag;
        body.AddForce(liftVector + dragVector, ForceMode.Force);
        speedText.text = "Airspeed = " + velocity + "\n Vertical Airspeed = " + body.velocity.y + "\n Score = " + score;
    }

    // Update is called once per frame
    void Update()
    {
        if(launched == false){
            if(Input.GetAxis("Vertical") > 0){
                body.transform.Rotate(.5f,0,0);
                if(body.transform.rotation.eulerAngles.x < 90 && body.transform.rotation.eulerAngles.z == 180){
                    body.transform.rotation = Quaternion.Euler(90,0,0);
                }
            }
            if(Input.GetAxis("Vertical") < 0){
                body.transform.Rotate(-.5f,0,0);
                if(body.transform.rotation.eulerAngles.x > 260 && body.transform.rotation.eulerAngles.z == 180){
                    body.transform.rotation = Quaternion.Euler(270,0,0);
                }
            }
            if(Input.GetKeyDown("space")){
                body.isKinematic = false;
                float powerValue = 40 * power.GetPower();
                body.AddRelativeForce(Vector3.back * powerValue, ForceMode.Impulse);
                launched = true;
                power.gameObject.SetActive(false);
            }
        }
    }
}
