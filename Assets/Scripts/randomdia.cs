using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomdia : MonoBehaviour
{
    public GameObject coin;
    public GameObject dia;
    public GameObject armor;
    void Start()
    {
        int random = Random.Range(0, 200);
        if(random==199)
        {
            coin.SetActive(false);
            dia.SetActive(true);

        }
        if(random>=190 && random<199)
        {
            coin.SetActive(false);
            armor.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
