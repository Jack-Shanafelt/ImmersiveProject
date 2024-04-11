using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parent : MonoBehaviour
{
    [SerializeField] GameObject child;
    [SerializeField] Transform Parent;
    [SerializeField] GameObject[] body;
    [SerializeField] Transform Body;
    private WheelCollider wheelCollider; // Reference to the WheelCollider
    private CapsuleCollider capsuleCollider; // Reference to the CapsuleCollider

    [SerializeField] Collider triggerArea; // the trigger area

    // Start is called before the first frame update
    void Start()
    {
        child.transform.SetParent(Parent);
        wheelCollider = GetComponent<WheelCollider>(); // Get the WheelCollider component
        capsuleCollider = GetComponent<CapsuleCollider>(); // Get the CapsuleCollider component


    }

    // This method is called when a collider enters the trigger area
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Body"))
        {
            Body = other.transform;
        }
    }

    // This method is called when a collider exits the trigger area
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Body"))
        {
            Body = null;
        }
    }

    public void parenting()
    {
        if (Body != null)
        {
            child.transform.SetParent(Body);
        }
    }

    public void Wheel()
    {
        wheelCollider.enabled = true; // Enable the WheelCollider
        capsuleCollider.enabled = false; // Disable the CapsuleCollider
    }
}