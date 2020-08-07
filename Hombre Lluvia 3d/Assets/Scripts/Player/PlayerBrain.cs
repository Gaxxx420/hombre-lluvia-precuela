using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Collider topCollider, bottomCollider;
    public Vector2 axis;
    public Cinemachine.CinemachineVirtualCamera myCamera;
    public int currentState;
    public Text displayValue;
    private enum stateNames
    {
        Movement,
        OnWallJump,
        OnDash,
        OnWarp,
        OnCrouch
       
    }
    private Dictionary<stateNames, int> myStates = new Dictionary<stateNames, int>();
    //-------------------------------------------
    public Transform body;
    private void Start(){
        myRigidbody = GetComponent<Rigidbody>();
        myFloorDetection = GetComponent<FloorDetection>();
        myInputs = GetComponent<PlayerInputs>();
        myMovement = GetComponent<PlayerMovement>();
        myWallJump = GetComponent<PlayerWallJump>();
        myDash = GetComponent<PlayerDash>();
        myVisuals = GetComponent<PlayerVisuals>();
        myWarp = GetComponent<PlayerWarp>();
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
        else if(currentState == myStates[stateNames.OnCrouch])
        {
            CrouchUpdate();
        }
    }
    private void FixedUpdate(){
        if (currentState == myStates[stateNames.Movement] || currentState == myStates[stateNames.OnCrouch])
        {
            myMovement.MovementFixedUpdate(myInputs.jumpPerformed, myInputs.jumpHeld, myInputs.verAxis);
            myInputs.jumpPerformed = false;
        }
        else if (currentState == myStates[stateNames.OnWallJump]){
            myMovement.WallJumpFixedUpdate();
        }
    }
    private void SetAxis(){
        axis = new Vector2(myInputs.horAxis, myInputs.verAxis);
    }   
    void MovementUpdate(){
        if (axis.y < -0.9f)
        {
            if (myFloorDetection.Grounded())
            {
                ToCrouch();
            }          
        }  
        if (myInputs.jumpPerformed && !myFloorDetection.Grounded() && myWallJump.onWall()){
            ToWallJump();
        }
        else{
            myMovement.MovementUpdate(myInputs.horAxis);
        }
        if (myInputs.dashPerformed){
            ToDash();
        }
        if (myInputs.warpPerformed){
            if (!myWarp.usedWarp)
            {
                myWarp.Launch(axis.y);
            }
            myInputs.warpPerformed = false;
        }
        if (myWarp.onWarp){
            ToWarp();
        }       
    }
    void WallJumpUpdate(){
        myMovement.WallJumpUpdate(myInputs.horAxis);
        if (myRigidbody.velocity.y < 0){
            SetState(myStates[stateNames.Movement]);
        }
    }
    void DashUpdate(){
        myInputs.jumpPerformed = false;
        if (!myDash.onDash){
            myDash.DashEnd();
            myRigidbody.drag = 0;
            myRigidbody.useGravity = true;         
            myVisuals.SetParticles(false, 0);
            if (!myFloorDetection.UnderCeiling())
            {
                activateColliders(true, true);
                changeSize(false);
                SetState(myStates[stateNames.Movement]);
            }
            else
            {
                ToCrouch();
                SetState(myStates[stateNames.OnCrouch]);
            }
        }
    }
    void WarpUpdate(){
        if (!myWarp.onWarp){
            if (axis.x != 0)
            {
                myMovement.fixedDirection(axis.x);
            }
            else
            {
                myMovement.fixedDirection(transform.forward.x);
            }
            myVisuals.SetParticles(false, 1);
            myVisuals.myRenderer.SetActive(true);
            activateColliders(true,true);
            SetState(myStates[stateNames.Movement]);          
        }
    }
    void CrouchUpdate()
    {
        myMovement.MovementUpdate(0);
        if ((!myFloorDetection.UnderCeiling() && axis.y >= 0) || !myFloorDetection.Grounded())
        {
            activateColliders(true, true);
            changeSize(false);
            SetState(myStates[stateNames.Movement]);
        }
        if (myInputs.dashPerformed)
        {
            ToDash();
        }
        if (myInputs.warpPerformed)
        {
            if (!myWarp.usedWarp && !myFloorDetection.UnderCeiling())
            {
                myWarp.Launch(axis.y);
            }
            myInputs.warpPerformed = false;
        }
        if (myWarp.onWarp)
        {
            body.localScale = new Vector3(1, 1.5f, 1);
            ToWarp();
        }
    }

    public void OnLand()
    {
        myMovement.OnLandMovement();
        myDash.onLandDash();
    }
    void SetState(int newState)
    {
        currentState = newState;
    }
    void activateColliders(bool top, bool bottom)
    {
        topCollider.isTrigger = !top;
        bottomCollider.isTrigger = !bottom;
    }

    void ToWarp()
    {
        activateColliders(false, false);
        myMovement.RestartAcceleration();
        SetState(myStates[stateNames.OnWarp]);
        myVisuals.SetParticles(true, 1);
        myVisuals.myRenderer.SetActive(false);
    }
    void ToDash()
    {
        if (myDash.CanDash())
        {
            activateColliders(false, true);
            changeSize(true);
            myMovement.RestartAcceleration();
            myVisuals.SetParticles(true, 0);
            myDash.DashStart();
            SetState(myStates[stateNames.OnDash]);
        }
        myInputs.dashPerformed = false;
        
    }
    void ToWallJump()
    {
        myMovement.RestartAcceleration();
        myWallJump.wallJump(transform.forward.x);
        myInputs.jumpPerformed = false;
        myMovement.fixedDirection(-transform.forward.x);
        SetState(myStates[stateNames.OnWallJump]);
    }
    void ToCrouch()
    {
        activateColliders(false, true);
        changeSize(true);
        SetState(myStates[stateNames.OnCrouch]);
    }

    void changeSize(bool shrink)
    {
        if (shrink)
        {
            body.localScale = new Vector3(1, .75f, 1);
            body.localPosition = new Vector3(0, -.75f, 0);
        }
        else
        {
            body.localScale = new Vector3(1, 1.5f, 1);
            body.localPosition = new Vector3(0, 0, 0);
        }
    }
}

