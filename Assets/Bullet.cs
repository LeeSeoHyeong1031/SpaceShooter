using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 5f; // �Ѿ� �ӵ�

	void Update()
	{
		// �� �����Ӹ��� y������ �ӵ���ŭ �̵�
		transform.position += Vector3.up * speed * Time.deltaTime;

		if (transform.position.y > 10f) // y���� 10 �̻��̸� ��Ȱ��ȭ
		{
			gameObject.SetActive(false);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//�ε��� �ݶ��̴� �±װ� Enemy���
		if (collision.CompareTag("Enemy"))
		{
			//�ݶ��̴��� Enemy ������Ʈ�� ��� �ű⿡ �ִ� takeDamageȣ��
			collision.GetComponent<Enemy>().takeDamage();
		}
	}
}

