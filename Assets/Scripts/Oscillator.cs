using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{ 
    [SerializeField]
    float speed = 0.5f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Mathf.Cos(speed * (Time.time + Mathf.PI / 2)) * transform.right * 4;

    }
}
