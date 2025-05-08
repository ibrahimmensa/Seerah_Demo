using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ayatHandler : MonoBehaviour
{
    public float duration;
    public Slider slider;
    public controlHandler controls;
    public ayat[] acceptedWords;
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
        slider.value = 0;
    }

    public void playSlider()
    {
        StartCoroutine(playingSlider());
    }

    IEnumerator playingSlider()
    {
        float i = 0.0f;
        slider.maxValue = duration;
        while (i < duration)
        {
            yield return new WaitForSeconds(0.1f);
            i += 0.1f;
            slider.value = i;
        }
        controls.playBtn.interactable = true;
        controls.nextBtn.interactable = true;
        controls.PreviousBtn.interactable = true;
        controls.recordBtn.interactable = true;
    }
}
