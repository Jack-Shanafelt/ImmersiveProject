using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDrive : MonoBehaviour
{
    public float speed; // the speed at which the object moves
    public float fuel = 100000f; // initial amount of fuel
    public float fuelConsumptionRate = 1f; // rate of fuel consumption
    private Rigidbody rb; // the Rigidbody component
    private bool isMoving = false; // whether the object is moving
    public WheelCollider[] wheelColliders; // the WheelColliders

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (isMoving && fuel > 0)
        {
            Drive();
        }

        if (fuel > 0)
        {
            DriveWithWheelColliders();
        }

    }

    public void Drive()
    {
        if (fuel > 0)
        {
            // Calculate the force
            Vector3 force = transform.up * speed;

            // Apply the force to the Rigidbody
            rb.AddForce(force);

            // Consume fuel
            fuel -= fuelConsumptionRate * Time.deltaTime;
        }
    }

    public void DriveWithWheelColliders()
    {
        if (fuel > 0)
        {
            // Apply the motor torque to the WheelColliders
            foreach (WheelCollider wheelCollider in wheelColliders)
            {
                wheelCollider.motorTorque = speed;
            }

            // Consume fuel
            fuel -= fuelConsumptionRate * Time.deltaTime;
        }
    }

    public void GO()
    {
        isMoving = true;
    }
}