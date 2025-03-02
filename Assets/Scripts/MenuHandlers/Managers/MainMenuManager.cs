using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject loginScreen, MainMenu;
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
            MainMenu.SetActive(true);
        }
        else
        {
            SceneHandler.Instance.isStart = true;
        }
    }

    public void OnClickWhisper()
    {
        SceneManager.LoadScene(3);
    }

    public void onClickOpenAI()
    {
        SceneManager.LoadScene(2);
    }
}
