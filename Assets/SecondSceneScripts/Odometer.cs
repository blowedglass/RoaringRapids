using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Odometer : MonoBehaviour
{
    public TextMeshProUGUI Distance;

    public GameObject leftHand;
    public GameObject righHand;

    float distanceTravelledL = 0;
    float distanceTravelledR = 0;

    float distanceTravelled = 0;
    Vector3 lastPosition;

    Vector3 lastPositionL;
    Vector3 lastPositionR;

    void Start()
    {

        lastPositionL = leftHand.transform.position;
        
        lastPosition = transform.position;
    }

    void Update()
    {

        distanceTravelledL += Vector3.Distance(leftHand.transform.position, lastPositionL);
        

        lastPositionL = leftHand.transform.position;
        

        print("Left hand distance: " + distanceTravelledL);

      
        Distance.text = ("Score:" + Mathf.Round(distanceTravelledL * 1f) * .1f);


       
    }

}