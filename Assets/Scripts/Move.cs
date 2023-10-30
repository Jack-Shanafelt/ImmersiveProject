using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] Transform object1;
    [SerializeField] Rigidbody object1k;
    [SerializeField] Transform object2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void move()
    {
        object1k.isKinematic = false;
        object1.transform.position = object2.transform.position + new Vector3(0, 0, 0);
    }
}
