using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class menu : MonoBehaviour
{
    public Button[] lvls;//кнопки урвовней в игре в меню UI
    public Text coinText;
    public Slider musicMenuSlider, musicLevelSlider;
    public Text musicMenuText, musicLevelText;
    public AudioSource menuSource;
   
    void Start()
    {
     
        if (PlayerPrefs.HasKey("Level+"))//если ключ level+ найден то
            for (int i = 0; i < lvls.Length; i++)//открывается следующий  уровень
            {
               if (i <= PlayerPrefs.GetInt("Level+"))
                    lvls[i].interactable = true;
                else
                    lvls[i].interactable = false;
            }


    }

   
    void Update()
    {
      
        if (PlayerPrefs.HasKey("coins"))//если есть деньги
            coinText.text = PlayerPrefs.GetInt("coins").ToString();//то будет выводится их количество в строковом варианте на табло в гл.меню
        else
            coinText.text = "0";//если нет денег,то будет писаться 0

    }
    public void openScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void delKey()//кнопка удаления сохранений
    {
        PlayerPrefs.DeleteAll();
    }

    public void exitGame()//выход из игры
    {
        Application.Quit();
    }
}
