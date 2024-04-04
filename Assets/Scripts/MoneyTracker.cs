using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyTracker : MonoBehaviour
{
    public static float money = 0;
    private Vector3 startPoint;
    private GameObject body;
    public Text moneyText;
    public Text distanceText;
    public Transform startPointObject;

    // Start is called before the first frame update
    void Start()
    {
        body = GameObject.FindGameObjectWithTag("Body");
        startPoint = startPointObject.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseMoney()
    {
        float distance = Vector3.Distance(body.transform.position, startPoint);
        money += distance;
        moneyText.text = money.ToString();
        distanceText.text = "Distance: " + distance.ToString();
    }
}