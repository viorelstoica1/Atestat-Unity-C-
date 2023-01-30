using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotire : MonoBehaviour
{
    public Transform corp;
    public float rotirex,rotirey,rotirez;
    void FixedUpdate()
    {
        corp.rotation = Quaternion.Euler(corp.rotation.eulerAngles.x + rotirex, corp.rotation.eulerAngles.y + rotirey, corp.rotation.eulerAngles.z + rotirez);
    }
}
