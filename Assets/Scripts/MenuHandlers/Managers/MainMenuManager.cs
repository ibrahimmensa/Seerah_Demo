using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject loginScreen, MainMenu, surahsMenu, ProphetStoryMenu, StudyPlanMenu, DashboardMenu, MilestonMenu, ExploreMenu;
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
            else if (SceneHandler.Instance.isReturningFromChatGPT)
            {
                closeAllMenus();
                switch (SceneHandler.Instance.menuNumber)
                {
                    case 1:
                        surahsMenu.gameObject.SetActive(true);
                        break;
                    case 2:
                        ExploreMenu.gameObject.SetActive(true);
                        break;
                    case 3:
                        MainMenu.gameObject.SetActive(true);
                        break;
                    case 4:
                        StudyPlanMenu.gameObject.SetActive(true);
                        break;
                    case 5:
                        MilestonMenu.gameObject.SetActive(true);
                        break;
                }
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

    public void closeAllMenus()
    {
        loginScreen.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(false);
        surahsMenu.gameObject.SetActive(false);
        ProphetStoryMenu.gameObject.SetActive(false);
        StudyPlanMenu.gameObject.SetActive(false);
        DashboardMenu.gameObject.SetActive(false);
        MilestonMenu.gameObject.SetActive(false);
        ExploreMenu.gameObject.SetActive(false);
    }
}
