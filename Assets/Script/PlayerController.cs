using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidBody; //이동에 사용할 리지드 바디 컴포넌트
    public float speed = 8f; //이동 속력
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody.GetComponent<Rigidbody>();

        audioSource =GameObject.Find("Die Sound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // 수평축과 수직충의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float ZInput = Input.GetAxis("Vertical");

        // 실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = ZInput * speed;

        //Vector3 속도를 (zSpeed, 0, zSpeed)로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        //리지드 바디의 속도에 newVelocity할당
        playerRigidBody.velocity = newVelocity;

    }
    public void Die()
    {
        Debug.Log("다이 함수 호출");
        // 자신의 게임 오브젝트를 비활성화
        gameObject.SetActive(false);

        //씬에 존재하는 GameManager 타입의 오브젝트를 찾아서 가져오기
        GameManager gamemanager = FindObjectOfType<GameManager>();
        //가져온 GameManager 오브젝트의 EndGame() 메서드 실행
        gamemanager.EndGame();

        // 죽는 사운드
        audioSource.Play();
    }
}