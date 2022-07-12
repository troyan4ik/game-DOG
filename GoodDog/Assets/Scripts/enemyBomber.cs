using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBomber : MonoBehaviour
{
    public GameObject bullet;// пуля
    public Transform shoot;//точка откуда будет происходить выстрел
    public float timeShot = 3f;//переменная которая задаст ,с какой частотой будет происходить выстрел
    
    void Start()
    {
        shoot.transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);//координаты,откуда будет проиходить выстрел(-1f)
        StartCoroutine(Shooting());//запус корутины в методе старт,чтобы она начала работать с самого начала
    }

  
    void Update()
    {
        
    }
    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(timeShot);//корутина,которая указывает время спауна пули
        Instantiate(bullet, shoot.transform.position, transform.rotation);// метод"instantiate" создает объект,условия(какой оъект,откуда,и угол)
        StartCoroutine(Shooting());//после вызываю опять эту корутина,чтобы все выше описаное в корутине повторились по кругу,чтобы пули падали постоянно

    }
}
