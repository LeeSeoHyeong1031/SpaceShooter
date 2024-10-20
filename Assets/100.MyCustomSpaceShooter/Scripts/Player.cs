using System.Collections;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
	public GameObject gameOverMessage;
	public int playerHealth;
	public bool isTakeDamage = false; //�������� �޴� ������.
	public bool dead = false;
	public Transform bulletPivot;

	public float attackInterval = 0.5f; //���� ����
	private float lastAttackTime = 0; //������ ���� �ð�

	private SpriteRenderer playerRenderer;
	private SpriteRenderer[] hearts;
	private Color originalColor;
	public GameObject playerHearts;
	private Color originalHeartColor;

	public void Awake()
	{
		playerHealth = 3;
		playerRenderer = GetComponentInChildren<SpriteRenderer>();
		originalColor = playerRenderer.color; // ���� ������ ����
		hearts = playerHearts.GetComponentsInChildren<SpriteRenderer>();
		originalHeartColor = Color.red;

		Time.timeScale = 1.0f;
		
	}

	private void Update()
	{
		//�÷��̾ �׾����� �˻�
		if (!dead)
		{
			//���� �ʾҴٸ� �߻� �õ�.
			Fire();
		}
	}
	//Shoot�Լ��� ȣ���ϱ� ���� �����Լ�
	private void Fire()
	{
		//�� �ð��� ������ ���� �ð����� ũ�ٸ� Shoot�Լ� ȣ��
		if (Time.time >= lastAttackTime)
		{
			StartCoroutine(Shoot());
			lastAttackTime = Time.time + attackInterval; //���� �ð� + ���� ����
		}
	}

	//���� �߻� ����
	private IEnumerator Shoot()
	{
		 GameObject bullet = PoolManager.instance.ActivateObj(1);
		bullet.transform.position = transform.position + Vector3.up;
		yield return null;
	}

	public void takeDamage()
	{
		isTakeDamage = true;
		--playerHealth;
		if(playerHealth == 2) hearts[0].color = Color.white;
		else if(playerHealth == 1) hearts[1].color = Color.white;
		else if (playerHealth <= 0)
		{
			hearts[2].color = Color.white;
			playerHealth = 0;
			dead = true;
			GameOver();
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Enemy"))
		{
			//Ʈ���ſ� ��Ƶ� �����̴� ������ �������� ������ �ȉ�.
			if (isTakeDamage == true) return;
			StartCoroutine(BlinkPlayer()); // �������� ������ �����̴� �ڷ�ƾ ����
			takeDamage();
		}
	}

	public void GameOver()
	{
		gameOverMessage.SetActive(true);
		Time.timeScale = 0f;
	}

	// �����̴� ȿ���� �ִ� �ڷ�ƾ
	private IEnumerator BlinkPlayer()
	{
		int blinkCount = 3; // 3�� �����̵��� ����
		float blinkDuration = 0.2f; // �� �� �����̴� �ð�

		for (int i = 0; i < blinkCount; i++)
		{
			// �����ϰ� ����
			Color blinkColor = originalColor;
			blinkColor = Color.red; //������ ����
			blinkColor.a = 0.5f; // ���� 50%�� ����
			playerRenderer.color = blinkColor;

			// ��� ���
			yield return new WaitForSeconds(blinkDuration);

			// ���� �������� ����
			playerRenderer.color = originalColor;

			// �ٽ� ��� ���
			yield return new WaitForSeconds(blinkDuration);
		}
		isTakeDamage = false; //�����̴°� �������� false
	}
}
