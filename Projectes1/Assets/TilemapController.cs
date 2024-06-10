using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapController : MonoBehaviour
{

    public Tilemap windows;
    private Collider2D tileCollider;
    // Start is called before the first frame update
    void Start()
    {
        tileCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetTilePos(Vector2 worlPos)
    {
        
   
            Vector3Int originCell = windows.WorldToCell(worlPos);
            Debug.Log(originCell);

        
    }
}
