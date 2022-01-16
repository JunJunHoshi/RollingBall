using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectManager : MonoBehaviour
{
    [SerializeField] List<Transform> StageSelectButtonList = new List<Transform>(); //各ステージボタンごとのTransformコンポーネント
    static bool[] ClearStatusArray = new bool[10];//各ステージごとのクリア状況を格納するリスト
    static int CurrentStageId; //現在プレイしているステージを格納するリスト

    private void Awake()
    {
        GetClearDataKey();
    }
    private void Start()
    {
        SetStageSelectButtonList();

        GetClearStatus();
    }

    //ステージボタンをリストに入れるメソッド
    private void SetStageSelectButtonList()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            if (child.name.Contains("STAGE Button"))
            {
                StageSelectButtonList.Add(child);
            }
        }
    }

    private void GetClearDataKey()
    {

        //クリア情報に関するキーがもし見つかれば、リストに格納
        for (int i = 0; i < ClearStatusArray.Length; i++)
        {
            if (PlayerPrefs.HasKey("CLEAR" + i))
            {
                if (PlayerPrefs.GetInt("CLEAR" + i, 0) > 0)
                {
                    ClearStatusArray[i] = true;
                }
                else
                {
                    ClearStatusArray[i] = false;
                }
            }
        }
    }

    //リストのクリア情報情報をもとに、Clearタグを可視化
    private void GetClearStatus()
    {
        for(int i = 0; i < ClearStatusArray.Length; i++)
        {
            var clear = ClearStatusArray[i];
            if (clear)
            {
                TurnClearTag(StageSelectButtonList[i], true);
            }
        }
    }

    //クリアのタグを付け加えるメソッド
    private void TurnClearTag(Transform SelectButton, bool clear)
    {
        var clearIcon = SelectButton.GetChild(0).Find("CLEAR ICON");
        if (clearIcon != null & clear)
        {
            clearIcon.gameObject.SetActive(true);
        }
    }

    //ステージを選択すると、現在のステージIdを入力し、ステージをロードする
    public void OnSelectScene(int id)
    {
        SetCurrentStageId(id-1);
        SceneManager.LoadScene(id+1);
    }

    public static void SetCurrentStageId(int id)
    {
        CurrentStageId = id;
    }

    public static void SetNextStageId()
    {
        CurrentStageId++;
    }
    public static int GetStageId()
    {
        return CurrentStageId;
    }
}
