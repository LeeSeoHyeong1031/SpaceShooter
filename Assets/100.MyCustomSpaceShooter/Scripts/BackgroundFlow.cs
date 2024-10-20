using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class BackgroundFlow : MonoBehaviour
    {
        public float flowSpeed;
        void Start()
        {

        }

        void Update()
        {
            //transform : �� ������Ʈ�� ������ ������Ʈ�� Transfrom ������Ʈ
            //Transform.Translate : ���� position���� �Ķ������ Vector�� ��ŭ Position�� �̵�
            //Vector3.down : new Vector(0,-1,0)
            transform.Translate(Vector3.down * Time.deltaTime * flowSpeed);
            if (transform.position.y < -7.5f)
            {
                transform.position = Vector3.zero;
            }
        }
    }