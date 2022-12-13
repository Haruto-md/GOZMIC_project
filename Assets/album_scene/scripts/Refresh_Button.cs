using UnityEngine;

public class Refresh_Button : MonoBehaviour, IButtonObject
{
    public GameObject supervisor;
    public void OnMouseDown()
    {
        supervisor.GetComponent<AlbumSupervisor>().refreshAlbum();
    }
}
