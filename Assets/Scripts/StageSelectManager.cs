using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectManager : MonoBehaviour
{
    public void OnSelectScene(int id)
    {
        SceneManager.LoadScene(id+1);      
    }
}
