using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //The ground prefab
    public GameObject groundPrefab;

    //Reference to all ground objects
    private GameObject[] allGroundObjects;
    // Postion where the new prefab will be instatiated
    private Vector3 instantiatePos;
    // Index for the all ground GameObjects
    private int groundIndex;

    //player for Test
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize the level and intantiate the ground Objects
        allGroundObjects = new GameObject[5];
        for (int i = 0; i < 5; i++)
        {
            InitializeLevel();
        }
    }

    private void Update()
    {
        player.Translate(Vector3.forward * Time.deltaTime * 1f);

        if (player.transform.position.z > instantiatePos.z - 35)
            AddGround();
    }

    // Locate the last ground player just crossed to the front most
    void AddGround()
    {
        allGroundObjects[groundIndex].transform.position = instantiatePos;
        instantiatePos += new Vector3(0f, 0f, 10f);
        groundIndex++;
        if (groundIndex >= 5)
            groundIndex = 0;
    }

    void InitializeLevel()
    {
        GameObject obj = Instantiate(groundPrefab, instantiatePos, Quaternion.identity);
        allGroundObjects[groundIndex] = obj;
        instantiatePos += new Vector3(0f, 0f, 10f);
        groundIndex++;
        if (groundIndex >= 5)
            groundIndex = 0;
    }
}