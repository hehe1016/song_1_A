using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidBody; //�̵��� ����� ������ �ٵ� ������Ʈ
    public float speed = 8f; //�̵� �ӷ�
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
        // ������� �������� �Է°��� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal");
        float ZInput = Input.GetAxis("Vertical");

        // ���� �̵� �ӵ��� �Է°��� �̵� �ӷ��� ����� ����
        float xSpeed = xInput * speed;
        float zSpeed = ZInput * speed;

        //Vector3 �ӵ��� (zSpeed, 0, zSpeed)�� ����
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        //������ �ٵ��� �ӵ��� newVelocity�Ҵ�
        playerRigidBody.velocity = newVelocity;

    }
    public void Die()
    {
        Debug.Log("���� �Լ� ȣ��");
        // �ڽ��� ���� ������Ʈ�� ��Ȱ��ȭ
        gameObject.SetActive(false);

        //���� �����ϴ� GameManager Ÿ���� ������Ʈ�� ã�Ƽ� ��������
        GameManager gamemanager = FindObjectOfType<GameManager>();
        //������ GameManager ������Ʈ�� EndGame() �޼��� ����
        gamemanager.EndGame();

        // �״� ����
        audioSource.Play();
    }
}