using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCommand : MonoBehaviour
{
    float _Speedy = 15.0f;
    
    
    public void Update()
    {
        transform.Translate(Vector3.back * _Speedy * Time.deltaTime);
    
    }
   
}
