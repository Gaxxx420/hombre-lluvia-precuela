using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
    public ParticleSystem [] myParticles;
    public GameObject myRenderer; 
    private void Start(){
       foreach(ParticleSystem current in myParticles){
            current.Stop();
       }
    }
    public void SetParticles(bool active, int index){
        if (active){
            myParticles[index].Play();
        }
        else{
            myParticles[index].Stop();
        }
    }
}
