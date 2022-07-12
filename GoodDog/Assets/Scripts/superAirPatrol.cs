using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superAirPatrol : MonoBehaviour
{
    public Transform[] points;//массив с точками передвижения врага
    public float speed = 2f;//скорость передвижения объекта врага
    public float waitTime = 3f;//время ожидания 
    bool canGo = true;//может ли,изначально да
    int i = 1;// вспомогательная переменная 
    void Start()
    {
        gameObject.transform.position = new Vector3(points[0].position.x, points[0].position.y, transform.position.z);//обозначил позицию врага у поинта 0
    }


    void Update()
    {
        if (canGo == true)
            transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);// данной командой враг двигается к point1
        if (transform.position == points[i].position)// если враг достигает point1 то
        {
            if (i < points.Length - 1)//если 
                i++;//
            else
                i = 0;//

            canGo = false;
            StartCoroutine(Waiting());
        }

    }
    IEnumerator Waiting()//корутина "ожиадния"
    {
        yield return new WaitForSeconds(waitTime);
        canGo = true;
    }


}
