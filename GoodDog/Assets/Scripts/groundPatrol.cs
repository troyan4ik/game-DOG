using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundPatrol : MonoBehaviour
{
    public float speed = 3f;// скорость передвижения врага
    public bool moveLeft = true;// переменная "двигаться в лево" 
    public Transform groundDetect;// земляной луч для проверки границ 
   

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);// метод Translate нужен для того,чтобы враг двигался в нужную сторону,в моем случае налево
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetect.position, Vector2.down, 1f);//Raycast2d означает бросить луч,в моем случае луч исходит из groundDetect бросается вниз на 1f 
        if (groundInfo.collider == false)// если луч не видит коллайдера то
        {
            if (moveLeft == true)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                moveLeft = false;
            } 
            else
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                    moveLeft = true;
            
                }
            
        }
    }
}
