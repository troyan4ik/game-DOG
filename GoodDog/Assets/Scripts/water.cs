using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    float timer= 0f;//
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        timer +=  Time.deltaTime;//� ������� ������������ 
        if(timer >= 1f)//���� ������ ������ ��� ����� 1 ���
        {
            timer = 0f;//������ ���������� 
            transform.localScale = new Vector3(-3f, 3f, 3f);// � �������� ����� �������
            
        }
        else if (timer >= 0.5f) //������ ������ 0.5 ���
        
            transform.localScale = new Vector3(3f, 3f, 3f);// �� �������� ���� ����� �������
        
    }
  
}
