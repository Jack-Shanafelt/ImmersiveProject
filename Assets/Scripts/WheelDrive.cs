using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelDrive : MonoBehaviour
{
    public float motorForce; // the force applied to the wheel
    private WheelCollider wheelCollider;

    // Start is called before the first frame update
    void Start()
    {
        wheelCollider = GetComponent<WheelCollider>();
    }

    // Update is called once per frame
    
    public void drive(){
        wheelCollider.motorTorque = motorForce;
    }
}