﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airPatrol : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public float speed = 2f;
    public float waitTime = 2f;
    bool canGo = true;
    void Start()
    {
        gameObject.transform.position = new Vector3(point1.position.x, point1.position.y, point1.position.z);//задал стартовую позицю летающего врага у point1 
    }


    void Update()
    { 
        if (canGo == true)
        transform.position = Vector3.MoveTowards(transform.position, point1.position, speed * Time.deltaTime);// данной командой враг двигается к point1
        if (transform.position == point1.position)// если враг достигает point1 то
        {
            Transform t = point1;//transform "t"(вспомогательный) обозначаем ,что это point1
            point1 = point2; //а point1 это point2
            point2 = t;// а point2 это t,т.е point1
            canGo = false;
            StartCoroutine (Waiting());
        }

    }
    IEnumerator Waiting()//корутина "ожиадния"
    {
        yield return new WaitForSeconds(waitTime);
        if(transform.rotation.y == 0)//это можно будет убрать ,чтобы птица "вверх вниз" не поворачивлась
        transform.eulerAngles = new Vector3(0, 180, 0);//меняет ротацию врага при повороте в другую сторону
        else
            transform.eulerAngles = new Vector3(0, 0, 0);
        canGo = true;
    }

}

