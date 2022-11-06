using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    bool timerActive = false;
    float currentTime;
    public int startMinutes; 
    public Text currentTimeText;
    public GameObject reStart_UI;
    public GameObject UIController;
    private bool isActiveUI = false;
    private Spawner spawner;
    private Score score;
    public Text result; //�� ����

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startMinutes * 60; //2�м���  currentTime = 60 * 2;
        spawner = GameObject.Find("Spawner Manager").GetComponent<Spawner>();
        score = GameObject.Find("ScoreManager").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timerActive == true)
        {
            currentTime = currentTime - Time.deltaTime;
            isActiveUI = false;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();

        if (currentTime <= 0.0f && isActiveUI == false)
        {
            Debug.Log("�ð� ��");
            StopTimer();
            spawner.isPlay = false;
            spawner.gameObject.SetActive(false);
            Invoke("ReStart", 5.0f);
            isActiveUI = true;
        }
    }

    public void ReStart()
    {
        int totalScore = score.leftPoint + score.rightPoint; 
        result.text = totalScore.ToString(); // �� ����
        currentTime = startMinutes * 60; //�ð� �ʱ�ȭ
        spawner.isPlay = true; 
        spawner.gameObject.SetActive(true);
        reStart_UI.SetActive(true);
        UIController.SetActive(true);
        score.leftPoint = 0; //���ھ� �ʱ�ȭ
        score.rightPoint = 0;// ���ھ� �ʱ�ȭ
    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }
}
