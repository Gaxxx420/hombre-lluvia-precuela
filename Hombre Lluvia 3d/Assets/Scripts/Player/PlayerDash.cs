using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashForce;
    public float dragValue;
    public float dashDuration;
    public float dashEndForce;
    public bool onDash;
    public float dashCooldown;
    private float cooldownCounter;
    public bool onCooldown;
    public bool usedDash;
    private Rigidbody myRigidbody;
    private FloorDetection myFloorDetection;

    private void Start(){
        myRigidbody = GetComponent<Rigidbody>();
        myFloorDetection = GetComponent<FloorDetection>();
    }
    private void Update(){
        if(myFloorDetection.Grounded() && usedDash){
            usedDash = false;
        }
        if (onDash){
            Dash();
        }
        else{
            if (cooldownCounter < dashCooldown){
                cooldownCounter += Time.deltaTime;
                cooldownCounter = Mathf.Clamp(cooldownCounter, 0, dashCooldown);
            }
            else{
                onCooldown = false;
            }         
        }
    }
    public void DashStart(){
        onDash = true;
        usedDash = true;
        myRigidbody.drag = dragValue;
        myRigidbody.useGravity = false;      
        myRigidbody.velocity += transform.forward * dashForce;
        onCooldown = true;
        cooldownCounter = 0;
    }
    private void Dash(){
        myRigidbody.drag -= dragValue * (Time.deltaTime/dashDuration);
    }
    public void DashEnd(){
        onDash = false;
        myRigidbody.velocity = Vector3.zero;
        myRigidbody.AddForce(transform.forward * dashEndForce,ForceMode.Impulse);
    }
    public bool CanDash(){
        return !onCooldown && !usedDash;
    }
}
