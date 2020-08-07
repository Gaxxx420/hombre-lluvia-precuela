using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloorDetection : MonoBehaviour
{
    [SerializeField] private Transform groundCheck,ceilingCheck;
    [SerializeField] private Vector3 floorDetectionSize, ceilingDetectionSize;
    [SerializeField] private LayerMask walkableLayer, ceilingLayer;
    private Rigidbody myRigidbody;  
    private bool wasGrounded;
    public UnityEvent onLandEvent;
    public UnityEvent onLeaveLandEvent;
    public Collider[] myColliders;
    public int nColliders;
    public bool drop;


    private void Start(){
        myRigidbody = GetComponent<Rigidbody>();
        drop = false;
        wasGrounded = Grounded();
    }

    public bool Grounded(){
        Collider[] groundcheck = Physics.OverlapBox(groundCheck.position, floorDetectionSize / 2, Quaternion.identity, walkableLayer);
        return groundcheck.Length != 0 && myRigidbody.velocity.y <= .1f;
    }

    public bool UnderCeiling()
    {
        Collider[] ceilingcheck = Physics.OverlapBox(ceilingCheck.position, ceilingDetectionSize / 2, Quaternion.identity, ceilingLayer);
        return ceilingcheck.Length != 0 && Grounded();
    }

    private void Update(){
        Stomp(); 

        if(myRigidbody.velocity.y > 0){
            drop = false;
        }
        if(wasGrounded!= Grounded()){
            if (Grounded()){
                onLandEvent.Invoke();
            }
            else{
                onLeaveLandEvent.Invoke();
            }
            wasGrounded = Grounded();
        }
    }
    void Stomp(){
        Collider[] detection = Physics.OverlapBox(groundCheck.position-Vector3.up/4, (floorDetectionSize + Vector3.up/2)/2, Quaternion.identity, walkableLayer);
        for (int i = 0; i < detection.Length; i++){
            if (detection[i].GetComponent<IStompable>() != null){               
                foreach(Collider n in myColliders)
                {
                    detection[i].GetComponent<IStompable>().Stomped(n, drop);
                }
            }
        }
    }

    public bool OnPlatform()
    {
        Collider[] detection = Physics.OverlapBox(groundCheck.position - Vector3.up / 4, (floorDetectionSize + Vector3.up / 2) / 2, Quaternion.identity, walkableLayer);
        int n=0;
        for (int i = 0; i < detection.Length; i++)
        {
            if (detection[i].GetComponent<IStompable>() != null)
            {
                n++;
            }
        }
        if (n != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void OnDrawGizmos(){
        Gizmos.DrawWireCube(groundCheck.position, floorDetectionSize);
        Gizmos.DrawWireCube(ceilingCheck.position, ceilingDetectionSize);
        Gizmos.DrawWireCube(groundCheck.position - Vector3.up/4, floorDetectionSize + Vector3.up/2);
    }
}
