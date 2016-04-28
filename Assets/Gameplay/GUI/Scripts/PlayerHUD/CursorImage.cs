using UnityEngine;
using System.Collections;

public class CursorImage : MonoBehaviour {

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        
    }
    void OnMouseEnter() {
    }
    void OnMouseExit() {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }


    /*
    texture    The texture to use for the cursor or null to set the default cursor. 
                Note that a texture needs to be imported with "Read/Write enabled" in the texture importer (or using the "Cursor" defaults),
                in order to be used as a cursor.
    hotspot     The offset from the top left of the texture to use as the target point (must be within the bounds of the cursor).
    cursorMode  Allow this cursor to render as a hardware cursor on supported platforms, or force software cursor.
    */

}
