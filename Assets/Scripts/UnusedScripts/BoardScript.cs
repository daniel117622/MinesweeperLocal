using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BoardScript : MonoBehaviour
{


    int Vertical,Horizontal,Columns,Rows;
    public Sprite empty,mine;
    public int[,] Grid ;
    public Transform m_Board;

    [SerializeField] private float cellScale = 0.2f;

    private GameObject[] cellData = new GameObject[16*16];

    // Start is called before the first frame update
    void Start()
    {

        Columns = 16;
        Rows = 16;
        Grid = new int[Columns,Rows];
        for (int i = 0 ; i < Columns ; i++)
        {
            for (int j = 0 ; j < Rows ;  j++) 
            {
                Grid[i,j] = Random.Range(0,10);
                cellData[i*8 + j] = SpawnTile(i,j,Grid[i,j]);
            }
        }
        
    }

    // Called when a serialized variable changes
    void OnValidate()
    {
        for (int i = 0 ; i < 16*16 ; i++)
        {
            if (cellData[i].CompareTag("Empty"))
            cellData[i].transform.localScale = new Vector3(cellScale,cellScale,cellScale);
        }
    }

    GameObject SpawnTile(float x,float y,float value)
    {

        if (value <= 8) // Set a empty in this case
        {
            GameObject Empty = new GameObject("Mine x: " + x + " y: "  + y );
            Empty.transform.SetParent(m_Board);
            Empty.transform.localPosition = new Vector3 (x - (Horizontal) + 0.5f,y - (Vertical) + 0.5f);
            //Empty.tag = "Empty";

            var es = Empty.AddComponent<SpriteRenderer>();
            es.sprite = empty;

            return Empty;
        }
        else
        {
            GameObject Mine = new GameObject("Mine x: " + x + " y: "  + y );
            Mine.transform.SetParent(m_Board);
            //Mine.tag = "Mine";


            Mine.transform.localPosition = new Vector3 (x - (Horizontal) + 0.5f,y - (Vertical) + 0.5f);
            Mine.transform.localScale = new Vector3(cellScale,cellScale,cellScale);
         
            var ms = Mine.AddComponent<SpriteRenderer>();            
            ms.sprite = mine;
            return Mine;
        }

    }

}
