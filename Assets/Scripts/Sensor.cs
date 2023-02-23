using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    [SerializeField]
    public float maxK = 10f;
    [SerializeField]
    float receptiveField=10;
    [SerializeField]
    float maxResponse = 10;
    Rigidbody rb;
    Transform target;
    float response;
    float receptiveAngle;


    // Start is called before the first frame update
    void Start()
    {
        var spring = gameObject.GetComponent<SpringJoint>();
        spring.spring = Random.value * maxK;
        response = (Random.value - 0.5f) * maxResponse * 2;
        rb = gameObject.GetComponent<Rigidbody>();
        receptiveAngle = Random.value * 180f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        rb.AddForce(Sense() * response * transform.right);
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public float Sense()
    {
        Vector3 toTarget = target.position - transform.position;
        float angle = Vector3.Angle(toTarget, transform.up);
        float response = Utils.WitchesHat(angle, receptiveAngle, receptiveField, maxResponse);
        return response; // for distance scaling divide by toTarget.magnitude;
    }

    public void SetHeading(GameObject beak)
    {
        var spring = gameObject.GetComponent<SpringJoint>();
        spring.connectedBody = beak.GetComponent<Rigidbody>();
    }

    public void SetHinge(Rigidbody body)
    {
        var joint = gameObject.GetComponent<HingeJoint>();
        joint.connectedBody = body;
        joint.anchor = Vector3.forward  + Vector3.up * 0.7f; //Set the anchor point to the center of the body
    }

}
