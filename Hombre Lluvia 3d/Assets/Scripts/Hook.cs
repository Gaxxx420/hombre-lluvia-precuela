using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{

    [Range(1,20)]
    public int numberOfSegments;
    public Transform finalPos;
    public GameObject prebafPart;
    public float MovementSpeed;
    public float RotationSpeed;
    private Vector3 initalPos;
    private List<GameObject> parts = new List<GameObject>();
    void Start()
    {     
        initalPos = transform.position;
        for (int i = 0; i < numberOfSegments + 1; i++)
        {
            GameObject current = Instantiate(prebafPart);            
            parts.Add(current);
            current.transform.parent = transform;
        }
    }

    void Update()
    {
        SetPartsPosition();
    }
    private void SetPartsPosition()
    {

        if (numberOfSegments +1 != parts.Count)
        {
            Change();
        }
        for (int i = 0; i < parts.Count; i++)
        {
            float position = (1f / parts.Count * i);
            parts[i].transform.position = Vector3.Lerp(transform.position, finalPos.position, position);
        }
    }

    void Change()
    {
        float amount = Mathf.Abs(numberOfSegments + 1 - parts.Count);     
        if (numberOfSegments + 1 < parts.Count)
        {
            for (int i = 0; i < amount; i++)
            {
                GameObject current = parts[parts.Count - 1];
                parts.RemoveAt(parts.Count-1);
                Destroy(current);
            }
            Debug.Log("Removed " + amount + " segments.");
            Debug.Log("Total segments = " + parts.Count);
        }
        else
        {
            for (int i = 0; i < amount; i++)
            {
                GameObject current = Instantiate(prebafPart);
                parts.Add(current);
                current.transform.parent = transform;
            }
            Debug.Log("Added " + amount + " segments.");
            Debug.Log("Total segments = " + parts.Count);
        }
    }
}
