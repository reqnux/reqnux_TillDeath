using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

	public const float mapSizeX = 25.5999996f;
	public const float mapSizeY = 20.733f;

    [SerializeField] float xMovementRange, yMovementRange = 0; // Player movement boundaries

    public float XMovementRange 
    {
        get {return xMovementRange; }
    }

    public float YMovementRange 
    {
        get {return yMovementRange; }
    }

}
