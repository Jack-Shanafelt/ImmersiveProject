using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parent : MonoBehaviour
{
    [SerializeField] GameObject child;
    [SerializeField] Transform Parent;
    [SerializeField] GameObject[] body;
    [SerializeField] Transform Body;
    [SerializeField] Collider triggerArea; // the trigger area

    // Start is called before the first frame update
    void Start()
    {
        child.transform.SetParent(Parent);
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
}