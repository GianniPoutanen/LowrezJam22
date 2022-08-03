using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToGrid : MonoBehaviour
{
    public Transform TruePosition;

    public void Update()
    {
        this.transform.position = TruePosition.position;
    }
}
