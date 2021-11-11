using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functionality : MonoBehaviour
{
    [SerializeField] GameObject m_Board;
    void Start()
    {
        m_Board.transform.localPosition = new Vector3(0,0,0);
        Debug.Log("x:  " + (int)m_Board.transform.localPosition.x + " y:" + (int)m_Board.transform.localPosition.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // You pass the array corresponding to the map and spawns game objects accordingly
    void GenerateTiles(int[,] map , int x, int y ) 
    {
        
    }


}
