using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    float timer= 0f;//
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        timer +=  Time.deltaTime;//к таймеру прибавляется 
        if(timer >= 1f)//если таймер больше или равно 1 сек
        {
            timer = 0f;//таймер обнуляется 
            transform.localScale = new Vector3(-3f, 3f, 3f);// и получает такую позицию
            
        }
        else if (timer >= 0.5f) //таймер больше 0.5 сек
        
            transform.localScale = new Vector3(3f, 3f, 3f);// то получает вода такую позицию
        
    }
  
}
