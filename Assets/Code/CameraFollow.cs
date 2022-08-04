using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject FollowObject;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = LittleMaths.ZeroZVector(FollowObject.transform.position) + new Vector3(0,0,-10);    
    }
}
