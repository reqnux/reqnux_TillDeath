using UnityEngine;
using System.Collections;

public class PlayerController : UnitMovement {

    private float horizontalMovement;
    private float verticalMovement;
    private Player player;
    private Rigidbody2D playerRigidbody;

    // Use this for initialization
    void Start () {
        player = GetComponent<Player> ();
        playerRigidbody = GetComponent<Rigidbody2D> ();
    }

    void Update() {
        if (Input.GetKey (KeyCode.Mouse0)) {
            player.CurrentWeapon.shoot();
        }
        if (Input.GetKey (KeyCode.R)) {
            player.CurrentWeapon.reload();
        }
    }

    protected override void move() {
        // getAxis returns values from -10 to 10

        if (Input.GetAxis ("Horizontal") != 0) {
            horizontalMovement = Input.GetAxis ("Horizontal") / Mathf.Abs(Input.GetAxis ("Horizontal"));
        } else {
            horizontalMovement = 0;
        }
        if (Input.GetAxis ("Vertical") != 0) {
            verticalMovement = Input.GetAxis("Vertical")/Mathf.Abs(Input.GetAxis("Vertical"));
        } else {
            verticalMovement = 0;
        }

        playerRigidbody.velocity = new Vector2(horizontalMovement,verticalMovement).normalized *(player.Stats.MovementSpeed);
        //playerRigidbody.position = new Vector2 (Mathf.Clamp (playerRigidbody.position.x, Mapa.xMin, Mapa.xMax),
        //    Mathf.Clamp (playerRigidbody.position.y, Mapa.yMin, Mapa.yMax));
        lookAtTarget(Camera.main.ScreenToWorldPoint (Input.mousePosition));

    }
}