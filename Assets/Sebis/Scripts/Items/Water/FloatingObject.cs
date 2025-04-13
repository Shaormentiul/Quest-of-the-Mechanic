using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public Transform water;
    public float buoyancyForce = 10f;
    public float damping = 2f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.layer == 4)
            water = col.gameObject.transform;
    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.layer == 4)
            water = null;
    }

    void FixedUpdate()
    {
        if (water == null) return;

        float waterLevel = water.position.y + water.localScale.y / 1.3f;

        float objectHeight = transform.position.y;

        float depth = waterLevel - objectHeight;

        if (depth > 0)
        {
            float force = buoyancyForce * depth;
            rb.AddForce(Vector3.up * force - rb.velocity * damping, ForceMode.Acceleration);
        }
    }
}