using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class predatoryPlant : MonoBehaviour
{
    public float speed = 3f;//скорость перемещения растения
    public Transform point;//точка куда будет двигться растение из земли
    public float waitTime = 3f;//время ожидания перед выходом из земли или наоборот
    bool isWait = false;//ждет ли наш чтобы выпрыгнуть или скрыться
    bool isHidden = false;//спрятано ли растение под землей или нет,изначально "да"
    void Start()
    {
        point.transform.position = new Vector3(transform.position.x, transform.position.y + 6f, transform.position.z);//задал координат где будет находиться point  и куда будет перемещаться растение(враг)
    }

    
    void Update()
    {
        if (isWait == false)

        transform.position = Vector3.MoveTowards(transform.position, point.position, speed * Time.deltaTime);//координат point куда будеть вылазить растение
        
        if(transform.position == point.position)//если позиция растения находится в point то условие...
        {
            if (isHidden == true)//если растение скрыто,т.е правда то
            {
                point.transform.position = new Vector3(transform.position.x, transform.position.y + 6f, transform.position.z);//цветок вылезет на poin на 1f
                isHidden = false;
            }
            else//иначе
            {
                point.transform.position = new Vector3(transform.position.x, transform.position.y - 6f, transform.position.z);//зазелезит обратно на свою роднуюю координат
                isHidden = true;
            }
            isWait = true;
            StartCoroutine(Waiting());// стартует время ожидания между "залезть" и "вылезти"
        }

    }
    IEnumerator Waiting()//корутина ожидания между "залезть" и "вылезти"
    {
        yield return new WaitForSeconds(waitTime);
        isWait = false;
    }
}
