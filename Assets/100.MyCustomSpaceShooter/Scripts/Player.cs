using System.Collections;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
	public GameObject gameOverMessage;
	public int playerHealth;
	public bool isTakeDamage = false; //데미지를 받는 중인지.
	public bool dead = false;

	private SpriteRenderer playerRenderer;
	private SpriteRenderer[] hearts;
	private Color originalColor;
	public GameObject playerHearts;
	private Color originalHeartColor;

	public void Awake()
	{
		playerHealth = 3;
		playerRenderer = GetComponentInChildren<SpriteRenderer>();
		originalColor = playerRenderer.color; // 원래 색상을 저장
		hearts = playerHearts.GetComponentsInChildren<SpriteRenderer>();
		originalHeartColor = Color.red;

		Time.timeScale = 1.0f;
		
	}

	public void takeDamage()
	{
		isTakeDamage = true;
		--playerHealth;
		if(playerHealth == 2) hearts[0].color = Color.white;
		if(playerHealth == 1) hearts[1].color = Color.white;
		if(playerHealth == 0) hearts[2].color = Color.white;
		if (playerHealth <= 0)
		{
			playerHealth = 0;
			dead = true;
			GameOver();
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		//트리거에 닿아도 깜빡이는 동안은 데미지를 입으면 안됌.
		if (isTakeDamage == true) return;
		StartCoroutine(BlinkPlayer()); // 데미지를 받으면 깜빡이는 코루틴 실행
		takeDamage();
	}

	public void GameOver()
	{
		gameOverMessage.SetActive(true);
		Time.timeScale = 0f;
	}

	// 깜빡이는 효과를 주는 코루틴
	private IEnumerator BlinkPlayer()
	{
		int blinkCount = 3; // 3번 깜빡이도록 설정
		float blinkDuration = 0.2f; // 한 번 깜빡이는 시간

		for (int i = 0; i < blinkCount; i++)
		{
			// 투명하게 변경
			Color blinkColor = originalColor;
			blinkColor = Color.red; //빨간색 설정
			blinkColor.a = 0.5f; // 투명도 50%로 설정
			playerRenderer.color = blinkColor;

			// 잠깐 대기
			yield return new WaitForSeconds(blinkDuration);

			// 원래 색상으로 복귀
			playerRenderer.color = originalColor;

			// 다시 잠깐 대기
			yield return new WaitForSeconds(blinkDuration);
		}
		isTakeDamage = false; //깜빡이는게 끝났으면 false
	}
}
