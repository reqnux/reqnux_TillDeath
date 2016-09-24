using UnityEngine;
using System.Collections;

public class PlayerController : UnitMovement {

    private float horizontalMovement;
    private float verticalMovement;
    private Player player;
    private Rigidbody2D playerRigidbody;
    private Map map;

    void Awake () 
    {
        player = GetComponent<Player> ();
        playerRigidbody = GetComponent<Rigidbody2D> ();
        map = GameObject.FindObjectOfType<Map>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }

    void Update() 
    {
        if (Input.GetKey (KeyCode.Mouse0))
            player.CurrentWeapon.shoot();
        
        if (Input.GetKeyDown (KeyCode.R))
            player.CurrentWeapon.reload();
    }

    protected override void move() 
    {
        if (Input.GetAxis ("Horizontal") != 0)
            horizontalMovement = Input.GetAxis ("Horizontal") / Mathf.Abs(Input.GetAxis ("Horizontal"));
        else
            horizontalMovement = 0;
        
        if (Input.GetAxis ("Vertical") != 0)
            verticalMovement = Input.GetAxis("Vertical")/Mathf.Abs(Input.GetAxis("Vertical"));
        else
            verticalMovement = 0;

        playerRigidbody.velocity = new Vector2(horizontalMovement,verticalMovement).normalized *player.Stats.MovementSpeed/10;
        playerRigidbody.position = new Vector2 (Mathf.Clamp (playerRigidbody.position.x, -map.XMovementRange, map.XMovementRange),
                                                Mathf.Clamp (playerRigidbody.position.y, -map.YMovementRange, map.YMovementRange));
        lookAtTarget(Camera.main.ScreenToWorldPoint (Input.mousePosition));
    }
}