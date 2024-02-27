using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActionPlayer : MonoBehaviour
{
    int hashJumpAttack;
    public Animator myAnim;
    // Start is called before the first frame update
    void Start()
    {
        hashJumpAttack = Animator.StringToHash("Jumpattack");
    }

    // Update is called once per frame
    void Update()
    {
       float x = Input.GetAxis("Horizontal");
       float y = Input.GetAxis("Vertical");
        myAnim.SetFloat("X", x);
        myAnim.SetFloat("Y", y);

        if (Input.GetKeyDown(KeyCode.F1))
        {
            myAnim.SetTrigger(hashJumpAttack);
        }
    }
}
