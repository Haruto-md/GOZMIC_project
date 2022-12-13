using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public string videoPath;
    [SerializeField]private GameObject videoScreen;
    [SerializeField] private GameObject video;
    [SerializeField] private float exhibitionSize;

    // Start is called before the first frame update
    private void Start()
    {
        video.GetComponent<IExhibitable>().getData(videoPath);
        video.GetComponent<IExhibitable>().setExhibitionSize(exhibitionSize);
    }

}
/*
 * データ読み込み
 * Map生成
 * サイズ調整
 * データ描画
 */