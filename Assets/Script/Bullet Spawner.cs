using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;    //생성할 탄알의 원본 프리팹
    public float spawnRateMin = 0.5f;  //최소 생성 주기
    public float spawnRateMax = 3f;    //퇴대 생성 주기

    private Transform target;    //발사할 대상
    private float spawnRate;     //생성 주기
    private float timeAfterspawn;  // 최근 생성 시점에서 지난 시간
    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        // 최근 생성 이후의 누적 시간을 0으로 초기화
        timeAfterspawn = 0f;
        // 탄알 생성 간격을 spawnRateMin과 spawnRateMax 사이에서 랜덤 저장
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        //playerController 컴포넌트를 가진 게임 오브젝트를 찾아 조준 대상으로 설정
        target = FindObjectOfType<PlayerController>().transform;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // timeAfterspawn 갱신
        timeAfterspawn += Time.deltaTime;

        // 최신 생성 시점에서부터 누적된 시간이 생성 추가보다 크거나 같다면
        if(timeAfterspawn>=spawnRate)
        {
            //누적된 시간을 리셋
            timeAfterspawn = 0f;

            // bulletPrefab의 복제본을
            // transform.position 위치와 transform.rotation 회전으로 생성
            GameObject bullet
                = Instantiate(bulletPrefab, transform.position, transform.rotation);

            //생성된 bullet 게임 오브젝트의 정면 방향이 target을 향하도록 회전
            bullet.transform.LookAt(target);

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);

            // 포탄 발사 사운드 재생 코드 추가
            audioSource.Play();
        }
    }
}
