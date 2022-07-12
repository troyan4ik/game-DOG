using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class menu : MonoBehaviour
{
    public Button[] lvls;//������ �������� � ���� � ���� UI
    public Text coinText;
    public Slider musicMenuSlider, musicLevelSlider;
    public Text musicMenuText, musicLevelText;
    public AudioSource menuSource;
   
    void Start()
    {
     
        if (PlayerPrefs.HasKey("Level+"))//���� ���� level+ ������ ��
            for (int i = 0; i < lvls.Length; i++)//����������� ���������  �������
            {
               if (i <= PlayerPrefs.GetInt("Level+"))
                    lvls[i].interactable = true;
                else
                    lvls[i].interactable = false;
            }


    }

   
    void Update()
    {
      
        if (PlayerPrefs.HasKey("coins"))//���� ���� ������
            coinText.text = PlayerPrefs.GetInt("coins").ToString();//�� ����� ��������� �� ���������� � ��������� �������� �� ����� � ��.����
        else
            coinText.text = "0";//���� ��� �����,�� ����� �������� 0

    }
    public void openScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void delKey()//������ �������� ����������
    {
        PlayerPrefs.DeleteAll();
    }

    public void exitGame()//����� �� ����
    {
        Application.Quit();
    }
}
