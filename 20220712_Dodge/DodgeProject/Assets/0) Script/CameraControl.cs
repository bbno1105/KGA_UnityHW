using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float camAngleSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAround();
    }

    public void LookAround()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X") * camAngleSpeed, Input.GetAxis("Mouse Y") * camAngleSpeed);
        Vector3 camAngle = this.transform.rotation.eulerAngles;

        float camAngleX = camAngle.x - mouseDelta.y;

        if (camAngleX < 180f)
        {
            camAngleX = Mathf.Clamp(camAngleX, -1f, 70f);
        }
        else
        {
            camAngleX = Mathf.Clamp(camAngleX, 340f, 361f);
        }

        this.transform.rotation = Quaternion.Euler(camAngleX, camAngle.y + mouseDelta.x, camAngle.z);
        // camAngle.x - mouseDelta.y << �������� ���ϰ� ���Ǵ� ���۹������ ����ڿ� ���� �ͼ����� �ٸ� �� �ִ�
        // +, - ���� �ΰ��� ������ �ξ ���ϴ� ���۹������ ������ �� �ֵ��� �ɼǿ� �߰�����

        //UnityEngine.Debug.Log("camAngleX:" + camAngleX);
    }
}
