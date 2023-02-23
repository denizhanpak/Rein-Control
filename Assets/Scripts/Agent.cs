using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public int sensorCount;
    public GameObject beak;
    public GameObject sensorModel;
    public Transform target;
    Sensor [] sensors;

    // Start is called before the first frame update
    void Start()
    {
        sensors = new Sensor [sensorCount];
        MakeSensors();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void MakeSensors()
    {
        for (int i = 0; i < sensors.Length; i++)
        {
            sensors[i] = Instantiate(sensorModel, new Vector3(0f,0.7f,0.9f),Quaternion.Euler(90f,0f,0f), transform).GetComponent<Sensor>();
            sensors[i].SetHeading(beak);
            sensors[i].SetTarget(target);
            sensors[i].SetHinge(GetComponent<Rigidbody>());
        }
    }
}
