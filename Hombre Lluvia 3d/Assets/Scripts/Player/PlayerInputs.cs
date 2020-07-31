using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{

    private PlayerInputMap inputMap;
    public float horAxis {get; private set;}
    public float verAxis;
    public bool jumpPerformed;
    public bool jumpHeld {get; private set;}
    public bool dashPerformed;
    public bool warpPerformed;
    public Vector2 menu;
    public bool pause;

    private void Awake(){
        inputMap = new PlayerInputMap();
        pause = false;
    }
    private void OnEnable(){
        inputMap.Enable();
    }
    private void OnDisable(){
        inputMap.Disable();
    }
    void Start(){
        SetJump();
        SetDash();
        SetMenuButtons();
        setWarp();
    }    
    private void SetMenuButtons(){
        inputMap.Main.Edit.performed += _ => PauseMenu();
        inputMap.Menu.Up.performed += _ => MenuDirection(0,-1);
        inputMap.Menu.Down.performed += _ => MenuDirection(0, 1);
        inputMap.Menu.Right.performed += _ => MenuDirection(1, 0);
        inputMap.Menu.Left.performed += _ => MenuDirection(-1, 0);
    }
    private void PauseMenu(){
        pause = !pause;
    }
    private void MenuDirection(float x, float y){
        menu = new Vector2(x,y);
    }
    private void SetDash(){
        inputMap.Main.Dash.performed += _ => DashPressed();
    }
    private void DashPressed(){
        dashPerformed = true;
    }
    private void SetJump(){
        inputMap.Main.Jump.performed += _ => JumpPressed();
        inputMap.Main.Jump.canceled += _ => JumpReleased();
    }
    private void JumpPressed(){
        jumpPerformed = true;
        jumpHeld = true;
    }
    private void JumpReleased(){
        jumpHeld = false;
    }
    private void setWarp(){
        inputMap.Main.Warp.performed += _ => WarpPressed();
    }
    private void WarpPressed(){
        warpPerformed = true;
    }
    private void Update(){      
        SetMovement();
    }
    void SetMovement(){
        horAxis = inputMap.Main.HorAxis.ReadValue<float>();
        verAxis = inputMap.Main.VerAxis.ReadValue<float>();
        if (horAxis != 0){
            horAxis = horAxis > 0 ? 1 : -1;
        }
        if (verAxis != 0){
            verAxis = verAxis > 0 ? 1 : -1;
        }
    }
}
