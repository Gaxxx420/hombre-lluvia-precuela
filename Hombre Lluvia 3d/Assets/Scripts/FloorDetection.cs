using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloorDetection : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Vector3 detectionSize;
    [SerializeField] private LayerMask walkableLayer;
    private Rigidbody myRigidbody;
    private Collider myCollider;
    private bool wasGrounded;
    public UnityEvent onLandEvent;
    public UnityEvent onLeaveLandEvent;
    public int nColliders;
    public bool drop;

    private void Start(){
        myRigidbody = GetComponent<Rigidbody>();
        myCollider = GetComponent<Collider>();
        drop = false;
        wasGrounded = Grounded();
    }

    public bool Grounded(){
        Collider[] groundcheck = Physics.OverlapBox(groundCheck.position, detectionSize / 2, Quaternion.identity, walkableLayer);
        return groundcheck.Length != 0 && myRigidbody.velocity.y <= .1f;
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
        Collider[] detection = Physics.OverlapBox(groundCheck.position-Vector3.up/8, (detectionSize + Vector3.up/4)/2, Quaternion.identity, walkableLayer);
        for (int i = 0; i < detection.Length; i++){
            if (detection[i].GetComponent<IStompable>() != null){
                detection[i].GetComponent<IStompable>().Stomped(myCollider,drop);
            }
        }
    }
    private void OnDrawGizmos(){
        Gizmos.DrawWireCube(groundCheck.position, detectionSize);
        Gizmos.DrawWireCube(groundCheck.position - Vector3.up/8, detectionSize + Vector3.up/4);
    }
}
