using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecitationHandler : MonoBehaviour
{
    public GameObject[] allAyats;
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
        for (int i = 0; i < allAyats.Length; i++)
        {
            allAyats[i].gameObject.SetActive(false);
        }
        allAyats[SceneHandler.Instance.ayatNumber - 1].gameObject.SetActive(true);
    }

    public void onclickPlay()
    {
        
    }

    public void onClickBack()
    {
        SceneHandler.Instance.isReturningFromWhisper = true;
        SceneManager.LoadScene(1);
    }
}
