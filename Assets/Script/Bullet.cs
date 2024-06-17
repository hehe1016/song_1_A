using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f; //ź���� �ӷ�
    private Rigidbody bulletRigidbody; //ź�˿� ���Ǵ� ���� ������Ʈ�� ������ ���� 

    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed;              // transform.foward = vector3(0f, 0f, 0f);
        

        Destroy(gameObject, 3.0f);       //3�� �ڿ� �ڽ��� �ı�
    }

    // Ʈ���� �浹 �� �ڵ����� ����Ǵ� �޼���
    private void OnTriggerEnter(Collider other)
    { 

            //�浹�� ���� ���� ������Ʈ�� Player �±׸� ���� ���
            if (other.tag == "Player")
        {
            // ���� ���� ������Ʈ���� PlayerController ������Ʈ ��������
            PlayerController playerController = other.GetComponent<PlayerController>();

            // �������� ���� PlayerController ������Ʈ�� �������� �� �����ߴٸ�
            if (playerController != null)
            {
                // ���� PlayerController ������Ʈ�� Die() �޼��� ����
                playerController.Die();
            }
        }
  }



    // Update is called once per frame
    void Update()
    {
        
    }
}
