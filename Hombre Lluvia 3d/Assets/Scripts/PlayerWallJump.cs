using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJump : MonoBehaviour
{
    public Transform wallCheck;
    public LayerMask WallMask;
    public float wallJumpForce;
    public Vector2 wallJumpVector;
    private Rigidbody myRigidbody;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    public bool onWall()
    {
        return Physics.OverlapBox(wallCheck.position, Vector3.one / 2, Quaternion.identity, WallMask).Length != 0;
    }

    public void wallJump(float direction)
    {
        Vector3 wallJumpdirection = new Vector3(-direction * wallJumpVector.x, wallJumpVector.y, 0).normalized;
        myRigidbody.velocity = Vector3.zero;
        myRigidbody.AddForce(wallJumpdirection * wallJumpForce, ForceMode.Impulse);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(wallCheck.position, Vector3.one);
        Gizmos.DrawLine(transform.position, transform.position + 2.5f * new Vector3(-transform.forward.x * wallJumpVector.x, wallJumpVector.y, 0).normalized);
    }
}
