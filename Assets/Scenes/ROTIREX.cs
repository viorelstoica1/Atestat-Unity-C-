using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROTIREX : MonoBehaviour
{
    public Transform corp;
    public float x,y,z;
    void FixedUpdate()
    {
        corp.Rotate(x, y, z);
    }
}
