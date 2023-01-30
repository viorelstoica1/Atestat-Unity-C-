using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class meniuprincipal : MonoBehaviour
{
    public void nivel1()
    {
        SceneManager.LoadScene(1);
    }
    public void nivel2()
    {
        SceneManager.LoadScene(2);
    }
    public void nivel3()
    {
        SceneManager.LoadScene(3);
    }
    public void nivel4()
    {
        SceneManager.LoadScene(4);
    }
    public void nivel5()
    {
        SceneManager.LoadScene(5);
    }
    public void Quitgame()
    {
        Debug.Log("iesire");
        Application.Quit();
    }
}
