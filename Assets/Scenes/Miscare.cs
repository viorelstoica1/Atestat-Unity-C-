using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Miscare : MonoBehaviour
{
    public Rigidbody Player;
    public GameObject cubcezar;
    public Material Cezar;
    public float FortaSaritura = 1000f , suma = 0 , modif = 0.5f , FortaFata = 100f , FortaLateral = 50f , FortaVertical = 100f , fy , fx , fz;
    public Transform Cameratransform , playertransform;
    public Vector3 directieg , resetpoz;
    public int suprafata = 1 , supraftrec = 1;
    public bool oka = false , okd = false , okspace = false , oksup = true , okescape = false;
    void Start()
    {
        directieg = new Vector3(0f, -FortaVertical, 0f);
        fy = -FortaVertical;
        fx = 0;
        fz = 0;
    }
    //verificam coliziunea
    void OnCollisionEnter(Collision col)
    {
        oksup = true;
        switch (col.gameObject.name)
        {
            case "Plan1":
                {
                    Debug.Log("1");
                    suprafata = 1;
                    fy = -FortaVertical;
                    fx = 0;
                    break;
                }
            case "Plan2":
                {
                    Debug.Log("2");
                    suprafata = 2;
                    fx = -FortaVertical * 0.7f;
                    fy = -FortaVertical * 0.7f;
                    break;
                }
            case "Plan3":
                {
                    Debug.Log("3");
                    suprafata = 3;
                    fx = -FortaVertical;
                    fy = 0;
                    break;
                }
            case "Plan4":
                {
                    Debug.Log("4");
                    suprafata = 4;
                    fx = -FortaVertical * 0.7f;
                    fy = FortaVertical * 0.7f;
                    break;
                }
            case "Plan5":
                {
                    Debug.Log("5");
                    suprafata = 5;
                    fy = FortaVertical;
                    fx = 0;
                    break;
                }
            case "Plan6":
                {
                    Debug.Log("6");
                    suprafata = 6;
                    fx = FortaVertical * 0.7f;
                    fy = FortaVertical * 0.7f;
                    break;
                }
            case "Plan7":
                {
                    Debug.Log("7");
                    suprafata = 7;
                    fx = FortaVertical;
                    fy = 0;
                    break;
                }
            case "Plan8":
                {
                    Debug.Log("8");
                    suprafata = 8;
                    fx = FortaVertical * 0.7f;
                    fy = -FortaVertical * 0.7f;
                    break;
                }
            case "cubcezar":
                {
                    Player.GetComponent<MeshRenderer>().material = Cezar;
                    Debug.Log("Cezar");
                    cubcezar = GameObject.Find("cubcezar");
                    cubcezar.SetActive(false);
                    break;
                }
            default:
                {
                    Debug.Log("Obstacol");
                    suprafata = 1;
                    suma = 0;
                    fy = -FortaVertical;
                    fx = 0;
                    supraftrec = suprafata;
                    playertransform.rotation = Quaternion.Euler(playertransform.rotation.eulerAngles.x, playertransform.rotation.eulerAngles.y, 0f);
                    Cameratransform.rotation = Quaternion.Euler(Cameratransform.rotation.eulerAngles.x, Cameratransform.rotation.eulerAngles.y, 0f);
                    resetpoz.x = 1f;
                    resetpoz.y = 1f;
                    resetpoz.z = 15f;
                    playertransform.position = resetpoz;
                    break;
                }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a")||Input.GetKey("left"))
            oka = true;
        if (Input.GetKey("d")||Input.GetKey("right"))
            okd = true;
        if (Input.GetKeyDown(KeyCode.Space))
            okspace = true;
        if (Input.GetKey(KeyCode.Escape))
            okescape = true;
    }
    void FixedUpdate()
    {
        //invart corpul si camera
        if(suprafata!=supraftrec)
        {
            if((supraftrec > suprafata&&(supraftrec!=8||suprafata!=1))||(supraftrec==1&&suprafata==8))
            {
                modif = -5f;
                suma = suma - 45f;
            }
            else if(supraftrec < suprafata||supraftrec==8&&suprafata==1)
            {
                modif = 5f;
                suma = suma + 45f;
            }
        }
        if (suma!=0)
        {

            playertransform.rotation = Quaternion.Euler(playertransform.rotation.eulerAngles.x, playertransform.rotation.eulerAngles.y, playertransform.rotation.eulerAngles.z + modif);
            Cameratransform.rotation = Quaternion.Euler(Cameratransform.rotation.eulerAngles.x, Cameratransform.rotation.eulerAngles.y, Cameratransform.rotation.eulerAngles.z + 2*modif*(-1));
            suma = suma - modif;
        }
        directieg = new Vector3(fx, fy, fz);
        //Miscam Camera 
        switch (suprafata)
        {
            case 1:
                {
                    if(oka)
                    {
                        Player.AddForce(-FortaLateral, 0, 0);
                        oka = false;
                    }
                    if(okd)
                    {
                        Player.AddForce(FortaLateral, 0, 0);
                        okd = false;
                    }
                    if (okspace && oksup)
                    {
                        Player.AddForce(0, FortaSaritura, 0);
                        okspace = false;
                        oksup = false;
                    }
                    break;
                }
            case 2:
                {
                    if (oka)
                    {
                        Player.AddForce(-FortaLateral * 0.7f, FortaLateral * 0.7f, 0);
                        oka = false;
                    }
                    if (okd)
                    {
                        Player.AddForce(FortaLateral * 0.7f, -FortaLateral * 0.7f, 0);
                        okd = false;
                    }
                    if (okspace && oksup)
                    {
                        Player.AddForce(FortaSaritura * 0.7f, FortaSaritura * 0.7f, 0);
                        okspace = false;
                        oksup = false;
                    }
                    break;
                }
            case 3:
                {
                    if (oka)
                    {
                        Player.AddForce(0, FortaLateral, 0);
                        oka = false;
                    }
                    if (okd)
                    {
                        Player.AddForce(0, -FortaLateral, 0);
                        okd = false;
                    }
                    if (okspace && oksup)
                    {
                        Player.AddForce(FortaSaritura, 0, 0);
                        okspace = false;
                        oksup = false;
                    }
                    break;
                }
            case 4:
                {
                    if (oka)
                    {
                        Player.AddForce(FortaLateral * 0.7f, FortaLateral * 0.7f, 0);
                        oka = false;
                    }
                    if (okd)
                    {
                        Player.AddForce(-FortaLateral * 0.7f, -FortaLateral * 0.7f, 0);
                        okd = false;
                    }
                    if (okspace && oksup)
                    {
                        Player.AddForce(FortaSaritura * 0.7f, -FortaSaritura * 0.7f, 0);
                        okspace = false;
                        oksup = false;
                    }
                    break;
                }
            case 5:
                {
                    if (oka)
                    {
                        Player.AddForce(FortaLateral, 0, 0);
                        oka = false;
                    }
                    if (okd)
                    {
                        Player.AddForce(-FortaLateral, 0, 0);
                        okd = false;
                    }
                    if (okspace && oksup)
                    {
                        Player.AddForce(0, -FortaSaritura, 0);
                        okspace = false;
                        oksup = false;
                    }
                    break;
                }
            case 6:
                {
                    if (oka)
                    {
                        Player.AddForce(FortaLateral * 0.7f, -FortaLateral * 0.7f, 0);
                        oka = false;
                    }
                    if (okd)
                    {
                        Player.AddForce(-FortaLateral * 0.7f, FortaLateral * 0.7f, 0);
                        okd = false;
                    }
                    if (okspace && oksup)
                    {
                        Player.AddForce(-FortaSaritura * 0.7f, -FortaSaritura * 0.7f, 0);
                        okspace = false;
                        oksup = false;
                    }
                    break;
                }
            case 7:
                {
                    if (oka)
                    {
                        Player.AddForce(0, -FortaLateral, 0);
                        oka = false;
                    }
                    if (okd)
                    {
                        Player.AddForce(0, FortaLateral, 0);
                        okd = false;
                    }
                    if (okspace && oksup)
                    {
                        Player.AddForce(-FortaSaritura, 0, 0);
                        okspace = false;
                        oksup = false;
                    }
                    break;
                }
            case 8:
                {
                    if (oka)
                    {
                        Player.AddForce(-FortaLateral * 0.7f, -FortaLateral * 0.7f, 0);
                        oka = false;
                    }
                    if (okd)
                    {
                        Player.AddForce(FortaLateral * 0.7f, FortaLateral * 0.7f, 0);
                        okd = false;
                    }
                    if (okspace && oksup)
                    {
                        Player.AddForce(-FortaSaritura * 0.7f, FortaSaritura * 0.7f, 0);
                        okspace = false;
                        oksup = false;
                    }
                    break;
                }
        }
        supraftrec = suprafata;
        //Miscam playerul in fata
        Player.AddForce(0, 0, FortaFata);
        //Gravitatia
        Player.AddForce(directieg);
        //Saritura
        okspace= false;
        if(okescape==true)
        {
            okescape = false;
            SceneManager.LoadScene(0);
        }
    }
}
