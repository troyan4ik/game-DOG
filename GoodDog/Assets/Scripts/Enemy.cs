using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public soundsGame soundsGames;


    bool isHit = false;// удар,изначально его нет(фолс)
    private void OnCollisionEnter2D(Collision2D collision)// метод отвечающий за столкновение двух и более коллайдеров у объектов
    {
        if(collision.gameObject.tag == "DOG" && !isHit) //если коллайдер объетка с тегом "DOG" соприкосается с коллайдером врага и враг не в ударе(!isHit)
        {
            
            collision.gameObject.GetComponent<dogPlayer>().RecountHp(-1);// срабатывает метод отнимания жизни - 1,который находится в скрипте dogPlayer
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 9f, ForceMode2D.Impulse);// пила будет отталкивать гл.персонажа на 3ф когда будут соприкосаться их коллайдеры  
            soundsGames.playHitSound();
        }
    }

 
 public IEnumerator Death()// корутина смерти врага
    {
        isHit = true;// если удар 
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;//
        GetComponent<Collider2D>().enabled = false;//отключение коллайдера врага
        GetComponentInChildren<Collider2D>().enabled = false;//отключение коллайдера "aim"
        yield return new WaitForSeconds(1f);//время перед тем как удалить врага со сцены 2 сек
        Destroy(gameObject);//удаление объекта со сцены
    }
    public void startDeath()//сделал это для того что,чтобы корутину Death можно было вызвать с этого скрипта в другой
    {
        StartCoroutine(Death());
    }
}
