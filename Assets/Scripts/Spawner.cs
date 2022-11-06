using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] cubes;
    public Transform[] points;
    public float beat = (60 / 130) * 2;
    public bool isPlay = true;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("SpawnDelay");
    }

    public void Play()
    {
        StartCoroutine("SpawnDelay", isPlay);
    }

    IEnumerator SpawnDelay(bool isPlay)
    {
        while (isPlay)
        {
            if (Random.Range(0, 10) % 2 == 0)
            {
                Instantiate(cubes[0], points[0].position, points[0].rotation);
            }
            else
            {
                Instantiate(cubes[1], points[1].position, points[1].rotation);
            }
            yield return new WaitForSeconds(Random.Range(0.3f, 1.3f));
        }
    }
}
