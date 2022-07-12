
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    bool isFly = false;

    public GameObject _Helicopter;
    public float moveSpeed;
    bool isUp = false;

    public GameObject _Slime;
    float slimeRotateX = 0;
    float slimeRotateZ = 0;

    public GameObject _Wings;
    public float wingSpeedAddForce;
    float wingSpeed;

    void Update()
    {
        RotateWing();
        UpHelicopter();
        MoveHelicopyter();
        Respawn();
    }

    void UpHelicopter()
    {
        if (wingSpeed > 5 && isUp)
        {
            isFly = true;
            _Helicopter.GetComponent<Rigidbody>().AddForce(0, wingSpeed, 0);
        }
    }

    void MoveHelicopyter()
    {
        if (isFly)
        {
            float inputX = Input.GetAxis("Vertical"); // аб©Л
            float inputZ = Input.GetAxis("Horizontal"); // ╬у╣з

            _Helicopter.transform.position += moveSpeed * new Vector3(inputZ, 0f, inputX) * Time.deltaTime;

            if (inputX < 0)
            {
                if (slimeRotateX < 20)
                {
                    slimeRotateX += 20 * Time.deltaTime;
                }
            }
            else if (inputX > 0)
            {
                if (slimeRotateX > -20)
                {
                    slimeRotateX -= 20 * Time.deltaTime;
                }
            }
            else
            {
                if (slimeRotateX < -1)
                {
                    slimeRotateX += 20 * Time.deltaTime;
                }
                else if (slimeRotateX > 1)
                {
                    slimeRotateX -= 20 * Time.deltaTime;
                }
                else
                {
                    slimeRotateX = 0;
                }
            }

            if (inputZ > 0)
            {
                if (slimeRotateZ < 20)
                {
                    slimeRotateZ += 20 * Time.deltaTime;
                }
            }
            else if (inputZ < 0)
            {
                if (slimeRotateZ > -20)
                {
                    slimeRotateZ -= 20 * Time.deltaTime;
                }
            }
            else
            {
                if (slimeRotateZ < -1)
                {
                    slimeRotateZ += 20 * Time.deltaTime;
                }
                else if (slimeRotateZ > 1)
                {
                    slimeRotateZ -= 20 * Time.deltaTime;
                }
                else
                {
                    slimeRotateZ = 0;
                }
            }

            _Slime.transform.rotation = Quaternion.Euler(slimeRotateX, -180f, slimeRotateZ);
        }
    }

    void RotateWing()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            isUp = true;

            if (wingSpeed < 10f)
            {
                wingSpeed += wingSpeedAddForce * Time.deltaTime;
            }
        }
        else
        {
            isUp = false;

            if (wingSpeed > 0)
            {
                wingSpeed -= 1.5f * wingSpeedAddForce * Time.deltaTime;

            }
            else if (wingSpeed <= 0)
            {
                wingSpeed = 0;
            }
        }
        _Wings.transform.Rotate(0, wingSpeed, 0);
    }

    void Respawn()
    {
        if (_Helicopter.transform.position.y <= 1 || Input.GetKeyDown(KeyCode.R))
        {
            _Helicopter.transform.position = new Vector3(0, 28.81f, 0);
            _Slime.transform.rotation = Quaternion.Euler(0, -180f, 0);
            isFly = false;
        }
    }
}








        
