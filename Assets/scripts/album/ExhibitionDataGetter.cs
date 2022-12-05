using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

public class ExhibitionDataGetter : MonoBehaviour
{
    [SerializeField] private List<string> paths;
    [SerializeField] private GameObject frame;
    [SerializeField] private GameObject panelPrefab;
    [SerializeField] private GameObject[] exhibitionObjects;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            var filePath = EditorUtility.OpenFilePanel("Select File You Want To Add To Album", Application.dataPath,"jpeg");
            if(filePath != "")
            { 
                paths.Add(filePath);
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            var folderPath = EditorUtility.OpenFolderPanel("Select Folder You Want To Add To Album", Application.dataPath, string.Empty);
            if (folderPath != "")
            {
                foreach (var file in Directory.GetFiles(folderPath))
                {
                    if (!file.EndsWith(".meta"))
                    {
                        paths.Add(file);
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            exhibitionObjects = new GameObject[paths.Count];
            int i= 0;
            foreach (var path in paths)
            {
                exhibitionObjects[i] = Instantiate(panelPrefab, frame.transform);
                exhibitionObjects[i].gameObject.SetActive(false);
                exhibitionObjects[i].gameObject.GetComponent<IExhibitable>().getData(path);
                i++;
            }
        }
    }
    //èdï°çÌèúã@î\Çí«â¡ÇµÇΩÇ¢
}