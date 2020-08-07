using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWarp : MonoBehaviour
{
    public float launchForce, warpSpeed, lifeTime, stopTime, maxDistance;
    public WarpPoint prefabWarpoint;
    public bool onWarp;
    public bool usedWarp;
    public Vector2 launchDirection; 
    public LayerMask destroyers;
    public Transform spawnPoint;
    private bool stoped;
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
            if (checkCollision.Length != 0 || currentLifeTime <= 0 || Vector3.Distance(currentWarpPoint.transform.position, transform.position) > maxDistance)
            {             
                if (!currentWarpPoint.stopped)
                {
                    StartCoroutine(currentWarpPoint.DestroyWarp(stopTime));
                    destroyPoint = currentWarpPoint.transform.position;
                }
            }
            if (!onWarp){
                currentLifeTime -= Time.deltaTime;
            }
            else{
                warpPointRigidbody.velocity = Vector3.zero;
                warpPointRigidbody.useGravity = false;
            }         
            if (!currentWarpPoint.accesible)
            {
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

    public void Launch(float y){
        if (currentWarpPoint == null){
            currentLifeTime = lifeTime;
            currentWarpPoint = Instantiate(prefabWarpoint, spawnPoint.position, transform.rotation);
            warpPointRigidbody = currentWarpPoint.GetComponent<Rigidbody>();
            Vector3 currentDirection = new Vector3(transform.forward.x * launchDirection.x, launchDirection.y + y/2);
            currentWarpPoint.GetComponent<Rigidbody>().AddForce(currentDirection.normalized * launchForce,ForceMode.Impulse);
        }
        else{
            onWarp = true;
            usedWarp = true;
            transform.rotation = currentWarpPoint.transform.rotation;
            StopCoroutine(currentWarpPoint.DestroyWarp(stopTime));
        }
    }
    private void Warp(){
        if (onWarp){
            if(currentWarpPoint != null && Vector3.Distance(currentWarpPoint.transform.position, transform.position) <= .5f){               
                usedWarp = true;
                Destroy(currentWarpPoint.gameObject);
                currentWarpPoint = null;
                myRigidbody.velocity = Vector3.zero;
                onWarp = false;
            }
            if(currentWarpPoint == null && Vector3.Distance(destroyPoint, transform.position) <= .5f){
                myRigidbody.velocity = Vector3.zero;
                onWarp = false;
                usedWarp = true;
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }
}
