using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectManager : MonoBehaviour
{
    [SerializeField] List<Transform> StageSelectButtonList = new List<Transform>(); //各ステージボタンごとのTransformコンポーネント
    [SerializeField] bool[] ClearStatusArray = new bool[5];//各ステージごとのクリア状況を格納するリスト

    private void Awake()
    {
        SetStageSelectButtonArray();

        GetClearStatus();
    }

    //ステージボタンを配列に入れるメソッド
    private void SetStageSelectButtonArray()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            if (child.name.Contains("STAGE Button"))
            {
                Debug.Log("ボタンだよ");
                StageSelectButtonList.Add(child);
            }
        }
    }

    //クリア情報を獲得するメソッド
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

    public void OnSelectScene(int id)
    {
        SceneManager.LoadScene(id+1);      
    }
}
