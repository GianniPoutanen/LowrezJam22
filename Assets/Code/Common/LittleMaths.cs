using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleMaths
{
    public static Vector3 ZeroZVector(Vector3 vector)
    {
        return new Vector3(vector.x, vector.y, 0);
    }

    public static Vector3 AngleToVector(float angle)
    {
        return new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), Mathf.Cos(Mathf.Deg2Rad * angle)).normalized;
    }
}
