using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class pControl : MonoBehaviour
{
    public Image PauseImage;
    public Image DefeatImage;

    public void Start()
    {
        EventManager.Subscribe("resetLevel", FuncDefeat);
    }


    public void LoadSceneMap()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        EventManager.Clear();
    }

    public void LoadScenePause()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        EventManager.Clear();
    }

    public void FuncDefeat(object[] parameters)
    {
        DefeatImage.transform.gameObject.SetActive(true);
        StartCoroutine(resetAnim());
    }

    public void Pause()
    {
        PauseImage.transform.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        PauseImage.transform.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    IEnumerator resetAnim()
    {
        yield return new WaitForSeconds(3);
        Time.timeScale = 0;
    }
}
