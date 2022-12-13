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
        paths = new List<string>{ };//�t�@�C����path��������

        foreach (var file in Directory.GetFiles(Application.streamingAssetsPath + "/pictures"))//StreamingAssets/pictures���̃t�@�C����path��T��
        {
            if (!file.EndsWith(".meta"))//.meta�͏��O
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
 * �f�[�^�ǂݍ���
 * Map����
 * �T�C�Y����
 * �f�[�^�`��
 */