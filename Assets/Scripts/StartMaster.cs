using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMaster : MonoBehaviour
{
    float _skyboxRotation = 6f;
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * _skyboxRotation);
    }
}
