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
    public Text result; //총 점수

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startMinutes * 60; //2분세팅  currentTime = 60 * 2;
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
            Debug.Log("시간 끝");
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
        result.text = totalScore.ToString(); // 총 점수
        currentTime = startMinutes * 60; //시간 초기화
        spawner.isPlay = true; 
        spawner.gameObject.SetActive(true);
        reStart_UI.SetActive(true);
        UIController.SetActive(true);
        score.leftPoint = 0; //스코어 초기화
        score.rightPoint = 0;// 스코어 초기화
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
