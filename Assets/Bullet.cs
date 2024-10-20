using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 5f; // 총알 속도

	void Update()
	{
		// 매 프레임마다 y축으로 속도만큼 이동
		transform.position += Vector3.up * speed * Time.deltaTime;

		if (transform.position.y > 10f) // y축이 10 이상이면 비활성화
		{
			gameObject.SetActive(false);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//부딪힌 콜라이더 태그가 Enemy라면
		if (collision.CompareTag("Enemy"))
		{
			//콜라이더의 Enemy 컴포넌트를 얻고 거기에 있는 takeDamage호출
			collision.GetComponent<Enemy>().takeDamage();
		}
	}
}

