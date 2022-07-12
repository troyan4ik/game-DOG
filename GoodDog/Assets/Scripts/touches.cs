using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touches : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)// ���� ������� ������ 0 
        {
            Touch touch = Input.GetTouch(0);//���� ������ �� ������� ��� ������ "0" ��(touch ��� ��������� ���������� Touch)
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);//������� ��������������� ����� �� ����� ������(touchPosition ��� ��������� ���������� vector3)
            if (touchPosition.x > Camera.main.transform.position.x)//���� ������� ������ ����(�� ��������� � ������ ������� ��������� �� ������� 0 �.� �� �������� ��� �)
                transform.position = new Vector3(5f, 0f, 0f);//������������� ����� �� 5f � �����
            else
                transform.position = new Vector3(-5f, 0f, 0f);//� ��� �� 5f � ���
        }
    }
}
