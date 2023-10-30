using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class parent : MonoBehaviour
{
    [SerializeField] GameObject child;
    [SerializeField] Transform Parent;
    [SerializeField] GameObject[] body;
    [SerializeField] Transform Body;

    // Start is called before the first frame update
    void Start()
    {
        child.transform.SetParent(Parent);
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void parenting(){
        body = GameObject.FindGameObjectsWithTag("Body");
        Body = body[0].transform;
        child.transform.SetParent(Body);
    }
}
