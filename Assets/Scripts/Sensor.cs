using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public Transform target;
    public GameObject heading;
    float maxResponse = 1;
    float k;
    float receptiveField=30;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float Sense()
    {
        Vector3 toTarget = target.position - transform.position;
        float angle = Vector3.Angle(toTarget, transform.up);
        float response = Utils.WitchesHat(angle, 0f, receptiveField, maxResponse);
        return response; // for distance scaling divide by toTarget.magnitude;
    }

    public void SetHeading(GameObject beak)
    {
        var joint = gameObject.AddComponent<HingeJoint>();
        joint.connectedBody = transform.parent.GetComponent<Rigidbody>();
    }

}
