using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim : StateMachineBehaviour
{
    public Rigidbody rb;
    void Start()
    {
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(0, -1, 0));
    }
}
