using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform lookAt; // Commands camera to look at something
    private Vector3 offset = new Vector3(0, 0, -6.5f);
    // Use this for initialization
    //void Start () {
    private void Start()
    {

    }
    // Update is called once per frame
    //void Update () {
    //}
    private void LateUpdate() //Makes sure camera doesnt flicker
    {
        transform.position = lookAt.transform.position + offset; // Follows the object it looks at
    }

}