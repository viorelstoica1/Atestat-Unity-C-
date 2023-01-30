using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usa : MonoBehaviour
{
    public Transform usa;
    public int ok=0;
    public float viteza;
    void OnTriggerEnter()
    {
        ok = 1;
        Debug.Log("Usa");
    }
    void FixedUpdate()
    {
        if(ok==1)
        {
            usa.position = usa.position + new Vector3(0f, viteza, 0f);
        }
    }
}
