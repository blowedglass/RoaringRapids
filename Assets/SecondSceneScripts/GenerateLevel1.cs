using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel1 : MonoBehaviour
{
    public GameObject[] section;
    public float zPos = 120f;
    public bool creatingSection = false;
    public int secNum;

    // Update is called once per frame
    void Update()
    {
        if(creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection()
    {
        secNum = Random.Range(0, 3);
        Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 90f;
        yield return new WaitForSeconds(1);
        creatingSection = false;

    }
}
