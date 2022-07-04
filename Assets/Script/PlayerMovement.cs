using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 5f;
	public float jumpspeed = 5f;
	private float movement = 0f;
	private Rigidbody2D rigidBody;
	public Transform cekTanah;
	public LayerMask layerTanah;
	public float cekTanahRadius;
	public bool nyentuhTanah;
	private Animator animator;
	public bool animasiJalan;
    public Vector2 respawnPoint;
	float dirX;

	public AudioSource audioCheckpoint, audioJump, audioJalan, audioLawan, audioKoin;
	
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
		dirX = Input.GetAxis ("Horizontal") * speed;
		nyentuhTanah = Physics2D.OverlapCircle(cekTanah.position, cekTanahRadius, layerTanah);
		animasiJalan = false;
		
		// UnityEngine.Debug.Log(movement);
		if (movement > 0)
		{
			rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
			animasiJalan = true;
			transform.localScale = new Vector2(3.626023f, 3.626023f);
		} 
		else if (movement < 0)
		{
			rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
			animasiJalan = true;
			transform.localScale = new Vector2(-3.626023f, 3.626023f);
		}
		
		if(Input.GetButtonDown("Jump") && nyentuhTanah)
		{
			rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpspeed);
			audioJump.Play();
		}
		
		// if(Input.GetButtonDown("Horizontal") && nyentuhTanah)
		// {
		// 	audioJalan.Play();
		// }

		if (rigidBody.velocity.x != 0)
			animasiJalan = true;
		else
			animasiJalan = false;

		if (animasiJalan) {
			if (!audioJalan.isPlaying)
			audioJalan.Play ();
		}
		else
			audioJalan.Stop ();

		//animator.SetFloat("Kecepatan", Mathf.Abs(rigidBody.velocity.x));
		animator.SetBool("OnGround", nyentuhTanah);
		animator.SetBool("IsRun", animasiJalan);
    }
	
	void FixedUpdate(){
		rigidBody.velocity = new Vector2 (dirX, rigidBody.velocity.y);
	}

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "FallDetector"){
            transform.position = respawnPoint;
			audioLawan.Play();
        }
        if (other.tag == "Checkpoint"){
            respawnPoint = other.transform.position;
			audioCheckpoint.Play();
        }
        if (other.tag == "Koin"){
			audioKoin.Play();
        }
    }

}
