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
        lastPositionR = righHand.transform.position;
        lastPosition = transform.position;
    }

    void Update()
    {

        distanceTravelledL += Vector3.Distance(leftHand.transform.position, lastPositionL);
        distanceTravelledR += Vector3.Distance(righHand.transform.position, lastPositionR);

        lastPositionL = leftHand.transform.position;
        lastPositionR = righHand.transform.position;

        print("Left hand distance: " + distanceTravelledL);
        Distance.text = ("L: " + distanceTravelledL);


        print("Right hand Distace: " + distanceTravelledR);
        print("Right hand position: " + lastPositionR);
        print("Left hand position: " + lastPositionL);
        Distance.text += ("R: " + distanceTravelledR);
    }

}