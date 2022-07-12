using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimEnemy : MonoBehaviour
{
 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)//если гл.персонаж столкнется коллайдерами с врагом то
    {
        if(collision.gameObject.tag == "DOG")//если коллайдер объекта с тегом "DOG" то.
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 3f, ForceMode2D.Impulse);//персонаж подпрыгнет на 3 ф
            gameObject.GetComponentInParent<Enemy>().startDeath();//отсылка с корутиной в скрипт Enemy
        }
    }



}
