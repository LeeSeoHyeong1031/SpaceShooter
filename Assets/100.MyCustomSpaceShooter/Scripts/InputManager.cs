using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float boundaryleftSize = -11f;
    public float boundaryrightSize = 11f;
    public float boundaryUpSize = 4.5f;
    public float boundaryDownSize = -4.5f;

    private Vector3 dir = Vector3.zero;
    private Player player;
	private void Awake()
	{
        player = FindObjectOfType<Player>();
	}


	void Update()
    {
        if (Input.GetKey("r")) { if (player.dead == true) ReStart(); }
        InputCheck();
        dir.x = Input.GetAxis("Horizontal");
        dir.y = Input.GetAxis("Vertical");
        dir = dir.normalized;

        transform.Translate(dir * Time.deltaTime * moveSpeed);
    }

    private void InputCheck()
    {
        if (transform.position.x < boundaryleftSize)
        {
            transform.position = new Vector3(boundaryleftSize, transform.position.y);
        }
        else if (transform.position.x > boundaryrightSize)
        {
            transform.position = new Vector3(boundaryrightSize, transform.position.y);
        }
        else if(transform.position.y < boundaryDownSize)
        {
            transform.position = new Vector3(transform.position.x, boundaryDownSize);
        }
        else if (transform.position.y > boundaryUpSize)
        {
            transform.position = new Vector3(transform.position.x, boundaryUpSize);
        }
    }

    public static void ReStart()
    {
        SceneManager.LoadScene("SpaceShooter");
    }
}
