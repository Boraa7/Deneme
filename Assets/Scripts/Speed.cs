using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    float speed;
    


    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        speed = MasterCODE.Instance._Speedy;

        transform.Translate(Vector3.back * speed * Time.deltaTime);
        if (transform.position.z <= -10)
        {
            Destroy(gameObject);
        }

    }
}
