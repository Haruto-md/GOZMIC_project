using System.IO;
using UnityEngine;

public class Picture : MonoBehaviour, IExhibitable
{
    public Sprite sprite;
    [SerializeField] private string testPath;
    [SerializeField] private float spriteHeight;
    [SerializeField] private float spriteWidth;
    [SerializeField] private float spriteSize;

    private void Start()
    {
        //gameObject.SetActive(false);
    }

    public void getData(string path)
    {
        using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            BinaryReader bin = new BinaryReader(fileStream);
            byte[] values = bin.ReadBytes((int)bin.BaseStream.Length);
            bin.Close();
            Texture2D texture = new Texture2D(1, 1);
            texture.LoadImage(values);

            sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            GetComponent<SpriteRenderer>().sprite = sprite;
            spriteHeight = sprite.bounds.size.y;
            spriteWidth = sprite.bounds.size.x;
            spriteSize = Mathf.Max(spriteHeight,spriteWidth);
        }

    }

    public void setExhibitionSize(float exhibitionSize)
    {
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(exhibitionSize/ spriteSize/10, exhibitionSize/ spriteSize/10, 1f);
    }
}