using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f;
    Vector3 lookDirection;
    public float shootPower = 500.0f;
    public float shootRange = 10.0f;


    void Update()
    {
        Move();
        Shoot();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)
            || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            float x = Input.GetAxisRaw("Vertical");
            float z = Input.GetAxisRaw("Horizontal");
            lookDirection = x * Vector3.forward + z * Vector3.right;

            this.transform.rotation = Quaternion.LookRotation(lookDirection);
            this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    void Shoot()
    {
        // ������ ��ġ���� Forward �������� shootRange ��ŭ red���� �������� �߻��Ͽ� Debug(Ȯ��)
        Debug.DrawRay(transform.position, this.transform.forward * shootRange, Color.red);

        // Space�ٸ� ������ �������� �浹�ϴ� ������Ʈ�� ã�´�
        if(Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.forward, out hit, shootRange))
            {
                // �浹�� ������Ʈ�� �±װ� "Box"���� Ȯ��
                if(hit.collider.gameObject.tag == "Box")
                {
                    // �浹�� ������Ʈ�� �ڽ��� ������ �ܼ�â�� name �� ���
                    Debug.Log(hit.collider.name);
                    // �÷��̾�κ��� Raycast�� �ε��� ����Ʈ�� �������� shootPoer��ŭ Force�� �߻�
                    hit.rigidbody.AddForceAtPosition(transform.forward * shootPower, hit.point);
                }
            }
        }
    }
}
