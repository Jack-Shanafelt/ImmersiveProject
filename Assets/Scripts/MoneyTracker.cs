using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyTracker : MonoBehaviour
{
    public static float money = 0;
    private Vector3 lastPosition;
    private GameObject body;
    public Text moneyText;
    public Text distanceText;
    public Transform startPointObject;

    // Start is called before the first frame update
    void Start()
    {
        body = GameObject.FindGameObjectWithTag("Body");
        lastPosition = body.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        IncreaseMoney();
        lastPosition = body.transform.position;
    }

    public void IncreaseMoney()
    {
        float distance = Vector3.Distance(body.transform.position, lastPosition);
        money += distance;
        money = Mathf.Ceil(money); // round up to the nearest whole number
        moneyText.text = money.ToString();
        distanceText.text = "Distance: " + Vector3.Distance(body.transform.position, startPointObject.position).ToString();
    }
}