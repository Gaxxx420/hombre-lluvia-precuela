using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWarp : MonoBehaviour
{
    public float launchForce;
    public WarpPoint prefabWarpoint;
    public float warpSpeed;
    public bool onWarp;
    public float lifeTime;
    public Vector2 launchDirection;
    public bool usedWarp;
    public LayerMask destroyers;
    private float currentLifeTime;
    private Rigidbody myRigidbody;
    private Rigidbody warpPointRigidbody;
    private WarpPoint currentWarpPoint;
    private FloorDetection myFloorDetection;
    private Vector3 destroyPoint;
    void Start(){
        myRigidbody = GetComponent<Rigidbody>();
        myFloorDetection = GetComponent<FloorDetection>();
        currentLifeTime = lifeTime;
    }
    void Update(){
        Warp();
        if (currentWarpPoint != null){
            Collider[] checkCollision = Physics.OverlapBox(currentWarpPoint.transform.position, Vector3.one,Quaternion.identity, destroyers);
            if (!onWarp){
                currentLifeTime -= Time.deltaTime;
            }
            else{
                warpPointRigidbody.velocity = Vector3.zero;
                warpPointRigidbody.useGravity = false;
            }
            if (checkCollision.Length != 0){
                destroyPoint = currentWarpPoint.transform.position;
                Destroy(currentWarpPoint.gameObject);
                currentWarpPoint = null;
            }
            if (currentLifeTime <= 0){
                destroyPoint = currentWarpPoint.transform.position;
                Destroy(currentWarpPoint.gameObject);
                currentWarpPoint = null;
            }         
        }
        if(myFloorDetection.Grounded() && usedWarp){
            usedWarp = false;
        }
    }
    private void FixedUpdate(){
        WarpMovement();
    }

    public void Launch(){
        if (currentWarpPoint == null){
            currentLifeTime = lifeTime;
            currentWarpPoint = Instantiate(prefabWarpoint, transform.position, transform.rotation);
            warpPointRigidbody = currentWarpPoint.GetComponent<Rigidbody>();
            Vector3 currentDirection = new Vector3(transform.forward.x * launchDirection.x, launchDirection.y).normalized;
            currentWarpPoint.GetComponent<Rigidbody>().AddForce(currentDirection * launchForce,ForceMode.Impulse);
        }
        else{
            onWarp = true;
            usedWarp = true;
        }
    }
    private void Warp(){
        if (onWarp){
            if(currentWarpPoint != null && Vector3.Distance(currentWarpPoint.transform.position, transform.position) <= .5f){
                transform.rotation = currentWarpPoint.transform.rotation;
                usedWarp = true;
                Destroy(currentWarpPoint.gameObject);
                currentWarpPoint = null;
                myRigidbody.velocity = Vector3.zero;
                onWarp = false;
            }
            if(currentWarpPoint == null && Vector3.Distance(destroyPoint, transform.position) <= .5f){
                myRigidbody.velocity = Vector3.zero;
                onWarp = false;
            }         
        }
    }
    void WarpMovement(){
        if (onWarp){
            if(currentWarpPoint != null){
                Vector3 direction = (currentWarpPoint.transform.position - transform.position).normalized;
                myRigidbody.velocity = direction * warpSpeed;
            }
            else{
                Vector3 direction = (destroyPoint - transform.position).normalized;
                myRigidbody.velocity = direction * warpSpeed;
            }          
        }      
    }
}
