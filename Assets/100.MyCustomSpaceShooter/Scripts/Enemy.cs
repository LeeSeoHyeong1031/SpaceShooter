using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public int health;

	private void OnEnable()
	{
		health = 2;
	}
	public void takeDamage()
	{
		--health;
		if(health <= 0)
		{
			health = 0;
			gameObject.SetActive(false);
		}
	}
}
