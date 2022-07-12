using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public bool isOpen = false;//���������� ����� �������
    public Transform Door;//������� ����� � ������� �� ����� �����������������
    public Sprite doorIsOpen;//������ �������� �����



   public void Unlock()//����� ���������� ����
    {
        isOpen = true;//����� �������
        GetComponent<SpriteRenderer>().sprite = doorIsOpen;//�������� ������ �� �������� �����
    }
    public void Teleport(GameObject dogPlayer)//������� ��������� ������ �� ����� ����� � ������
    {
        dogPlayer.transform.position = new Vector3(Door.position.x, Door.position.y, dogPlayer.transform.position.z);// ������� ������ ������������ � ������� �����,����� ������ �������� ����� �� ������(�� �������,� � ������� ���������� Door)
    }
}
