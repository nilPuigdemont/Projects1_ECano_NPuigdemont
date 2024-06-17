using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CursorSet : MonoBehaviour
{
    public Texture2D _cursor;
    void Start()
    {
       
        Cursor.SetCursor(_cursor, Vector2.zero, CursorMode.ForceSoftware);
    }
}
