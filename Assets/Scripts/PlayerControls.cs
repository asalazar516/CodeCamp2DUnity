using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour {

    public float maxSpeed = 3;
    public float Speed = 50f;
    public float JumpPwr = 150f;

    public bool Grounded;

    public int points;
    public Text pointText;

    private Rigidbody2D rg2d;
    private Animator Anim;

	// Use this for initialization
	void Start ()
    {
        rg2d = gameObject.GetComponent<Rigidbody2D>();
        Anim = gameObject.GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        Anim.SetBool("Grounded", Grounded);
        Anim.SetFloat("Speed", Mathf.Abs(rg2d.velocity.x));
		
        if(Input.GetAxis("Horizontal") < 0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if(Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        //Jumping
        if (Input.GetButtonDown("Jump") && Grounded == true)
        {
            rg2d.AddForce(Vector2.up * JumpPwr);
        }
	}

    void FixedUpdate()
    {
        Vector3 easeVelocity = rg2d.velocity;
        easeVelocity.y = rg2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;

        float h = Input.GetAxis("Horizontal");

        //Fix friction by easing the x speed of player
        if (Grounded == true)
        {
            rg2d.velocity = easeVelocity;
        }

        //Player movement
        rg2d.AddForce((Vector2.right * Speed) * h);

        //Limiting the Player's speed
        if(rg2d.velocity.x > maxSpeed)
        {
            rg2d.velocity = new Vector2(maxSpeed, rg2d.velocity.y);
        }

        if(rg2d.velocity.x < -maxSpeed)
        {
            rg2d.velocity = new Vector2(-maxSpeed, rg2d.velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Coin"))
        {
            Destroy(col.gameObject);
            points += 100;
            setCountText();
            
        }
    }

    void setCountText()
    {
        pointText.text = "Score: " + points.ToString();
       
    }

    public void NextLevel(int x)
    {
        SceneManager.LoadScene(x);
    }
}
