using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Vector3Seri {

    public float x;
    public float y;
    public float z;

    public Vector3Seri(Vector3 v3)
    {
        x = v3.x;
        y = v3.y;
        z = v3.z;
    }

    public void Fill(Vector3 v3)
    {
        x = v3.x;
        y = v3.y;
        z = v3.z;
    }

    public Vector3 V3
    { get { return new Vector3(x, y, z); } }
}
