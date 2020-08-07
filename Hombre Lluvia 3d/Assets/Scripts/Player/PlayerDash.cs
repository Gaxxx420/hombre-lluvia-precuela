using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float groundDashForce, airDashforce, dashGroundDuration, dashAirDuration;
    public float dragValue;
    public float dashEndForce;
    public bool onDash;
    public float dashCooldown;
    private float cooldownCounter;
    public bool onCooldown;
    public bool usedDash;
    private Rigidbody myRigidbody;
    private FloorDetection myFloorDetection;
    private float yIndex, xIndex, currentDashforce, dashDuration;
    private Vector3 momentum;
    //-----------------------------------------
    public Transform cylinder;
    private float rotationIndex;

    private void Start() {
        myRigidbody = GetComponent<Rigidbody>();
        myFloorDetection = GetComponent<FloorDetection>();
    }
    private void Update() {
        if (myFloorDetection.Grounded() && usedDash) {
            usedDash = false;
        }
        if (onDash) {
            Dash();
        }
        else {
            if (cooldownCounter < dashCooldown) {
                cooldownCounter += Time.deltaTime;
                cooldownCounter = Mathf.Clamp(cooldownCounter, 0, dashCooldown);
            }
            else {
                onCooldown = false;
            }
        }
    }
    public void DashStart() {
        momentum = myRigidbody.velocity;
        onDash = true;
        usedDash = true;
        myRigidbody.velocity = Vector3.zero;
        myRigidbody.drag = dragValue;
        onCooldown = true;
        cooldownCounter = 0;
        yIndex = 0;
        xIndex = 1;
    }
    private void Dash() {
        if (!myFloorDetection.Grounded())
        {
            yIndex += Time.deltaTime / dashDuration;
            yIndex = Mathf.Clamp(yIndex, 0, 1);
            xIndex -= Time.deltaTime / dashDuration;
            xIndex = Mathf.Clamp(xIndex, .5f, 1);
            currentDashforce = airDashforce;
            dashDuration = dashAirDuration;
        }
        else
        {
            xIndex = 1;
            yIndex = 1f;
            currentDashforce = groundDashForce;
            dashDuration = dashGroundDuration;
        }

        myRigidbody.drag -= dragValue * (Time.deltaTime / dashDuration);
        Vector3 dashVelocity = new Vector3(transform.forward.x * xIndex, -yIndex, 0).normalized * currentDashforce;
        float finalVelocityY = Mathf.Clamp(dashVelocity.y + momentum.y, -1000, 0);
        myRigidbody.velocity = new Vector3(dashVelocity.x, finalVelocityY,0);
        rotationIndex += 360 * Time.deltaTime / dashDuration;
        cylinder.transform.localRotation = Quaternion.Euler(rotationIndex, 0, 0);
        if(myRigidbody.drag <= 0)
        {
            DashEnd();
        }
    }
    public void DashEnd() {
        if (!myFloorDetection.UnderCeiling())
        {
            onDash = false;
            cylinder.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            Prolongue();
        }
    }
    public bool CanDash() {
        return !onCooldown && !usedDash;
    }

    public void onLandDash()
    {
        if (onDash)
        {
            myRigidbody.drag++;
        }
    }

    void Prolongue()
    {
        myRigidbody.drag++;
    }
}
