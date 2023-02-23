using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public int sensorCount;
    public GameObject beak;
    public GameObject sensorModel;
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
            sensors[i] = new Sensor();
            sensors[i].SetHeading(beak);
        }
    }
}
