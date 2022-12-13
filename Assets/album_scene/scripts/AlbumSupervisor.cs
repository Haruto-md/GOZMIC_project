using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AlbumSupervisor : MonoBehaviour
{
    private List<string> paths;
    private GameObject[] exhibitionObjects;
    public GameObject panelPrefab;
    public GameObject frame;
    public GameObject distributer;
    private int count=0;

    // Start is called before the first frame update
    private void Start()
    {
        paths = new List<string>{ };//ファイルのpathを初期化

        foreach (var file in Directory.GetFiles(Application.streamingAssetsPath + "/pictures"))//StreamingAssets/pictures内のファイルのpathを探索
        {
            if (!file.EndsWith(".meta"))//.metaは除外
            {
                paths.Add(file);
            }
        }
        exhibitionObjects = new GameObject[paths.Count];
        int i = 0;
        foreach (var path in paths)
        {
            exhibitionObjects[i] = Instantiate(panelPrefab, frame.transform);
            exhibitionObjects[i].gameObject.SetActive(false);
            exhibitionObjects[i].gameObject.GetComponent<IExhibitable>().getData(path);
            i++;
        }
    }
    public void refreshAlbum()
    {
        distributer.GetComponent<ExhibitionDistributer>().exhibitObjectsOnMap(frame,count%5+1);
        count++;
    }
}
/*
 * データ読み込み
 * Map生成
 * サイズ調整
 * データ描画
 */