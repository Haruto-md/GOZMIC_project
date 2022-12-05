using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AlbumSupervisor : MonoBehaviour
{
    private List<string> paths = new List<string>{ };
    private GameObject[] exhibitionObjects;
    public GameObject panelPrefab;
    public GameObject frame;
    public GameObject distributer;
    private int count=0;

    // Start is called before the first frame update
    public void Start()
    {
;        foreach (var file in Directory.GetFiles(Application.streamingAssetsPath + "/pictures"))
        {
            if (!file.EndsWith(".meta"))
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
        paths = new List<string> { };
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