using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDetector : MonoBehaviour
{
    [SerializeField] int num;
    [SerializeField] GameObject GoalBall;
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == GoalBall)
        GetComponentInParent<GoalManager>().SetGoalNum(num);
    }
}
