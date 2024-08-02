using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]float moveSpeed = 0.1f;
    [SerializeField] float moveTimerMax = 1;
    float moveTimer = 0;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        ForwardRigidbody();
        //ForwardTransform();

        Rotate(KeyCode.UpArrow, 0, false);
        Rotate(KeyCode.DownArrow, 0, true);

        Rotate(KeyCode.RightArrow, 1, false);
        Rotate(KeyCode.LeftArrow, 1, true);
    }
    void ForwardTransform()
    {
        moveTimer += Time.deltaTime;
        if(moveTimer >= moveTimerMax)
        {
            moveTimer = 0;
            print("move timer after moving " + moveTimer);
            transform.position += moveSpeed * transform.forward;
        }
    }
    void ForwardRigidbody()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = transform.forward * moveSpeed;
        }
    }
    void Rotate(KeyCode key,short rotateAxis, bool isNegative)
    {
        int rotateAmount = 90;
        if (isNegative == true) rotateAmount = -rotateAmount;
        if (Input.GetKeyDown(key))
        {
            if(rotateAxis == 0)
            {
                transform.Rotate(rotateAmount, 0, 0);
            }
            else if(rotateAxis == 1)
            {
                transform.Rotate(0, rotateAmount, 0);
            }
            else if (rotateAxis == 2)
            {
                transform.Rotate(0, 0, rotateAmount);
            }
        }
    }
}
