using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;    //������ ź���� ���� ������
    public float spawnRateMin = 0.5f;  //�ּ� ���� �ֱ�
    public float spawnRateMax = 3f;    //��� ���� �ֱ�

    private Transform target;    //�߻��� ���
    private float spawnRate;     //���� �ֱ�
    private float timeAfterspawn;  // �ֱ� ���� �������� ���� �ð�
    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        // �ֱ� ���� ������ ���� �ð��� 0���� �ʱ�ȭ
        timeAfterspawn = 0f;
        // ź�� ���� ������ spawnRateMin�� spawnRateMax ���̿��� ���� ����
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        //playerController ������Ʈ�� ���� ���� ������Ʈ�� ã�� ���� ������� ����
        target = FindObjectOfType<PlayerController>().transform;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // timeAfterspawn ����
        timeAfterspawn += Time.deltaTime;

        // �ֽ� ���� ������������ ������ �ð��� ���� �߰����� ũ�ų� ���ٸ�
        if(timeAfterspawn>=spawnRate)
        {
            //������ �ð��� ����
            timeAfterspawn = 0f;

            // bulletPrefab�� ��������
            // transform.position ��ġ�� transform.rotation ȸ������ ����
            GameObject bullet
                = Instantiate(bulletPrefab, transform.position, transform.rotation);

            //������ bullet ���� ������Ʈ�� ���� ������ target�� ���ϵ��� ȸ��
            bullet.transform.LookAt(target);

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);

            // ��ź �߻� ���� ��� �ڵ� �߰�
            audioSource.Play();
        }
    }
}
