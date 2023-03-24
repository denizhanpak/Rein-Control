using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    [SerializeField]
    public float maxK = 2f;
    float k;
    [SerializeField]
    float receptiveField=30;
    [SerializeField]
    float maxResponse = 1;
    [SerializeField]
    int senseFrequency = 3;
    [SerializeField]
    float maxPush;
    Rigidbody rb;
    Transform target;
    float response;
    float receptiveAngle;
    float sense;
    float push;
    HingeJoint joint;
    int senseCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        var spring = gameObject.GetComponent<SpringJoint>();
        spring.spring = Random.value * maxK;
        k = Random.value * maxK;
        float rand = (Random.value - 0.5f) * 2f;
        response = rand * maxResponse;
        rb = gameObject.GetComponent<Rigidbody>();
        receptiveAngle = Random.value * receptiveField;
        rand = (Random.value - 0.5f) * 2f;
        push = rand * maxPush;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        senseCount++;
        if (senseCount >= senseFrequency){
            sense = Sense();
            rb.AddForce(transform.right * sense, ForceMode.Impulse);
        }
    }

    // Assign target object
    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    //Respond to the stimulus
    public float Sense()
    {
        Vector3 toTarget = target.position - transform.position;
        float angle = Vector3.Angle(toTarget, transform.up);
        float rv = Utils.WitchesHat(angle, 0f, receptiveAngle, response);
        return rv; // for distance scaling divide by toTarget.magnitude;
    }


    //public Vector3 Move()
    //{
    //    sense 
    //}

    //Attach to the beak
    public void SetHeading(GameObject beak)
    {
        var spring = gameObject.GetComponent<SpringJoint>();
        spring.connectedBody = beak.GetComponent<Rigidbody>();
    }

    //Assign hinge around center of body
    public void SetHinge(Rigidbody body)
    {
        joint = gameObject.GetComponent<HingeJoint>();
        joint.connectedBody = body;
        joint.anchor = Vector3.up * -2f;//((0.5f + 0.7f)/2f); //Set the anchor point to the center of the body
    }

    //Help visualize spring Locations
    void OnDrawGizmosSelected()
    {
        var joints = gameObject.GetComponents<HingeJoint>();
        if (joints[0].connectedBody == null) return;
        foreach (var item in joints)
        {
        Gizmos.color = Color.blue;
        var connectedPos = item.anchor;//connectedBody.gameObject.transform.position;
        Gizmos.DrawLine(transform.position, connectedPos);
        Gizmos.DrawCube(connectedPos, new Vector3(0.1f, 0.1f, 0.1f));
        
        Gizmos.color = Color.red;
        connectedPos = item.connectedBody.gameObject.transform.position;
        Gizmos.DrawLine(transform.position, connectedPos);
        Gizmos.DrawCube(connectedPos, new Vector3(0.1f, 0.1f, 0.1f));
        }
    }
}
