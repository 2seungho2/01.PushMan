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
        // 지정한 위치에서 Forward 방향으로 shootRange 만큼 red색의 레이저를 발사하여 Debug(확인)
        Debug.DrawRay(transform.position, this.transform.forward * shootRange, Color.red);

        // Space바를 누르면 레이저가 충돌하는 오브젝트를 찾는다
        if(Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.forward, out hit, shootRange))
            {
                // 충돌한 오브젝트의 태그가 "Box"인지 확인
                if(hit.collider.gameObject.tag == "Box")
                {
                    // 충돌한 오브젝트가 박스가 맞으면 콘솔창에 name 을 띄움
                    Debug.Log(hit.collider.name);
                    // 플레이어로부터 Raycast가 부딪힌 포인트의 방향으로 shootPoer만큼 Force를 발사
                    hit.rigidbody.AddForceAtPosition(transform.forward * shootPower, hit.point);
                }
            }
        }
    }
}
