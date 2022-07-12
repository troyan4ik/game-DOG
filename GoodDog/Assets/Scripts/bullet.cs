using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 5f;// скорость падения пули
    float timeToDisable = 4.5f;//время до отключения
    void Start()
    {
        StartCoroutine(setDisable());//вызываю корутину в методе старт,чтобы вызывалась с самого начала
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);//метод при котором пуля летит вниз
    }
    
    IEnumerator setDisable() // отключение(установить отключение)
    {
        yield return new WaitForSeconds(timeToDisable);//ждем 10сек
        gameObject.SetActive(false);//отключаем пулю через 10 сек
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        gameObject.SetActive(false);//при столкновение с персонажем пуля удаляется
    }
}
