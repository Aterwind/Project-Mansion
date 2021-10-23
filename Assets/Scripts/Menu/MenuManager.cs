using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu=null;
    [SerializeField] private GameObject Controlls=null;
    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }

    public void Contolls(int menu)
    {
        if(menu == 0)
        {
            MainMenu.gameObject.SetActive(true);
            Controlls.gameObject.SetActive(false);
        }
        else if (menu == 1)
        {
            MainMenu.gameObject.SetActive(false);
            Controlls.gameObject.SetActive(true);
        }
    }
}
