using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float rotSpeed = 1.0f;
    public Vector2 rotYRange = new Vector2(0.0f, 180.0f );
    public LayerMask jumpMask;
    float curRotY;
    bool isGround; // ĳ���Ͱ� ���鿡 �پ� �ִ��� Ȯ��
    BoxCollider boxCollider;
    Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        curRotY = transform.localRotation.eulerAngles.y;
        boxCollider = GetComponent<BoxCollider>();
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        IsGround();
        TryJump();
        Rotate();
        Move();
    }


    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        transform.Translate(transform.forward * x * Time.deltaTime * moveSpeed); // �յ� �̵�.
        transform.position = new Vector3(0, transform.position.y, transform.position.z);

    }

    void Rotate()
    {
        if (Input.GetKey(KeyCode.D)) // ���������� ȸ��, +
        {
            curRotY -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A)) // �������� ȸ��, -
        {
            curRotY += -1*Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        }
        curRotY = Mathf.Clamp(curRotY, rotYRange.x, rotYRange.y); // rotYRange�ȿ� ������ ���ѵ�
        transform.localRotation = Quaternion.Euler(0, curRotY, 0);
    }

    void IsGround()
    {
        isGround = Physics.Raycast(transform.position, Vector3.down, boxCollider.size.y, jumpMask);
    }

    void TryJump()
    {
        if (isGround && Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    void Jump()
    {
        rigid.velocity = transform.up * 2.0f;
    }
    
}
