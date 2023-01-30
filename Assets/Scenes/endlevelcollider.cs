using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endlevelcollider : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        SceneManager.LoadScene(0);
    }
}
