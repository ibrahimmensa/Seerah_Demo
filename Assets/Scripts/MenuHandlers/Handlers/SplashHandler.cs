using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashHandler : MonoBehaviour
{
    public Image logo;
    public GameObject splash;
    public GameObject tutorial1, tutorial2, tutorial3;
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
        fadeInLogo();
    }

    public void fadeInLogo()
    {
        StartCoroutine(fadeInLogoStart());
    }

    IEnumerator fadeInLogoStart()
    {
        while (logo.color.a < 1)
        {
            yield return new WaitForSeconds(0.1f);
            logo.color = new Color(logo.color.r, logo.color.g, logo.color.b, logo.color.a + 0.05f);
        }
        tutorial1.SetActive(true);
        splash.SetActive(false);
    }

    public void onClickSkip()
    {
        SceneManager.LoadScene(1);
    }
}
