using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public float yDistance = 10;
    public float minSpread = 5;
    public float maxSpread = 10;

    //
    //public Transform playerTransform;
   // public Transform[] obstaclePrefab;

    //float ySpread;
   // float lastYPos;

    void Start()
    {
        //lastYPos = Mathf.NegativeInfinity;
        //ySpread = Random.Range(minSpread, maxSpread);
    }

    void Update()
    {
        //if (playerTransform.position.y - lastYPos >= ySpread)
       // {
       //     float lanePos = Random.Range(0, 3);
       //     lanePos = (lanePos - 1) * 1.5f;
       //     obstaclePrefab = Random.Range(0, array.Length);
       //     Instantiate(obstaclePrefab, new Vector3(lanePos, playerTransform.position.y + yDistance, 0), Quaternion.identity);
       //
       //     lastYPos = playerTransform.position.y;
      //      ySpread = Random.Range(minSpread, maxSpread);
       // }
    }
}
