using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour, IStompable
{
    public Collider myCollider;
    private int numberOfColliders;
    List<Collider> outterDetection = new List<Collider>();
    void Start(){
        myCollider = GetComponent<Collider>();       
    }
    private void Update(){
        Collider[] detection = Physics.OverlapBox(myCollider.bounds.center, (myCollider.bounds.size + new Vector3(1,2,1))/2);
        if(numberOfColliders != detection.Length){
            for(int i = 0; i<detection.Length; i++){
                Physics.IgnoreCollision(myCollider, detection[i], true);
            }
            numberOfColliders = detection.Length;
        }   
    }
    public void Stomped(Collider stomper, bool drop){
        Physics.IgnoreCollision(myCollider, stomper, drop);
    }
    private void OnCollisionExit(Collision collision){
        Physics.IgnoreCollision(myCollider, collision.collider, true);
    }
    private void OnDrawGizmos(){
        Gizmos.DrawWireCube(myCollider.bounds.center, myCollider.bounds.size + new Vector3(1, 2, 1));
    }
}
