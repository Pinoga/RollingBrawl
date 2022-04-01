using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody rb;
    Camera c;
    public float forceScale = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        c = Camera.main;
    }

    void addVelocity(Vector3 d)
    {
        rb.velocity += d * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forceDirection = new Vector3();

        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        forceDirection += v * Vector3.ProjectOnPlane(c.transform.forward, new Vector3(0f, 1f, 0f)).normalized;
        forceDirection += h * Vector3.ProjectOnPlane(c.transform.right, new Vector3(0f, 1f, 0f)).normalized;

        addVelocity(forceDirection);

        if (forceDirection.magnitude != 0f)
        {
            print(forceDirection);
            Debug.DrawRay(transform.position, forceDirection, new Color(255f, 0f, 0f), 2*Time.deltaTime);
        } 
    }
}
