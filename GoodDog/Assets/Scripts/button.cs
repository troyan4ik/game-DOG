using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    public GameObject[] block;//����� � ������� ������� ����������� ��� ������� ������
    public Sprite buttonDown;//������ ��� ������� ������
    public soundsGame soundsGames;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)//����� ��������������� ������ � ������ � ����� "MarkBox"
    {
        if(collision.gameObject.tag == "MarkBox")//���� ��������� ������ ������������� � ������� � ����� "MarkBox" ��...
        {
            soundsGames.playRedButtonSound();
            GetComponent<SpriteRenderer>().sprite = buttonDown;//�������� ������ �� ������� ������ �� �������
            GetComponent<Collider2D>().enabled = false;//��������� ������ ���������
            foreach (GameObject objBlock in block)//foreach � �������� "��� �������",� ����� ����� ���-�� ������
            {
                Destroy(objBlock);//������������ ����� ���� ������ ������
            }
        }
    }
}
