using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int level = 1;
    public float nextTime;
    public TextMeshPro levelUI;
    void Start()
    {
        nextTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //10초마다 소환
        if (Time.time >= nextTime) 
        {
            Wave();
            nextTime = Time.time + 5;
        }
    }
    public void Wave()
    {
        levelUI.text = $"Level {level}";
		int spawnCount = Mathf.RoundToInt(level * 2.5f);

		Spawn(spawnCount);
		level++;
	}

    public void Spawn(int count)
    {
        int x;
        int y;
        for (int i = 0; i < count; i++)
		{
            x = Random.Range(-11,12); //-11~11
            y = Random.Range(10,30);
            //켜진 오브젝트가 원하는 count만큼 담아짐.
			GameObject enemy = PoolManager.instance.ActivateObj(0);
            //위치잡아주기
            enemy.transform.position = new Vector3(x,y,0);
            enemy.transform.rotation = Quaternion.identity;
            //레벨에따른 속도 조정
            if (level == 2) enemy.GetComponent<Rigidbody2D>().gravityScale = 0.2f;
            else if (level == 3) enemy.GetComponent<Rigidbody2D>().gravityScale = 0.3f;
            else if (level == 4) enemy.GetComponent<Rigidbody2D>().gravityScale = 0.4f;
            else if (level >= 5) enemy.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
		}
	}
}
