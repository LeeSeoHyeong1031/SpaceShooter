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
            //transform : 이 컴포넌트가 부착된 오브젝트의 Transfrom 컴포넌트
            //Transform.Translate : 현재 position에서 파라미터의 Vector값 만큼 Position을 이동
            //Vector3.down : new Vector(0,-1,0)
            transform.Translate(Vector3.down * Time.deltaTime * flowSpeed);
            if (transform.position.y < -7.5f)
            {
                transform.position = Vector3.zero;
            }
        }
    }