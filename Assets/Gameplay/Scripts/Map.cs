using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

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
