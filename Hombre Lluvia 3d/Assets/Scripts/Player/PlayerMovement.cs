using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed, accelerationTime, airAccelerationTime;
    [SerializeField] private float jumpForce, fallMultiplier, fallPriority, maxFallSpeed;
    public float accelerationIndex;
    public float direction;
    private Collider myCollider;
    private Rigidbody myRigidbody;
    private FloorDetection myFloorDetection;
    private bool wasFacingRight;

    private void Start(){
        myFloorDetection = GetComponent<FloorDetection>();
        myRigidbody = GetComponent<Rigidbody>();
        myCollider = GetComponent<Collider>();
        accelerationTime = Mathf.Pow(accelerationTime, -1);
        airAccelerationTime = Mathf.Pow(airAccelerationTime, -1);
        direction = 1;
        Flip();
    }

    public void MovementUpdate(float horAxis){

        if (horAxis != 0)
        {
            direction = horAxis;
        }
        Acceleration(horAxis);
        if (wasFacingRight != FacingRight())
        {
            Flip();
        }
    }
    public void WallJumpUpdate(float horAxis)
    {
        direction = transform.forward.x;
        accelerationIndex = Math.Abs(myRigidbody.velocity.x)/movementSpeed;
    }
    public void WallJumpFixedUpdate()
    {
        SetGravity(false);
        float hormove = (accelerationIndex * direction * movementSpeed);
        myRigidbody.velocity = Vector3.Lerp(myRigidbody.velocity, new Vector3(hormove, myRigidbody.velocity.y, 0), .5f * Time.deltaTime);
    }
    public void MovementFixedUpdate(bool jumpPerformed, bool jumpHeld, float verAxis){
        Movement();
        Jump(jumpPerformed, verAxis);
        SetGravity(jumpHeld);
    }
    private void Acceleration(float horAxis){
        bool moveInput = horAxis != 0;
        if (myFloorDetection.Grounded())
        {
            accelerationIndex += (moveInput ? accelerationTime : -accelerationTime) * Time.deltaTime;
        }
        else
        {
            accelerationIndex += (moveInput ? airAccelerationTime : -airAccelerationTime) * Time.deltaTime;
        }
        
        accelerationIndex = Mathf.Clamp(accelerationIndex, 0, 1); 
    }
    public void Flip(){
        accelerationIndex = 0f;
        transform.rotation = Quaternion.Euler(0, 90 * direction, 0);
        wasFacingRight = FacingRight();
    }
    private void Movement(){
        if (accelerationIndex != 0){
            float hormove = (accelerationIndex * direction * movementSpeed);
            myRigidbody.velocity = new Vector3(hormove, myRigidbody.velocity.y, 0);            
        }
        if (myFloorDetection.Grounded() && accelerationIndex == 0)
        {
            myRigidbody.velocity = new Vector3(0,myRigidbody.velocity.y,0);
        }
    }
    private void Jump(bool jumpPerformed, float verAxis){
        if (jumpPerformed){
            if (verAxis < 0){
                myFloorDetection.drop = true;
            }
            else{
                if (myFloorDetection.Grounded()){
                    myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, 0, 0);
                    myRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                }
            }
        }
    }
    private void SetGravity(bool jumpHeld){
        if (!myFloorDetection.Grounded()){
            if (myRigidbody.velocity.y < fallPriority){
                myRigidbody.AddForce(Physics.gravity * fallMultiplier);
            }
            else if (myRigidbody.velocity.y > fallPriority && !jumpHeld){
                myRigidbody.AddForce(Physics.gravity * fallMultiplier * 2);
            }
        }
        if(myRigidbody.velocity.y < -maxFallSpeed)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, -maxFallSpeed);
        }
    }
    public void OnLandMovement(){
        myFloorDetection.drop = false;
        myRigidbody.velocity = new Vector3(0, myRigidbody.velocity.y, 0);
    }
    private bool FacingRight(){
        return direction > 0;
    }    

    public void fixedDirection(float desiredDirection){
        direction = desiredDirection;
        transform.rotation = Quaternion.Euler(0, 90 * direction, 0);
        wasFacingRight = FacingRight();
    }

    public void RestartAcceleration()
    {
        accelerationIndex = 0;
    }
}
