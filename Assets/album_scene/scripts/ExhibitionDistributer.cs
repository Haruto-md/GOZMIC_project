using UnityEngine;

public class ExhibitionDistributer : MonoBehaviour
{
    private float frameWidth;
    private float frameHeight;
    [SerializeField] private int columns = 3;
    [SerializeField] private float sizeRate=1f;

    public GameObject frame;

    public float exhibitionSize;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            exhibitObjectsOnMap(frame, columns);
        }
    }

    public Vector3[] mapGeneration(int col,int exhibitionNum)
    {
        float frameWidth = frame.GetComponent<Renderer>().bounds.size.x;
        float frameHeight = frame.GetComponent<Renderer>().bounds.size.y;
        exhibitionSize = sizeRate*frameWidth/col;

    Vector3[] map = new Vector3[exhibitionNum];

        float blockDistance= frameWidth/col;
        for (int i = 0; i < exhibitionNum; i++)
        {
            map[i] = frame.transform.position + new Vector3(-frameWidth/2 + blockDistance / 2 + (i%col)* blockDistance,  frameHeight /2 - blockDistance / 2 - blockDistance * (i-i%col)/col, -0.1f);
        }
        return map;
    }

    public void exhibitObjectsOnMap(GameObject parentObject,int col)
    {
        Transform[] objectsInFrame = parentObject.GetComponentsInChildren<Transform>(true);
        int objectNum = objectsInFrame.Length-1;//親オブジェクトの分を省く
        var map = mapGeneration(col,objectNum);

        int i=-1;
        foreach (var exhibitionTransform in objectsInFrame)
        {
            if (0 <= i)
            {
                var exhibitionObject = exhibitionTransform.gameObject;
                exhibitionObject.gameObject.transform.position = map[i];
                exhibitionObject.GetComponent<IExhibitable>().setExhibitionSize(exhibitionSize);
                exhibitionObject.gameObject.SetActive(true);
            }
            i++;

        }
    }

}
