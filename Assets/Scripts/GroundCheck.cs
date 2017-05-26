using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

    private PlayerControls player;

	
	void Start ()
    {
        player = gameObject.GetComponentInParent<PlayerControls>();
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        player.Grounded = true;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        player.Grounded = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        player.Grounded = false;
    }
}
