using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public float speed;//скорость передвижения персонажа
    public float JumpHeight;//высота прыжка
    bool isGrounded;// проверка "на земле ли персонаж" 
    public Transform groundCheck;
    int curHp; // currentHp в переводе текущее состояние здоровья
    int maxHp = 3;// максимальное количество жизней
    bool isHit = false;
    public main Main;// объявил скрипт main "Main" чтобы к нему обратиться с помощью метода "Lose"
    public bool key = false;// ключ от двери изначально его нет
    bool canTeleport = true;//переменная "может ли собака телепортироваться"
    int coins = 0;
    public soundsGame soundsGames;
    public Joystick joystick;
    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        curHp = maxHp; // вписал это сюда чтобы в начале игры было максимальное кол-во жизней
    }

    void Update()

    {
      
        Flip();//вызов метода флип (не системного) в методе update для активации ротации спрайта персонажа
        CheckGround();// вызов метода каждый кадр,все тоже самое что и с "флип"
        OnHit();


        //if (Input.GetAxis("Horizontal") == 0 && (isGrounded)) если не нажата ни одна кнопка по горизонтали(т.е = 0)и персонаж находится на земле,т.е персонаж стоит
        if (joystick.Horizontal == 0 && (isGrounded))//сенсорная версия
        {
            anim.SetInteger("State", 1);//то активируется анимация "1"
        }
        else // иначе,если персонаж на земле,и по горизинтали не ровняется "0" а например +1 или -1 , то активируется анимация "2"
        {
            if (isGrounded)
            {
                anim.SetInteger("State", 2);
            }
            if (!isGrounded) //если персонаж не на земле,а в воздухе,то активируется анимация "3"
            {
                anim.SetInteger("State", 3);
            }

        }

        rb.velocity = new Vector2(joystick.Horizontal * speed, rb.velocity.y);//движение влево и вправо сенсорное управление
        //rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y) компьютерное управление влево и впрво


        //if (Input.GetKeyDown(KeyCode.Space) && isGrounded) //если нажать кнопку space, и персонаж на земле,а не в воздухе,то персонаж прыгнет
        {
           //rb.AddForce(transform.up * JumpHeight, ForceMode2D.Impulse);//задал прыжок/AddForce в переводе добавить силы
         //  soundsGames.playJumpSound();//звук прыжка
        }


    }

   
    void Flip()
    {
       // if (Input.GetAxis("Horizontal") > 0) // персонаж смотрит в сторону движения право
            //transform.localRotation = Quaternion.Euler(0, 0, 0);// его кооординаты
       // if (Input.GetAxis("Horizontal") < 0) // персонаж смотрит в сторону движения лево 
           // transform.localRotation = Quaternion.Euler(0, 180, 0);// его координаты 

        if (joystick.Horizontal > 0) //cенсорная версия
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (joystick.Horizontal < 0) 
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f);// проверка на "земле ли персонаж" 
        isGrounded = colliders.Length > 1;// если коллайдеров больше одного ,значит "правда , true"
    }

    public void RecountHp(int Hp) //метод отнимания жизней
    {
        curHp = curHp + Hp;//к текущему состоянию здоровью прибавляется -1 при уроне, и плюсуется +1 при подбирание сердечка
        if (Hp < 0)
            StopCoroutine(OnHit());
        isHit = true;//если гл.персонаж "в ударе"
            StartCoroutine(OnHit());//то срабатывает корутина OnHit
        
        if(curHp <= 0)// если текущее количество здоровья меньше или равно 0 то будет "смерть"
        {
            GetComponent<Collider2D>().enabled = false;// если у персонажа кончатся жизни,то его коллайдер отключается и он падает 
           // Invoke("reloadLevel", 3f); //Invoke это метод с помощью которого можно вызывать другие методы с задержкой по временеи,в моем случае это 3 сек
            Invoke("lose", 1.5f);//вызываю метод проигрыша
        }
        else if(curHp > maxHp)
        {
          curHp = maxHp;
        }
    }
    IEnumerator OnHit()// метод корутина, при котором у гл.персонажа меняется цвет на красный,при получении урона
    {
        if(isHit)//если гл.перс в ударе то..
            GetComponent<SpriteRenderer>().color = new Color(1f, GetComponent<SpriteRenderer>().color.g - 0.09f, GetComponent<SpriteRenderer>().color.b - 0.09f);// происходит отнимание цвета при ударе ,должнен получится красный
        else//иначе
            GetComponent<SpriteRenderer>().color = new Color(1f, GetComponent<SpriteRenderer>().color.g + 0.09f, GetComponent<SpriteRenderer>().color.b + 0.09f);//просиходит прибавление цвета ,получится белый
        if(GetComponent<SpriteRenderer>().color.b == 1f)//если цвет персонажа белый,то корутина приостанавливается
        {
            StopCoroutine(OnHit());
        }
        if(GetComponent<SpriteRenderer>().color.b <= 0)
        isHit = false;
        yield return new WaitForSeconds(0.09f);
        StartCoroutine(OnHit());

    }
    void reloadLevel()
    {
        Main.GetComponent<main>().reloadLevel();
    }

    void lose()
    {
        Main.GetComponent<main>().lose();
    }
   

    private void OnTriggerEnter2D(Collider2D collision)// метод подбирания ключа через триггер в моем случае
    {
        if(collision.gameObject.tag == "Key")//если сталкиваемся с объектом с тегом Key
        {
            soundsGames.playKeySound();//звук собирания влючей
            Destroy(collision.gameObject);// ключ уничтожается 
            key = true;//и теперь собака имеет ключ
        }
        if(collision.gameObject.tag == "Door")//если объект столкновения объект с тегом Door
        {
            if (key)//и если есть ключ
            collision.gameObject.GetComponent<door>().Unlock();//то обращаемся к скрипту "door" за методом Unlock,спрайт меняется на открытую дверь
            
            if (collision.gameObject.GetComponent<door>().isOpen && canTeleport)//если объект столкновения дверь и она открыта 
            {
                soundsGames.playDoorSound();//звук открывания дверей
                collision.gameObject.GetComponent<door>().Teleport(gameObject);//то мы используем метод Teleport
                canTeleport = false;//после того как собака телепортировалась,снова она не может телепортироваться в течениие 5 сек
                StartCoroutine(teleportWait());//корутина на 3 сек
            }
            
        }
        if(collision.gameObject.tag == "Coin")//если собака сталкивается с монеткой с тегом "Coin"
        {
            Destroy(collision.gameObject);//то монетка удаляется
            coins++;//приабавляются монетки
            soundsGames.playCoinSound();//звук собирания монет
        }
        if(collision.gameObject.tag == "Heart")//если собака сталкивается с сердечком с тегом Heart
        {
            soundsGames.playHeartSound();//звук собирания сердца
            Destroy(collision.gameObject);//то сердце удаляется
            RecountHp(1);//и плюсуется +1 жизнь
           
        }
     
    }

    IEnumerator teleportWait()//корутина ожидания между телепортами из двери в дверь
    {
        yield return new WaitForSeconds(5f);
            canTeleport = true;
    }

    private void OnTriggerStay2D(Collider2D collision)//метод вхождения в тригер лестницы(невидимая зона лестницы )
    {
        if(collision.gameObject.tag == "Ladder")//(если собака вошла в тригер с тегом "Ladder"
        {
            rb.bodyType = RigidbodyType2D.Kinematic;//то физика собаки становится кинематической,т.е на нее в это время не действует гравитация
            transform.Translate(Vector3.up * Input.GetAxis("Vertical")* speed * Time.deltaTime);//задал движение собаки по лестнице
        }
    }

    private void OnTriggerExit2D(Collider2D collision)//метод выхода из триггера лестницы
    {
        if(collision.gameObject.tag == "Ladder")//если собака входит в триггер с тегом "Ladder"
        {
            rb.bodyType = RigidbodyType2D.Dynamic;//то у собаки меняется физика на Dynamic ,т.е гравитация начиает работать

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)//метод батута
    {
        if(collision.gameObject.tag == "Trampoline")//если собака сталкиваемся с коллайдером имеющий тег Trampoline 
        {
            soundsGames.playTrampolineSound();
            StartCoroutine(trampolineAnim(collision.gameObject.GetComponentInParent<Animator>()));//то активируется корутина на "ребенке" коллайдера "родителя" Trampoline
        }
    }

    IEnumerator trampolineAnim(Animator animator)//корутина вмещающая в себя аниматор,а переменную я сам назвал "animator"
    {
        animator.SetBool("stateTrampoline", true);//если собака прикосается коллайдером к батуту, то срабатывает анимация 
        yield return new WaitForSeconds(0.5f);//время работы анимации
        animator.SetBool("stateTrampoline", false);//если не дотрагивается нет соприкосновения,то анимация становится исходной
        

    }
    public int getCoins()//метод ,при котором данные о кол во монеток будут возвращаться в строку UI
    {
        return coins;
    }
    
    public int getHp()
    {
        return curHp;
    }


   public void jumpButton()
   {
       if (isGrounded)
       {
           rb.AddForce(transform.up * JumpHeight, ForceMode2D.Impulse);//задал прыжок/AddForce в переводе добавить силы
           soundsGames.playJumpSound();//звук прыжка
       }

   }

}
