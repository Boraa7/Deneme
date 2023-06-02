using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCROLL : MonoBehaviour
{
    float speed;


    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        speed = MasterCODE.Instance._Speedy;
        float x = (-speed/20) * Time.time;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0,x); 
        
    }
}
