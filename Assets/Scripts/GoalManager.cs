using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalManager : MonoBehaviour
{
    [SerializeField] Text ResultText; //ゴール表示用のテキスト
    [SerializeField] ParticleSystem[] GoalEffectArray = new ParticleSystem[2]; //ゴールエフェクトをまとめた配列
    private bool[] goallist = new bool[2]; //「各ゴールに指定のボールが来ているか」を格納するリスト
    private void Start()
    {
        ResultText.enabled = false;
    }

    public void SetGoalNum(int i)
    {
        goallist[i] = true;
        DetectGoal();
    }
    public void RemoveGoalNum(int i)
    {
        goallist[i] = false;
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
            GoalAction();
        }
    }

    private void GoalAction()
    {
        foreach(ParticleSystem effect in GoalEffectArray)
        {
            effect.Play();
        }
    }
}
