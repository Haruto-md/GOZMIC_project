using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataImporter : MonoBehaviour,IDataImporter
{
    public void importDataFromFolders(){

    }
    
    public string[] selectDownloadingFolder(){
        return new string[2]{"",""};
    }
}

public interface IDataImporter
{
    void importDataFromFolders();
}