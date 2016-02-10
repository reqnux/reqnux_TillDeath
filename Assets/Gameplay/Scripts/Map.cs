using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

    public float XMovementRange 
    {
        get {return xMovementRange; }
    }

    public float YMovementRange 
    {
        get {return yMovementRange; }
    }

    [SerializeField]
    private float xMovementRange, yMovementRange; // Player movement boundaries
}
