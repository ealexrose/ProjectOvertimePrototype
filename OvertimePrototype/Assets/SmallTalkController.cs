using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SmallTalkController : MonoBehaviour
{
    bool active;

    [HideInInspector]
    public bool talking;
    [HideInInspector]
    public bool breathing;
    [HideInInspector]
    public string loadedDialogue;
    
    float monologueProgress;
    
    [Header("Small talk control values")]
    public float talkSpeed;
    public Vector2 timeBetweenInterrupts;
    public float timeTillSpeech;
    public float breathTime;
    float breathCounter;

    [Header("References")]
    public TextMeshProUGUI speech;
    public GameObject textArea;
    public Animator guyAnimator;
    public TextAsset masterSmallTalkList;

    int newLines;
    // Start is called before the first frame update
    void Start()
    {
        loadedDialogue = masterSmallTalkList.text;
        breathCounter = breathTime;
    }



    // Update is called once per frame
    void Update()
    {
        UpdateDialogue();
        UpdateInterrupts();
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetButtonDown("FuckOff") && breathing) 
        {
            guyAnimator.SetTrigger("FuckOff");
            active = false;
            HideTextBox();
            timeTillSpeech = UnityEngine.Random.Range(timeBetweenInterrupts.x, timeBetweenInterrupts.y);
        }
    }

    private void UpdateInterrupts()
    {
        if (!active) 
        {
            timeTillSpeech -= Time.deltaTime;
            if (timeTillSpeech <= 0) 
            {
                ActivateSpeech();
            }
        }
    }


    internal void ShowTextBox()
    {
        speech.text = "";
        monologueProgress = 0f;
        textArea.SetActive(true);
        newLines = 0;

    }
    public void HideTextBox()
    {
        speech.text = "";
        monologueProgress = 0f;
        textArea.SetActive(false);
        newLines = 0;
    }

    private void ActivateSpeech()
    {
        active = true;
        guyAnimator.SetTrigger("ComeIn");
    }

    private void UpdateDialogue()
    {
        if (talking) 
        {
            speech.text = loadedDialogue.Substring(0,Mathf.Min((int)monologueProgress,loadedDialogue.Length));            
            monologueProgress += talkSpeed * Time.deltaTime;

            breathCounter -= Time.deltaTime;
            if (breathCounter <= 0) 
            {
                breathCounter = breathTime;
                guyAnimator.SetTrigger("Breath");
                talking = false;
            }

        }
    }
}
