using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f; //탄알의 속력
    private Rigidbody bulletRigidbody; //탄알에 사용되는 물리 컴포넌트를 연결할 변수 

    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed;              // transform.foward = vector3(0f, 0f, 0f);
        

        Destroy(gameObject, 3.0f);       //3초 뒤에 자신을 파괴
    }

    // 트리거 충돌 시 자동으로 실행되는 메서드
    private void OnTriggerEnter(Collider other)
    { 

            //충돌한 상대방 게임 오브젝트가 Player 태그를 가진 경우
            if (other.tag == "Player")
        {
            // 상대방 게임 오브젝트에서 PlayerController 컴포넌트 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();

            // 상대방으로 부터 PlayerController 컴포넌트를 가져오는 데 성공했다면
            if (playerController != null)
            {
                // 상대방 PlayerController 컴포넌트의 Die() 메서드 실행
                playerController.Die();
            }
        }
  }



    // Update is called once per frame
    void Update()
    {
        
    }
}
