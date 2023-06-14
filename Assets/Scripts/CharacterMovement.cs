using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public enum SIDE { Left, Mid, Right }

public class Character : MonoBehaviour
{
    public GameObject Master;
    public SIDE m_Side = SIDE.Mid;
    float NewXPos = 0f;
    [HideInInspector]
    public bool SwipeLeft, SwipeRight, SwipeUp;
    public float XValue;
    private CharacterController m_char;
    private Animator m_Animator;
    private float asd;
    public float SpeedDodge;
    public float JumpPower = 7f;
    private float qwe;
    public bool InJump;
    public float DownSpeed;
    public float FwdSpeed = 7f;
    public GameObject _Dog;
    public GameObject _DogRarm;
    public GameObject _DogLarm;
    public GameObject _DogHead;
    public GameObject _ArmorSuit;
    public GameObject _ArmorLarm;
    public GameObject _ArmorRarm;
    public GameObject _Duck;
    public GameObject _DuckRarm;
    public GameObject _DuckLarm;
    public GameObject _DuckHead;
    public GameObject _Bear;
    public GameObject _BearRarm;
    public GameObject _BearLarm;
    public GameObject _BearHead;
    public bool duckskin, bearskin;
    public bool dogskin = true;
    public Animation run;
   
    void Start()
    {
        m_char = GetComponent<CharacterController>();
        m_Animator = GetComponent<Animator>();
        transform.position = Vector3.zero;
    }
    void Update()
    {

        
        SwipeLeft = Input.GetKeyDown(KeyCode.A);
        SwipeRight = Input.GetKeyDown(KeyCode.D);
        
        SwipeUp = Input.GetKeyDown(KeyCode.Space);

        if (SwipeLeft)
        {
            if (m_Side == SIDE.Mid)
            {
                NewXPos = -XValue;
                m_Side = SIDE.Left;
                m_Animator.Play("LEFT_DASH");
            }
            else if (m_Side == SIDE.Right)
            {
                NewXPos = 0;
                m_Side = SIDE.Mid;
                m_Animator.Play("LEFT_DASH");
            }
        }
        else if (SwipeRight)
        {
            if (m_Side == SIDE.Mid)
            {
                NewXPos = XValue;
                m_Side = SIDE.Right;
                m_Animator.Play("RIGHT_DASH");
            }
            else if (m_Side == SIDE.Left)
            {
                NewXPos = 0;
                m_Side = SIDE.Mid;
                m_Animator.Play("RIGHT_DASH");
            }
        }
        Vector3 moveVector = new Vector3(asd - transform.position.x, qwe * Time.deltaTime, 0);
        asd = Mathf.Lerp(asd, NewXPos, Time.deltaTime * SpeedDodge);
        m_char.Move(moveVector);
        Jump();
        float animspeed = MasterCODE.Instance._Speedy/15;
        m_Animator.SetFloat("sss", animspeed);
    }
    public void Jump()
    {
        if (m_char.isGrounded)
        {
            if (SwipeUp)
            {
                qwe = JumpPower;
                m_Animator.Play("JUMP");
                InJump = true;
            }

        }
        else
        {
            qwe -= JumpPower * DownSpeed * Time.deltaTime;
            if (m_char.velocity.y == 0)
                InJump = false;

        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            Destroy(other.gameObject);
            MasterCODE.Instance.Coin();

        }

        if(other.tag == "Armor" && MasterCODE.Instance._Armored == false)
        {
            Master.GetComponent<MasterCODE>()._Armored = true;
            if (dogskin==true)
            {
                _Dog.SetActive(false);
                _DogLarm.SetActive(false);
                _DogRarm.SetActive(false);

            }
            if (bearskin==true)
            {
                _Bear.SetActive(false);
                _BearLarm.SetActive(false);
                _BearRarm.SetActive(false);
            }
            if (duckskin==true)
            {
                _Duck.SetActive(true);
                _DuckLarm.SetActive(true);
                _DuckRarm.SetActive(true);

            }
            _ArmorLarm.SetActive(true);
            _ArmorSuit.SetActive(true);
            _ArmorRarm.SetActive(true);

            Destroy(other.gameObject);


        }

        if (other.tag == "Block" && MasterCODE.Instance._Armored == false)
        {
            MasterCODE.Instance.GameOver();
        }

        if(other.tag == "Block" && MasterCODE.Instance._Armored == true)
        {
            Master.GetComponent<MasterCODE>()._Armored = false;
            if (dogskin==true)
            {
                _Dog.SetActive(true);
                _DogRarm.SetActive(true);
                _DogLarm.SetActive(true);
            }
            if (bearskin==true)
            {
                _Bear.SetActive(true);
                _BearLarm.SetActive(true);
                _BearRarm.SetActive(true);
            }
            if (duckskin==true)
            {
                _Duck.SetActive(true);
                _DuckLarm.SetActive(true);
                _DuckRarm.SetActive(true);

            }


            _ArmorLarm.SetActive(false);
            _ArmorSuit.SetActive(false);
            _ArmorRarm.SetActive(false);
        }
        if(other.tag =="CoinPower" )
        {
            MasterCODE.Instance.CoinPower();
            Destroy(other.gameObject);
        }
        if(other.tag == "SpeedBuff")
        {
            MasterCODE.Instance.SpeedUp();
            Destroy(other.gameObject);

        }
        if(other.tag == "SpeedDeBuff")
        {
            MasterCODE.Instance.SpeedDown();
            Destroy(other.gameObject);
        }
        if (other.tag =="dia")
        {
            MasterCODE.Instance.Dia();
            Destroy(other.gameObject);
        }
    }
}