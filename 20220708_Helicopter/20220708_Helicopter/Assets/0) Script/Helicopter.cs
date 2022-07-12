
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    public Transform startPos;

    bool _isFly = false;

    public GameObject helicopter;
    Rigidbody _helicopterRigid;
    public float moveSpeed;
    bool _isUp = false;

    public GameObject slimeCopter;
    public float slimeMaxRotate = 20f;
    public float slimeReturnRotate = 20f;
    float _slimeRotateX = 0;
    float _slimeRotateZ = 0;

    public GameObject wings;
    public float wingSpeedAddForce;
    public float wingMaxSpeed = 10;
    float _wingSpeed = 0;


    void Start()
    {
        _helicopterRigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        RotateWing();
        UpHelicopter();
        MoveHelicopyter();
        Respawn();
    }

    void UpHelicopter()
    {
        if (_wingSpeed > 5 && _isUp)
        {
            _isFly = true;
            _helicopterRigid.AddForce(0, _wingSpeed, 0);
        }
    }

    void MoveHelicopyter()
    {
        if (_isFly)
        {
            float inputX = Input.GetAxis("Horizontal");
            float inputZ = Input.GetAxis("Vertical");

            helicopter.transform.position += moveSpeed * new Vector3(inputX, 0f, inputZ) * Time.deltaTime;

            if (inputZ < 0 && _slimeRotateX < slimeMaxRotate)
            {
                _slimeRotateX += slimeReturnRotate * Time.deltaTime;
            }
            else if (inputZ > 0 && _slimeRotateX > -slimeMaxRotate)
            {
                _slimeRotateX -= slimeReturnRotate * Time.deltaTime;
            }
            else
            {
                if (_slimeRotateX < -1)
                {
                    _slimeRotateX += slimeReturnRotate * Time.deltaTime;
                }
                else if (_slimeRotateX > 1)
                {
                    _slimeRotateX -= slimeReturnRotate * Time.deltaTime;
                }
                else
                {
                    _slimeRotateX = 0;
                }
            }

            if (inputX > 0 && _slimeRotateZ < slimeMaxRotate)
            {
                _slimeRotateZ += slimeReturnRotate * Time.deltaTime;
            }
            else if (inputX < 0 && _slimeRotateZ > -slimeMaxRotate)
            {
                _slimeRotateZ -= slimeReturnRotate * Time.deltaTime;
            }
            else
            {
                if (_slimeRotateZ < -1)
                {
                    _slimeRotateZ += slimeReturnRotate * Time.deltaTime;
                }
                else if (_slimeRotateZ > 1)
                {
                    _slimeRotateZ -= slimeReturnRotate * Time.deltaTime;
                }
                else
                {
                    _slimeRotateZ = 0;
                }
            }

            slimeCopter.transform.rotation = Quaternion.Euler(_slimeRotateX, -180f, _slimeRotateZ);
        }
    }

    void RotateWing()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _isUp = true;

            if (_wingSpeed < wingMaxSpeed)
            {
                _wingSpeed += wingSpeedAddForce * Time.deltaTime;
            }
        }
        else
        {
            _isUp = false;

            if (_wingSpeed > 0)
            {
                _wingSpeed -= 1.5f * wingSpeedAddForce * Time.deltaTime;

            }
            else if (_wingSpeed <= 0)
            {
                _wingSpeed = 0;
            }
        }
        wings.transform.Rotate(0, _wingSpeed, 0);
    }

    void Respawn()
    {
        if (helicopter.transform.position.y <= 1 || Input.GetKeyDown(KeyCode.R))
        {
            helicopter.transform.position = startPos.position;
            slimeCopter.transform.rotation = Quaternion.Euler(0, -180f, 0);
            _isFly = false;
        }
    }
}








        
