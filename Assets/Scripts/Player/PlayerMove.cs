using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float moveSpeed = 0.1f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        Forward();

        Rotate(KeyCode.UpArrow, 0, false);
        Rotate(KeyCode.DownArrow, 0, true);

        Rotate(KeyCode.RightArrow, 0, false);
        Rotate(KeyCode.LeftArrow, 0, true);
    }
    void Forward()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(0, 0, moveSpeed);
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
