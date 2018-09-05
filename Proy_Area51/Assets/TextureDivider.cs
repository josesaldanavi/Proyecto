using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextureDivider : MonoBehaviour
{
    private System.Random _random = new System.Random();
    public Texture2D source;
    public int rows;
    public int columns;
    public float scale = 100f;

    public GameObject piecePrefab;
    public GameObject slotPrefab;

    public Puzzle rootParent;
    [Range(0.0f, 1f)]
    public float imageScale;

    public Transform slotParent;

    // Use this for initialization
    void Start()
    {

        GameObject spritesRoot = GameObject.Find("SpritesRoot");

        float spriteHeight = source.height;
        float spriteWidth = source.width;

        float columnSize = spriteHeight / columns;
        float rowSize = spriteWidth / rows;

        float columnUnits = columnSize / scale;
        float rowSUnits = rowSize / scale;

        float heightUnits = spriteHeight / scale;
        float widthUnits = spriteWidth / scale;

        Debug.Log("Sprite height: " + spriteHeight);
        Debug.Log("Sprite widht: " + spriteWidth);

        float ratio = spriteWidth / spriteHeight;

        float xRescale = imageScale;
        float yRescale = imageScale*Camera.main.aspect;

        int[] shuffledArray = new int[rows * columns];

        for (int i = 0; i < rows * columns;i++ )
        {
            shuffledArray[i] = i;
        }
        Shuffle(shuffledArray);
        if (ratio > 1)
        {
            yRescale /= ratio;
        }
        else
        {
            xRescale *= ratio;
        }

        GameObject[] slots = new GameObject[rows * columns];

        rootParent.pieces = new Piece[rows * columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                //Slot
                GameObject s = GameObject.Instantiate(slotPrefab);
                RectTransform slotTransform = s.GetComponent<RectTransform>();
                s.transform.parent = slotParent;
                slots[i * columns + j] = s;

                slotTransform.anchorMin = (new Vector2((1 - xRescale) / 2 + xRescale * (i * 1f / rows), (1 - yRescale) / 2 + yRescale * (j * 1f / columns)));
                slotTransform.anchorMax = (new Vector2((1 - xRescale) / 2 + xRescale * ((i + 1f) / rows), (1 - yRescale) / 2 + yRescale * ((j + 1f) / columns)));
                slotTransform.offsetMax = Vector2.zero;
                slotTransform.offsetMin = Vector2.zero;
            }
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                //Sprite newSprite = Sprite.Create(source, new Rect(i * rowSize, j * columnSize, rowSize, columnSize), new Vector2(0, 0), scale);
                //GameObject n = new GameObject();
                //SpriteRenderer sr = n.AddComponent<SpriteRenderer>();
                //sr.sprite = newSprite;
                //n.transform.position = new Vector3(i * rowSUnits - widthUnits / 2, j * columnUnits - heightUnits / 2, 0);
                //n.transform.parent = spritesRoot.transform;

                //Piece 
                Sprite newSprite = Sprite.Create(source, new Rect(i * rowSize, j * columnSize, rowSize, columnSize), new Vector2(0, 0), scale);
                GameObject n = GameObject.Instantiate(piecePrefab);
                Image sr = n.GetComponent<Image>();
                sr.sprite = newSprite;
                RectTransform recTransform = n.GetComponent<RectTransform>();

                //if (ratio > 0)
                
                Piece piece = n.GetComponent<Piece>();

                piece.id = i * columns + j;
                piece.rootParent = rootParent;
                rootParent.pieces[i * columns + j] = piece;
                //n.transform.position = new Vector3(i * rowSUnits - widthUnits / 2, j * columnUnits - heightUnits / 2, 0);
                n.transform.parent = rootParent.transform;



                if (true)
                {
                    int shuffledI = shuffledArray[i * columns + j] / columns;
                    int shuffledJ = shuffledArray[i * columns + j] % columns;
                    recTransform.anchorMin = (new Vector2((1 - xRescale) / 2 + xRescale * (shuffledI * 1f / rows), (1 - yRescale) / 2 + yRescale * (shuffledJ * 1f / columns)));
                    recTransform.anchorMax = (new Vector2((1 - xRescale) / 2 + xRescale * ((shuffledI + 1f) / rows), (1 - yRescale) / 2 + yRescale * ((shuffledJ + 1f) / columns)));
                    recTransform.offsetMax = Vector2.zero;
                    recTransform.offsetMin = Vector2.zero;

                    n.transform.parent = slots[shuffledArray[i * columns + j]].transform;
                }

                
            }
        }
    }

    void Shuffle(int[] array)
    {
        int p = array.Length;
        for (int n = p - 1; n > 0; n--)
        {
            int r = _random.Next(1, n);
            int t = array[r];
            array[r] = array[n];
            array[n] = t;
        }
    }
}