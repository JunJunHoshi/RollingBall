using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour
{
    //Stageディレクトリ以下にGoalオブジェクトを置かないとダメ
    [SerializeField] Text ResultText; //ゴール表示用のテキスト
    [SerializeField] GameObject NextStageButton; //次のステージへのボタン
    [SerializeField] ParticleSystem[] GoalEffectArray = new ParticleSystem[2]; //ゴールエフェクトをまとめた配列
    private List<bool> goalList = new List<bool>(); //「各ゴールに指定のボールが来ているか」を格納するリスト
    static bool Goaled;
    private void Start()
    {
        ResultText.enabled = false;
        NextStageButton.SetActive(false);
        InitializegoalList();
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
            if(SceneManager.GetActiveScene().buildIndex!=6){
                NextStageButton.SetActive(true);
            }
            
            GoalAction();
        }
    }

    private void GoalAction()
    {
        SaveClear();
        foreach (ParticleSystem effect in GoalEffectArray)
        {
            effect.Play();
            Goaled = true;
        }
    }

    public void MoveToNextStage()
    {
        Goaled = false;
        StageSelectManager.SetNextStageId();
        var NextStageId = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadSceneAsync(NextStageId, LoadSceneMode.Single);
    }

    private void SaveClear()
    {
        //セーブに使うキーはCLERA + 現在のid。クリアしているかどうかは0.1で示す
        int id = StageSelectManager.GetStageId();
        PlayerPrefs.SetInt("CLEAR"+ id, 1);
    }
}
