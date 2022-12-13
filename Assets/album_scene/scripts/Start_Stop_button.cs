using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Start_Stop_button : MonoBehaviour
{
    [SerializeField] private GameObject video;
    // Start is called before the first frame update
    void Start()
    {
        video.GetComponent<VideoPlayer>().Play();
        video.GetComponent<VideoPlayer>().StepForward();
        video.GetComponent<VideoPlayer>().StepForward();
        video.GetComponent<VideoPlayer>().Pause();
    }

    private void OnMouseDown()
    {
        if (video.GetComponent<VideoPlayer>().isPaused)
        {
            video.GetComponent<VideoPlayer>().Play();
        }
        else
        {
            video.GetComponent<VideoPlayer>().Pause();
        }
    }
}
