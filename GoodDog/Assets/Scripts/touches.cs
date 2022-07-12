using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touches : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)// если касаний больше 0 
        {
            Touch touch = Input.GetTouch(0);//если нажмем на касание под цифрой "0" то(touch это локальная переменная Touch)
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);//касание транслироваться будет по всему экрану(touchPosition это локальная переменная vector3)
            if (touchPosition.x > Camera.main.transform.position.x)//если касание больше нуля(по отношению к камере которая находится на позиции 0 т.е по середине оси х)
                transform.position = new Vector3(5f, 0f, 0f);//передвигаться будет на 5f в права
            else
                transform.position = new Vector3(-5f, 0f, 0f);//а тут на 5f в лев
        }
    }
}
