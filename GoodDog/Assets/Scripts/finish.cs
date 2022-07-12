using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour
{
    public main Main;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "DOG")
        {
            Main.win();
        }
    }
}
