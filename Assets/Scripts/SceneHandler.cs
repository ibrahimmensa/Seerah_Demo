using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHandler : Singleton<SceneHandler>
{
    public bool isStart = false;
    public int ayatNumber;
    public bool isReturningFromWhisper = false;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
