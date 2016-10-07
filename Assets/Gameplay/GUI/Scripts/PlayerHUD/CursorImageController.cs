using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CursorImageController : MonoBehaviour {

    public Texture2D defaultCursorTexture;
	public Texture2D aimingCursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 defaultCursorHotSpot = Vector2.zero;
	public Vector2 aimingCursorHotSpot = new Vector2(12.5f,12.5f);

	void Awake() {
		setAimingCursor ();
    }

    void OnMouseEnter() {
    }
    void OnMouseExit() {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
	void OnDestroy() {
		setDefaultCursor ();
	}

	public void setAimingCursor() {
		Cursor.SetCursor(aimingCursorTexture, aimingCursorHotSpot, cursorMode);
	}
	public void setDefaultCursor() {
		Cursor.SetCursor(defaultCursorTexture, defaultCursorHotSpot, cursorMode);
	}


    /*
    texture    The texture to use for the cursor or null to set the default cursor. 
                Note that a texture needs to be imported with "Read/Write enabled" in the texture importer (or using the "Cursor" defaults),
                in order to be used as a cursor.
    hotspot     The offset from the top left of the texture to use as the target point (must be within the bounds of the cursor).
    cursorMode  Allow this cursor to render as a hardware cursor on supported platforms, or force software cursor.
    */

}
