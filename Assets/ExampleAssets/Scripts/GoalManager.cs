using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalManager : MonoBehaviour
{
    [SerializeField] Text ResultText;
    private bool[] goallist = new bool[2];
    private void Start()
    {
        ResultText.enabled = false;
    }

    public void SetGoalNum(int i)
    {
        goallist[i] = true;
        DetectGoal();
    }

    private void DetectGoal()
    {
        int goalnum = 0;
        foreach(bool goal in goallist)
        {
            if (goal) goalnum += 1;
        }
        if(goalnum >= 2)
        {
            ResultText.text = "Goal";
            ResultText.enabled = true;
        }
    }
}
