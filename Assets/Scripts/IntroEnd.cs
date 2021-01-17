using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroEnd : MonoBehaviour
{
    public bool end = false;
    public float timeToEnd = 23.25f;
    public float time = 0f;
    void Start()
    {
       
    }

    void Update()
    {
        time += Time.deltaTime;
       if(time >= timeToEnd)
       {
           end = true;
       }
        if(end == true)
        {
           SceneManager.LoadScene(1);
        }
    }
}
