using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour
{
    //Stageディレクトリ以下にGoalオブジェクトを置かないとダメ
    [SerializeField] Text ResultText; //ゴール表示用のテキスト
    [SerializeField] ParticleSystem[] GoalEffectArray = new ParticleSystem[2]; //ゴールエフェクトをまとめた配列
    private List<bool> goalList = new List<bool>(); //「各ゴールに指定のボールが来ているか」を格納するリスト
    static bool Goaled;
    private void Start()
    {
        ResultText.enabled = false;
        InitializegoalList();
    }

    private void Update()
    {
        if (Goaled)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                MoveToNextStage();
            }
        }
    }

    private void InitializegoalList()
    {
        for(int i= 0; i<transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<GoalDetector>() != null)
            {
                goalList.Add(false);
            }
        }
    }

    public void SetGoalNum(int i)
    {
        goalList[i] = true;
        DetectGoal();
    }
    public void RemoveGoalNum(int i)
    {
        goalList[i] = false;
    }

    private void DetectGoal()
    {
        int goalnum = 0;
        foreach(bool goal in goalList)
        {
            if (goal) goalnum += 1;
        }
        if(goalnum >= goalList.Count)
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
            Goaled = true;
        }
    }

    private void MoveToNextStage()
    {
        Goaled = false;
        var NextStageId = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadSceneAsync(NextStageId, LoadSceneMode.Single);
    }
}
