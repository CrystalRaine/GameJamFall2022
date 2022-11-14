using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class StartTutorial : MonoBehaviour
{
    float counter = 100;
    void Update()
    {
        counter--;
        var player = gameObject.GetComponent<VideoPlayer>();
        if (!player.isPlaying && counter <= 0)
            SceneManager.LoadScene("Tutorial");
    }
}
