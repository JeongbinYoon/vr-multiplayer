using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int leftPoint;
    public int rightPoint;

    private void Start()
    {
        leftPoint = 0;
        rightPoint = 0;
    }

    private void Update()
    {
        Debug.Log("왼쪽: " + leftPoint + "오른쪽: " + rightPoint);
    }
}
