using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//добавил библиотеку работы со сценами в юнити 
using UnityEngine.UI;
 public class main : MonoBehaviour
{
    public dogPlayer dog;//переменная скрипта собаки
    public Text coinText;//строка показывающая кол-во собранных монеток
    public Image[] hearts;//показатель сердец(жиззни) у собаки
    public Sprite isLife, nonLife;//
    public GameObject pauseScreen;
    public GameObject winScreen;
    public GameObject loseScreen;
    float timer = 0f;
    public Text timeText;
    public soundsGame soundsGames;
    public AudioSource musicSource;

    private void Start()
    {
        
      
    }
    public void reloadLevel()// метод не системный "проигрыш"
    {
        Time.timeScale = 1f;
        dog.enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      
    }

    public void Update()
    {
        coinText.text = dog.getCoins().ToString();//в coinText UI будет отображаться данные о количестве монеток.ToString преобразует эти данные в строку

        for (int i = 0; i < hearts.Length; i++)//цикл ,при котором,если 
        {
            if (dog.getHp() > i)
                hearts[i].sprite = isLife;
            else
                hearts[i].sprite = nonLife;
        }
        timer += Time.deltaTime;//секундомер
        timeText.text = timer.ToString("F2").Replace(",", ":");//преобразуем значение секундомера в строку и заменям запятую на двоеточие в таймере
    }

    public void pauseOn()//метод влючения паузы
    {
        Time.timeScale = 0f;//время останавливается
        dog.enabled = false;//собака оключается
        pauseScreen.SetActive(true);//появляется окошко с паузой
    }
    public void pauseOff()//тут все наоборот
    {
        Time.timeScale = 1f;
        dog.enabled = true;
        pauseScreen.SetActive(false);
    }
    public void win()//панель победы
    {
        soundsGames.playWinSound();
        Time.timeScale = 0f;
        dog.enabled = false;
        winScreen.SetActive(true);
        if (!PlayerPrefs.HasKey("Level+") || PlayerPrefs.GetInt("Level+") < SceneManager.GetActiveScene().buildIndex)
            PlayerPrefs.SetInt("Level+", SceneManager.GetActiveScene().buildIndex);
        if (PlayerPrefs.HasKey("coins"))
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins" + dog.getCoins()));
        else
            PlayerPrefs.SetInt("coins", dog.getCoins());
    }

    public void lose()//панель проигрыша
    {
        soundsGames.playLoseSound();
        Time.timeScale = 0f;
        dog.enabled = false;
        loseScreen.SetActive(true);
    }

    public void menu()//панель меню
    {
        Time.timeScale = 1f;
        dog.enabled = true;
        SceneManager.LoadScene("Menu");
    }

    public void nextLevel()//панель "следующий лвл"
    {
        Time.timeScale = 1f;
        dog.enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//запуск следующей сцены (лвл)
    }
}
