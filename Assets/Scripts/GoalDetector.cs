using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDetector : MonoBehaviour
{
    //ゴール判定を扱うクラス。ゴールオブジェクトに付属
    [SerializeField] int GoalID;
    [SerializeField] Color mycolor;
    //最初に自身の色を代入
    private void Awake()
    {
       transform.GetChild(0).GetComponent<Renderer>().material.color = mycolor;
    }
    public bool IsTheGoalColor(GameObject ball)
    {
        //そもそも衝突対象が ボールかどうかを判断
        if(ball.GetComponent<Ball>() == null)
        {
            return false;
        }
        //ボールだった場合、色がゴールを一致しているかどうかを判断
        var ballcolor = ball.GetComponent<Ball>().myColor;
        if (ColorManager.IsSameColor(ballcolor, mycolor) == false)
        {
            return false;
        }
        return true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ball>() != null)
        {
            other.gameObject.GetComponent<Ball>().CurrentStayingGoal = this;
        }
        if (IsTheGoalColor(other.gameObject))
        {
            SetGoal();           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Ball>() != null)
        {
            other.gameObject.GetComponent<Ball>().CurrentStayingGoal = null;
        }
        if (IsTheGoalColor(other.gameObject))
        {
            SetGoal();
        }
    }

    public void SetGoal()
    {
        GetComponentInParent<GoalManager>().SetGoalNum(GoalID);
    }
}
