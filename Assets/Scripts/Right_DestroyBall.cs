using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right_DestroyBall : MonoBehaviour
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
        if(other.tag == "Red")
        {
            score.rightPoint += 10;
            Debug.Log("Ãæµ¹ Red point: " + score.rightPoint);
            right_audio.Play();
            Destroy(other.gameObject);
        }
    }
}
