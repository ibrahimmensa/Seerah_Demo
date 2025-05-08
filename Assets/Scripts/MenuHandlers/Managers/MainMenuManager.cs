using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject loginScreen, MainMenu, surahsMenu, ProphetStoryMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        if (SceneHandler.Instance.isStart)
        {
            loginScreen.SetActive(false);
            if (SceneHandler.Instance.isReturningFromWhisper)
            {
                surahsMenu.SetActive(true);
                SceneHandler.Instance.isReturningFromWhisper = false;
            }
            else
            {
                MainMenu.SetActive(true);
            }
        }
        else
        {
            SceneHandler.Instance.isStart = true;
        }
    }

    public void OnClickWhisper(int ayatNum)
    {
        SceneHandler.Instance.ayatNumber = ayatNum;
        SceneManager.LoadScene(3);
    }

    public void onClickOpenAI()
    {
        SceneManager.LoadScene(2);
    }
}
