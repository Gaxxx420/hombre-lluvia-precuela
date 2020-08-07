using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPoint : MonoBehaviour
{
    public bool stopped;
    public bool accesible;
    public ParticleSystem myParticles;
    public LayerMask destroyers;
    private Rigidbody myRigidbody;
    private ParticleSystem.MainModule settings;
    private float deathAnimationTime;

    private void Awake()
    {
        accesible = true;
        stopped = false;
        myRigidbody = GetComponent<Rigidbody>();
        settings = myParticles.main;
        deathAnimationTime = settings.startLifetime.constant;
    }

    private void Update()
    {
        if(stopped && myRigidbody.velocity.magnitude != 0)
        {
            myRigidbody.velocity = Vector3.zero;
        }
    }

    public IEnumerator DestroyWarp(float stopTime)
    {
        stopped = true;
        myRigidbody.useGravity = false;
        yield return new WaitForSeconds(stopTime);
        accesible = false;
        if (myParticles != null)
        {
            myParticles.Stop();
            yield return new WaitForSeconds(deathAnimationTime);
            Destroy(gameObject);
        }              
    }

}
