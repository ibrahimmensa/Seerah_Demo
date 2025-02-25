using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
