using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNameLookCam : MonoBehaviour
{
    GameObject CurrentCamera;
    
    void Start()
    {
        CurrentCamera = GameObject.FindGameObjectWithTag("MainCamera");
    } 

    void Update()
    {
        transform.rotation = CurrentCamera.transform.rotation;
    }
}
