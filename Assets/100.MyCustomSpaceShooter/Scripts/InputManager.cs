using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float crashEnemy = 500f;

    private Vector2 dir = Vector2.zero;
    private Player player;
    private Rigidbody2D rb2d;
	private void Awake()
	{
        player = FindObjectOfType<Player>();
        rb2d = GetComponent<Rigidbody2D>();
	}


	void Update()
    {
        if (Input.GetKey("r")) { if (player.dead == true) ReStart(); }
        dir.x = Input.GetAxis("Horizontal");
        dir.y = Input.GetAxis("Vertical");
        dir = dir.normalized;
    }
	private void FixedUpdate()
	{
		rb2d.MovePosition(rb2d.position + (dir * Time.deltaTime * moveSpeed));
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
        if (other.CompareTag("Enemy"))
        {
            rb2d.AddForce(Vector2.down * crashEnemy);
        }
	}

	public static void ReStart()
    {
        SceneManager.LoadScene("SpaceShooter");
    }
}
