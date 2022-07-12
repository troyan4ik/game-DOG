using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    float speed = 3f; // скорость камеры
    public Transform target;//цель для камеры(Player),за ним будет следить камера


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);// вектор3 работает в трех плоскостях(x.y.z) ,поэтому в z не указывает target
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = target.position;
        position.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
        // Lerp() с помощью этого метода можно плавно передвигать камеру к персонажу,он принимает 3 аргумента "позиция камера,куда движется, скорость 
    }
}
