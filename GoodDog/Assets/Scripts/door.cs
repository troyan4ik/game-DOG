using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public bool isOpen = false;//изначально дверь закрыта
    public Transform Door;//позиция двери к которой мы будем телепортироваться
    public Sprite doorIsOpen;//спрайт открытой двери



   public void Unlock()//метод открывания дври
    {
        isOpen = true;//дверь открыта
        GetComponent<SpriteRenderer>().sprite = doorIsOpen;//меняется спрайт на открытую дверь
    }
    public void Teleport(GameObject dogPlayer)//методом телепорта собаки из одной двери в другую
    {
        dogPlayer.transform.position = new Vector3(Door.position.x, Door.position.y, dogPlayer.transform.position.z);// позиция собаки приравниваем в позицию двери,чтобы спрайт откыртой двери не моргал(Не сприпта,а к ппозици переменной Door)
    }
}
