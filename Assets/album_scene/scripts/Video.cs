using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Video;

public class Video : MonoBehaviour, IExhibitable
{
    private VideoPlayer videoPlayer;
    [SerializeField] private float width;

    private void Start()
    {

    }

    public void getData(string path)
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.url = path;
        videoPlayer.Prepare();
    }

    public void setExhibitionSize(float exhibitionSize)
        /*
         * exhibitionSize��parent�Ƃ̑��Βl�ł���B�҂����荇�킹�����̂ł���΁A 1 �ƂȂ�B         
         */
    {
        width = exhibitionSize;
        transform.localScale = new Vector3(width,width*9f/16f,1f);
    }
}
