using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refresh_Button : MonoBehaviour, IButtonObject
{
    public GameObject supervisor;
    public void OnClick()
    {
        supervisor.GetComponent<AlbumSupervisor>().refreshAlbum();
    }
    private void OnMouseDown()
    {
        OnClick();
    }
}
