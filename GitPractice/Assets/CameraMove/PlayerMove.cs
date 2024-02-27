using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float rotSpeed = 360.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Move();
    }


    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        
        transform.Translate(Vector3.forward * x * Time.deltaTime * moveSpeed); // 앞뒤 이동.
        transform.position = new Vector3(0, transform.position.y, transform.position.z);

    }



    
}
