using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallTalkAnimationHelper : MonoBehaviour
{

    public SmallTalkController smallTalkController;

    public void SetTalkingActive() 
    {
        smallTalkController.talking = true;
    }
    public void SetTalkingInActive()
    {
        smallTalkController.talking = false;
    }

    public void SetBreathingActive()
    {
        smallTalkController.breathing = true;
    }

    public void SetBreathingInActive()
    {
        smallTalkController.breathing = false;
    }

    public void ShowTextBox() 
    {
        smallTalkController.ShowTextBox();
    }
}
