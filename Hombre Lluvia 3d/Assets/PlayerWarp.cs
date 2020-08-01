using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWarp : MonoBehaviour
{
    public float launchForce, warpSpeed, lifeTime, stopTime;
    public WarpPoint prefabWarpoint;
    public bool onWarp;
    public bool usedWarp;
    public Vector2 launchDirection; 
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
                StartCoroutine(DestroyWarp());
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
            currentWarpPoint = Instantiate(prefabWarpoint, transform.position, transform.rotation);
            warpPointRigidbody = currentWarpPoint.GetComponent<Rigidbody>();
            Vector3 currentDirection = new Vector3(transform.forward.x * launchDirection.x, launchDirection.y + y/2);
            Debug.Log(currentDirection);
            currentWarpPoint.GetComponent<Rigidbody>().AddForce(currentDirection.normalized * launchForce,ForceMode.Impulse);
        }
        else{
            onWarp = true;
            usedWarp = true;
            transform.rotation = currentWarpPoint.transform.rotation;
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

    private IEnumerator DestroyWarp()
    {
        if(currentWarpPoint != null)
        {
            warpPointRigidbody.velocity = Vector3.zero;
            warpPointRigidbody.useGravity = false;
            yield return new WaitForSeconds(stopTime);
        }
        else
        {
            StopAllCoroutines();
        }
        if(currentWarpPoint != null)
        {
            currentWarpPoint.GetComponentInChildren<ParticleSystem>().Stop();
            yield return new WaitForSeconds(currentWarpPoint.GetComponentInChildren<ParticleSystem>().main.startLifetime.constant);
        }
        else
        {
            StopAllCoroutines();
        }
        if (currentWarpPoint != null)
        {
            Debug.Log(currentWarpPoint.GetComponentInChildren<ParticleSystem>().main.startLifetime.constant);
            destroyPoint = currentWarpPoint.transform.position;
            Destroy(currentWarpPoint.gameObject);
            currentWarpPoint = null;
            StopAllCoroutines();
        }       
    }
}
