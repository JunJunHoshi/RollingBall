using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameScene : MonoBehaviour
{
    public void OnClick()
    {
        Debug.Log("afda");
        SceneManager.LoadScene("GameScene");
    }
}
