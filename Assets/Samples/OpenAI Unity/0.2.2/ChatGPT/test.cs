using LMNT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] private LMNTSpeech narrator;
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
        if (narrator == null)
        {
            narrator = GetComponent<LMNTSpeech>();
        }
        StartCoroutine(narrator.Talk());
    }
}
