using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrain : MonoBehaviour
{
    private FloorDetection myFloorDetection;
    private PlayerInputs myInputs;
    private PlayerMovement myMovement;
    private PlayerWallJump myWallJump;
    private PlayerDash myDash;
    private Rigidbody myRigidbody;
    private PlayerWarp myWarp;
    private PlayerVisuals myVisuals;
    private Collider myCollider;
    private Vector2 Axis;
    public Cinemachine.CinemachineVirtualCamera myCamera;
    public int currentState;
    private enum stateNames
    {
        Movement,
        OnWallJump,
        OnDash,
        OnWarp
    }
    private Dictionary<stateNames, int> myStates = new Dictionary<stateNames, int>();
    private void Start(){
        myRigidbody = GetComponent<Rigidbody>();
        myFloorDetection = GetComponent<FloorDetection>();
        myInputs = GetComponent<PlayerInputs>();
        myMovement = GetComponent<PlayerMovement>();
        myWallJump = GetComponent<PlayerWallJump>();
        myDash = GetComponent<PlayerDash>();
        myVisuals = GetComponent<PlayerVisuals>();
        myWarp = GetComponent<PlayerWarp>();
        myCollider = GetComponent<Collider>();
        int nStates = Enum.GetValues(typeof(stateNames)).Length;
        for(int i = 0; i<nStates; i++){
            stateNames value = (stateNames)i;
            myStates[value] = i;
        }
    }
    private void Update(){
        SetAxis();
        if (currentState == myStates[stateNames.Movement]){
            MovementUpdate();
        }
        else if (currentState == myStates[stateNames.OnWallJump]){
            WallJumpUpdate();
        }
        else if(currentState == myStates[stateNames.OnDash]){
            DashUpdate();
        }
        else if(currentState == myStates[stateNames.OnWarp]){
            WarpUpdate();
        }   
    }
    private void FixedUpdate(){
        if (currentState == myStates[stateNames.Movement]){
            myMovement.MovementFixedUpdate(myInputs.jumpPerformed, myInputs.jumpHeld, myInputs.verAxis);
            myInputs.jumpPerformed = false;
        }
        else if (currentState == myStates[stateNames.OnWallJump]){
            myMovement.WallJumpFixedUpdate();
        }
    }
    private void SetAxis(){
        Axis = new Vector2(myInputs.horAxis, myInputs.verAxis);
    }
    public void OnLand(){
        myMovement.OnLandMovement();
    }
    void SetState(int newState){
        currentState = newState;
    }
    void MovementUpdate(){
        if (myInputs.jumpPerformed && !myFloorDetection.Grounded() && myWallJump.onWall()){
            myWallJump.wallJump(transform.forward.x);
            myInputs.jumpPerformed = false;
            myMovement.Flip(true);
            SetState(myStates[stateNames.OnWallJump]);
        }
        else{
            myMovement.MovementUpdate(myInputs.horAxis);
        }
        if (myInputs.dashPerformed){
            if (myDash.CanDash()){
                SetState(myStates[stateNames.OnDash]);
                myVisuals.SetParticles(true, 0);
                myDash.DashStart();
            }
            myInputs.dashPerformed = false;
        }
        if (myInputs.warpPerformed){
            if (!myWarp.usedWarp)
            {
                myWarp.Launch();
            }
            myInputs.warpPerformed = false;
        }
        if (myWarp.onWarp){
            myCollider.isTrigger = true;
            SetState(myStates[stateNames.OnWarp]);
            myVisuals.SetParticles(true, 1);
            myVisuals.myRenderer.SetActive(false);
        }
    }
    void WallJumpUpdate(){
        myMovement.WallJumpUpdate(myInputs.horAxis);
        if (myRigidbody.velocity.y < 0){
            SetState(myStates[stateNames.Movement]);
        }
    }
    void DashUpdate(){
        if (myRigidbody.drag <= 0){
            myDash.DashEnd();
            myRigidbody.drag = 0;
            myRigidbody.useGravity = true;
            SetState(myStates[stateNames.Movement]);
            myVisuals.SetParticles(false, 0);
        }
    }
    void WarpUpdate(){
        if (!myWarp.onWarp){
            myCollider.isTrigger = false;
            myVisuals.SetParticles(false, 1);
            myVisuals.myRenderer.SetActive(true);
            SetState(myStates[stateNames.Movement]);
            myMovement.direction = transform.forward.x;
        }
    }
}

