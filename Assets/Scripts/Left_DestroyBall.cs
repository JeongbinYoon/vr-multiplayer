using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left_DestroyBall : MonoBehaviour
{
    public AudioSource right_audio;
    private Score score;

    private void Start()
    {   
        score = GameObject.Find("ScoreManager").GetComponent<Score>();
        right_audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Blue")
        {
            score.leftPoint += 10;
            Debug.Log("Ãæµ¹ Blue point " + score.leftPoint);
            right_audio.Play();
            Destroy(other.gameObject);
        }
    }
}
