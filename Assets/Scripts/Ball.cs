using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] public Color myColor = new Color();
    //最初に自身の色を代入
    private void Awake()
    {
        GetComponent<MeshRenderer>().material.color = myColor;
    }
}
