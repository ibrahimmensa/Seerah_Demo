using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using Samples.Whisper;
using ArabicSupport;
using TMPro;
using System;

[Serializable]
public class Surah
{
    public ayat[] ayat;
}

[Serializable]
public class ayat
{
    public string[] words;
}

public class controlHandler : MonoBehaviour
{
    public Surah preRecordedSurah;
    public ayat RecitedAyat;
    public int totalAyats;
    public GameObject[] allAyat;
    public AudioClip[] allAyatAudios;
    public AudioSource audioSource;
    public ayatHandler currentAyat;
    public int currentAyatIndex;
    public int totalAyat;
    public Button playBtn, nextBtn, PreviousBtn, playVideoBtn, recordBtn;
    public VideoPlayer videoPlayer;
    public RawImage video;
    public GameObject controller;
    public GameObject ayatIntro;
    public Whisper whisper;
    public GameObject recordingPopup;
    public string recordedSentance;
    public TMP_Text test;
    public string[] words;
    public GameObject recordingIcon;
    public GameObject resultPopup;
    public TMP_Text remarks;
    public string[] allRemarks;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        controller.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickPlay()
    {
        currentAyat.slider.value = 0;
        currentAyat.playSlider();
        audioSource.PlayOneShot(allAyatAudios[currentAyatIndex]);
        playBtn.interactable = false;
        nextBtn.interactable = false;
        PreviousBtn.interactable = false;
        recordBtn.interactable = false;
    }

    public void onClickNext()
    {
        if (currentAyatIndex < allAyat.Length - 1)
        {
            allAyat[currentAyatIndex].gameObject.SetActive(false);
            currentAyatIndex++;
        }
        allAyat[currentAyatIndex].gameObject.SetActive(true);
        currentAyat = allAyat[currentAyatIndex].GetComponent<ayatHandler>();
    }

    public void onClickPrevious()
    {
        if (currentAyatIndex > 0)
        {
            allAyat[currentAyatIndex].gameObject.SetActive(false);
            currentAyatIndex--;
        }
        allAyat[currentAyatIndex].gameObject.SetActive(true);
        currentAyat = allAyat[currentAyatIndex].GetComponent<ayatHandler>();
    }

    public void onClickRecord()
    {
        test.text = "";
        playBtn.interactable = false;
        nextBtn.interactable = false;
        PreviousBtn.interactable = false;
        recordBtn.interactable = false;
        recordingPopup.SetActive(true);
        resultPopup.SetActive(false);
        recordingIcon.SetActive(true);
        whisper.StartRecording(this);
        remarks.text = "";
    }

    public void recordingToString(string recordedMsg)
    {
        //recordingPopup.SetActive(false);
        //Debug.Log(recordedMsg);
        recordingIcon.SetActive(false);
        string fixedText = ArabicFixer.Fix(recordedMsg);
        test.text = fixedText;
        words = fixedText.Split(' ');
        System.Array.Reverse(words, 0, words.Length);
        RecitedAyat.words = words;
        //preRecordedSurah.ayat[currentAyatIndex].words = words;
        //recordingPopup.SetActive(false);
        checkForCorrections();
    }

    public void checkForCorrections()
    {
        bool haveMistakes = false;
        resultPopup.SetActive(true);
        string ayatResult = "";
        string[] wordsResult;
        for (int i = preRecordedSurah.ayat[currentAyatIndex].words.Length - 1; i >= 0; i--)
        {
            if (i >= RecitedAyat.words.Length)
            {
                string[] allAcceptedWords = preRecordedSurah.ayat[currentAyatIndex].words[i].Split(", ");
                haveMistakes = true;
                ayatResult += "<color=red>" + allAcceptedWords[0] + "</color> ";
            }else
            {
                string[] allAcceptedWords = preRecordedSurah.ayat[currentAyatIndex].words[i].Split(", ");
                bool isCorrectWordFound = false;
                for (int j = 0; j < allAcceptedWords.Length; j++)
                {
                    isCorrectWordFound = false;
                    if (RecitedAyat.words[i].Equals(allAcceptedWords[j]))
                    {
                        isCorrectWordFound = true;
                        ayatResult += allAcceptedWords[0] + " ";
                        break;
                    }
                }
                if (!isCorrectWordFound)
                {
                    haveMistakes = true;
                    ayatResult += "<color=red>" + allAcceptedWords[0] + "</color> ";
                }
            }
            
        }
        words = ayatResult.Split(' ');
        System.Array.Reverse(words, 0, words.Length);
        ayatResult = "";
        for (int i = words.Length-1; i >= 0; i--)
        {
            ayatResult += words[i] + " ";
        }
        //wordsResult = ayatResult.Split(' ');
        //Array.Reverse(wordsResult);
        //ayatResult = string.Concat(wordsResult);
        //ayatResult = "";
        //for (int j = 0; j < wordsResult.Length; j++)
        //{
        //    ayatResult += wordsResult[j] + " ";
        //}
        test.text = ayatResult;
        if (haveMistakes)
        {
            remarks.text = allRemarks[UnityEngine.Random.Range(0, allRemarks.Length)];
        }
        else
        {
            remarks.text = "No Remarks.";
        }
    }

    public void onClickSkip()
    {
        currentAyatIndex = 0;
        totalAyat = allAyat.Length;
        allAyat[currentAyatIndex].SetActive(true);
        currentAyat = allAyat[currentAyatIndex].GetComponent<ayatHandler>();
        controller.SetActive(true);
        ayatIntro.SetActive(false);
        videoPlayer.Stop();
    }

    public void onClickPlayVideo()
    {
        
    }
}
