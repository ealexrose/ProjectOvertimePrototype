using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EmailController : MonoBehaviour
{
    public static EmailController instance;

    public int emailsToRespondTo;
    public int emailLength;
    int emailProgress;

    public Vector2Int timeBetweenEmails;
    float timeTillNextEmail;



    [Header("References")]
    public Animator emailFieldAnimator;

    public GameObject emailScreen;
    public GameObject emailIcon;
    public TextMeshProUGUI inboxSize;

    public TextAsset emails;
    public TextMeshProUGUI sourceEmail;
    string[] sourceEmailArray;
    string loadedEmail;

    public TextAsset subjects;
    public TextMeshProUGUI subjectLine;
    string[] subjectArray;
    string loadedSubject;

    public TextAsset responses;
    public TextMeshProUGUI email;
    string[] responseArray;
    string loadedResponse;

    public TextMeshProUGUI emailNotifCounter;

    bool emailScreenIsUp;
    bool currentlyResondingToEmail;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        emailsToRespondTo = 0;
        timeTillNextEmail = UnityEngine.Random.Range(timeBetweenEmails.x, timeBetweenEmails.y);
        sourceEmailArray = sourceEmail.text.Split('\n');
        subjectArray = subjects.text.Split('\n');
        responseArray = responses.text.Split('>');

        RandomizeEmailTexts();


    }

    // Update is called once per frame
    void Update()
    {
        UpdateEmailTiming();
        HandleEmail();
    }

    private void HandleEmail()
    {
        if (EmailKeyPressed())
        {
            if (emailScreenIsUp)
            {
                AdvanceEmailScreen();
            }
            else
            {
                if (emailsToRespondTo > 0)
                {
                    BringUpEmailScreen();
                    AdjustEmailResponse(emailsToRespondTo - 1);
                    currentlyResondingToEmail = true;
                }
            }

        }
    }

    private void AdjustEmailResponse(int emailCount)
    {
        emailsToRespondTo = emailCount;
        if (emailsToRespondTo > 0)
        {

            emailIcon.SetActive(true);
            emailNotifCounter.text = emailsToRespondTo.ToString();
           
        }
        else 
        {
            emailIcon.SetActive(false);
        }
    }

    private void AdvanceEmailScreen()
    {
        emailProgress++;
        int totalWordCount = loadedEmail.Length + loadedResponse.Length + loadedSubject.Length;
        int charactersIn = (totalWordCount / ((int)(emailLength * 0.8f))) * emailProgress;

        sourceEmail.text = loadedEmail.Substring(0, Mathf.Min(charactersIn, loadedEmail.Length));
        subjectLine.text = loadedSubject.Substring(0, Mathf.Clamp(charactersIn - loadedEmail.Length, 0, loadedSubject.Length));
        email.text = loadedResponse.Substring(0, Mathf.Clamp(charactersIn - loadedEmail.Length - loadedSubject.Length, 0, loadedResponse.Length));

        if (emailProgress >= emailLength)
        {
            emailFieldAnimator.SetTrigger("SlideOut");
            email.text = "";
            subjectLine.text = "";
            sourceEmail.text = "";
            emailProgress = 0;
            emailScreenIsUp = false;
            currentlyResondingToEmail = false;
        }

    }

    private void BringUpEmailScreen()
    {
        emailFieldAnimator.SetTrigger("SlideIn");
        email.text = "";
        subjectLine.text = "";
        sourceEmail.text = "";
        emailProgress = 0;
        emailScreenIsUp = true;
    }

    private void UpdateEmailTiming()
    {
        timeTillNextEmail -= Time.deltaTime;
        if (timeTillNextEmail <= 0) 
        {
            timeTillNextEmail = UnityEngine.Random.Range(timeBetweenEmails.x, timeBetweenEmails.y);
            RandomizeEmailTexts();
            AdjustEmailResponse(emailsToRespondTo + 1);
        }

    }

    private void RandomizeEmailTexts()
    {
        loadedEmail = sourceEmailArray[UnityEngine.Random.Range(0, sourceEmailArray.Length)];
        loadedSubject = subjectArray[UnityEngine.Random.Range(0, subjectArray.Length)];
        loadedResponse = responseArray[UnityEngine.Random.Range(0, responseArray.Length)];
    }

    bool EmailKeyPressed()
    {
        bool topLine = Input.GetKeyDown("t") || Input.GetKeyDown("y") || Input.GetKeyDown("u") || Input.GetKeyDown("i") || Input.GetKeyDown("o") || Input.GetKeyDown("p") || Input.GetKeyDown("[") || Input.GetKeyDown("]");
        bool midLine = Input.GetKeyDown("f") || Input.GetKeyDown("g") || Input.GetKeyDown("h") || Input.GetKeyDown("j") || Input.GetKeyDown("k") || Input.GetKeyDown("l") || Input.GetKeyDown(";") || Input.GetKeyDown("'");
        bool botLine = Input.GetKeyDown("v") || Input.GetKeyDown("b") || Input.GetKeyDown("n") || Input.GetKeyDown("n") || Input.GetKeyDown("m") || Input.GetKeyDown(",") || Input.GetKeyDown(".") || Input.GetKeyDown("/");
        return topLine || midLine || botLine;
    }
}
