using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinTest : MonoBehaviour
{
    public Transform follow;
    public float followSpeed;
    public Transform target;
    public float freq;
    private float amp;
    private float index;


    private void Start()
    {
        follow.position = transform.position;
        amp = target.GetComponent<Collider>().bounds.size.y;

    }

    private void Update()
    {
        index += Time.deltaTime;
        float sin = Mathf.Sin(index * freq) * amp;
        follow.position += (Vector3.up * (target.position.y - follow.position.y)) * followSpeed * Time.deltaTime;
        float newPosY = follow.position.y + sin;
        transform.position = new Vector3(transform.position.x, newPosY, 0);
    }
}
