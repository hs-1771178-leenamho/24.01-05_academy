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
    bool isGround; // 캐릭터가 지면에 붙어 있는지 확인
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
        transform.Translate(transform.forward * x * Time.deltaTime * moveSpeed); // 앞뒤 이동.
        transform.position = new Vector3(0, transform.position.y, transform.position.z);

    }

    void Rotate()
    {
        if (Input.GetKey(KeyCode.D)) // 오른쪽으로 회전, +
        {
            curRotY -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A)) // 왼쪽으로 회전, -
        {
            curRotY += -1*Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        }
        curRotY = Mathf.Clamp(curRotY, rotYRange.x, rotYRange.y); // rotYRange안에 값으로 제한됨
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
