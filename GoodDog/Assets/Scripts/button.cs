using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    public GameObject[] block;//блоки в массиве которые уничтожатся при нажатие кнопки
    public Sprite buttonDown;//спрайт уже нажатой кнопки
    public soundsGame soundsGames;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)//метод соприкосновение кнопки и кубика с тегом "MarkBox"
    {
        if(collision.gameObject.tag == "MarkBox")//если коллайдер кнопки соприкосается с кубиком с тегом "MarkBox" то...
        {
            soundsGames.playRedButtonSound();
            GetComponent<SpriteRenderer>().sprite = buttonDown;//меняется спрайт не нажатой кнопки на нажатую
            GetComponent<Collider2D>().enabled = false;//коллайдер кнопки удаляется
            foreach (GameObject objBlock in block)//foreach в переводе "для каждого",в юнити задам кол-во блоков
            {
                Destroy(objBlock);//уничтожаются блоки если нажата кнопка
            }
        }
    }
}
