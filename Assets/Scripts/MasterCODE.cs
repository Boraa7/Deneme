using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterCODE : MonoBehaviour
{
    public static MasterCODE Instance;

    
    public GameObject[] blocks;
    public GameObject coin;
    public GameObject[] background;
    Vector3 mid = new Vector3(0, 1, 100);
    Vector3 left = new Vector3(-4, 1, 100);
    Vector3 right = new Vector3(4, 1, 100);
    Vector3 midb = new Vector3(0, 0, 100);
    Vector3 leftb = new Vector3(-3.7f, 0, 100);
    Vector3 rightb = new Vector3(3.7f, 0, 100);
    Vector3 midup = new Vector3(0, 4, 100);
    Vector3 rightup = new Vector3(4, 4, 100);
    Vector3 leftup = new Vector3(-4, 4, 100);
    




    bool slot1, slot3;
    int randomizer, spawncounter,blockcount,bgroundcount;
    int chldrandom = 3;




    public bool spawn, _Armored, _coinpower;
    public float _CoinCount = 0f;
    public float _DiaCount = 0f;
    public float _ScoreCount = 0;
    public float acceleration = 10f;
    public float _Speedy = 15.0f;
    float blockspawncontroller = 20f;

    float zaman,zaman1 =0f;
    float Respawner;
    [SerializeField]
    private Text CoinCount;
    [SerializeField]
    private Text DiaCOunt;
    [SerializeField]
    private Text ScoreCount;

    void Awake() => Instance = this;
   



    void Start()
    {
        Application.targetFrameRate = 180;
        blockcount = blocks.Length;
        bgroundcount = background.Length;
        CoinCount.text = _CoinCount.ToString();
        DiaCOunt.text = _DiaCount.ToString();
        ScoreCount.text = _ScoreCount.ToString();
    }


    void Update()
    {
        zaman += Time.deltaTime;
        zaman1 += Time.deltaTime;
        Respawner= 4f / _Speedy;
        if(zaman > Respawner)
        {
            Spawn();
            zaman = 0;
            ScoreUpdate();
            
        }
        if (zaman1>Respawner*4)
        {
            BackgroundSpawn();
            zaman1 = 0;
        }
    } 


    public void SpeedDown()
    {
        acceleration -= 1;
        Debug.Log(acceleration);
    }
    public void SpeedUp()
    {
        acceleration += 1;
        Debug.Log(acceleration);
    }
    public void Coin()
    {
       
        _CoinCount += 1;
        CoinCount.text = _CoinCount.ToString();
    }
    public void Dia()
    {
        _DiaCount += 1;
        DiaCOunt.text = _DiaCount.ToString();
    }

 
    public void GameOver()
    {
        Debug.Log("BITTI");
    }

    public void CoinPower()
    {
        _coinpower = true;
        StartCoroutine(PowerUp());
      
    }
     IEnumerator PowerUp()
    {
        yield return new WaitForSeconds(10);
        _coinpower = false;
    }
    public void ScoreUpdate()
    {
        float ddd;
       ddd = Mathf.Lerp(_ScoreCount,_ScoreCount+_Speedy*5,Time.deltaTime*_Speedy);
        _ScoreCount = Mathf.FloorToInt(ddd);
      ScoreCount.text = _ScoreCount.ToString();


    }



    void Spawn()
    {
        Debug.Log("1");
        randomizer = Random.Range(0, 3);

        if (randomizer == 0)
        {
            if (slot3 == true)
            {
                
                if (spawncounter>=blockspawncontroller)
                {
                    MidCoinblock();

                }
                CoinMid();


            }
            else
            {
                slot1 = true;
                if (spawncounter>=blockspawncontroller)
                {
                    LeftCoinblock();

                }
                CoinLeft();

            }
        }
        if (randomizer == 1)
        {
            if (spawncounter>=blockspawncontroller)
            {
                MidCoinblock();
            }
            CoinMid();



        }

        if (randomizer == 2)
        {
            if (slot1 == true)
            {
                if (spawncounter>=blockspawncontroller)
                {
                    MidCoinblock();

                }
                CoinMid();

            }
            else
            {
                slot3 = true;
                if (spawncounter>=blockspawncontroller)
                {
                    RightCoinBlock();

                }
                CoinRight();

            }

        }

    }
   
    #region Spawn
    void CoinMid()
    {
        if (chldrandom>2)
        {
            Instantiate(coin, mid, Quaternion.identity);

        }
        if(chldrandom<=2)
        {
            Instantiate(coin, midup, Quaternion.identity);

        }
        slot1 = false;
        slot3 = false;
        int rrr = Random.Range(0, 3);
        if (rrr==0)
        {
            spawncounter += 1;
        }
        if (rrr==1)
        {
            spawncounter += 2;
        }
        if (rrr==2)
        {
            spawncounter += 3;
        }
        chldrandom = 3;

    }
    void CoinLeft()
    {
        if (chldrandom>2|| chldrandom==1)
        {
            Instantiate(coin, left, Quaternion.identity);

        }
        if(chldrandom==2 || chldrandom==0)
        {
            Instantiate(coin, leftup, Quaternion.identity);

        }
        int rrr = Random.Range(0, 3);
        if (rrr == 0)
        {
            spawncounter += 1;
        }
        if (rrr == 1)
        {
            spawncounter += 2;
        }
        if (rrr == 2)
        {
            spawncounter += 3;
        }
        chldrandom = 3;
        


    }
    void CoinRight()
    {
        if (chldrandom>=2)
        {
            Instantiate(coin, right, Quaternion.identity);

        }
        if (chldrandom<2)
        {
            Instantiate(coin, rightup, Quaternion.identity);

        }
        int rrr = Random.Range(0, 3);
        if (rrr == 0)
        {
            spawncounter += 1;
        }
        if (rrr == 1)
        {
            spawncounter += 2;
        }
        if (rrr == 2)
        {
            spawncounter += 3;
        }
        chldrandom = 3;


    }
    void BlockMid()
    {
        Instantiate(blocks[chldrandom], midb, Quaternion.identity);
        spawncounter = 0;

    }
    void BlockLeft()
    {
        if (chldrandom<=2)
        {
            Instantiate(blocks[chldrandom], midb, Quaternion.identity);

        }else
        {
            Instantiate(blocks[chldrandom], leftb, Quaternion.identity);

        }

        spawncounter = 0;


    }
    void BlockRight()
    {

        if (chldrandom<=2)
        {
            Instantiate(blocks[chldrandom], midb, Quaternion.identity);

        }else
        {
            Instantiate(blocks[chldrandom], rightb, Quaternion.identity);

        }
        spawncounter = 0;


    }
    void MidCoinblock()
    {
        int brandom = Random.Range(0, 8);
        int arandom = Random.Range(0, 2);
        chldrandom = Random.Range(0, blockcount);

        if (brandom >= 5 && chldrandom>2)
        {
            BlockRight();
            BlockLeft();
        }
        else
        {
            if (arandom == 0)
            {
                BlockRight();
            }
            if (arandom == 1)
            {
                BlockLeft();
            }
        }

    }
    void LeftCoinblock()
    {
        int brandom = Random.Range(0, 8);
        int arandom = Random.Range(0, 2);
        chldrandom = Random.Range(0, blockcount);

        if (brandom >=5 &&chldrandom>2)
        {
            BlockRight();
            BlockMid();
        }
        else
        {
            if (arandom == 0)
            {
                BlockRight();
            }
            if (arandom == 1)
            {
                BlockMid();
            }
        }

    }
    void RightCoinBlock()
    {
        int brandom = Random.Range(0, 8);
        int arandom = Random.Range(0, 2);
        chldrandom = Random.Range(0, blockcount);

        if (brandom >= 5 && chldrandom>2)
        {
            BlockMid();
            BlockLeft();
        }
        else
        {
            if (arandom == 0)
            {
                BlockMid();
            }
            if (arandom == 1)
            {
                BlockLeft();
            }
        }

    }

    


    #endregion


    void BackgroundSpawn()
    {
       int bgroundrandom = Random.Range(0, bgroundcount);
       Instantiate(background[bgroundrandom], midb, Quaternion.identity);

    }
}




