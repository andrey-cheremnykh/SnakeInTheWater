using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool isAlive = true;
    PlayerSnake snakeLogic;
    Rigidbody rb;
    [SerializeField]float moveSpeed = 0.5f;
    [SerializeField]int rotateAmount;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        snakeLogic = GetComponent<PlayerSnake>();
    }
    
    private void Update()
    {
        if (isAlive)
        {
            ForwardRigidbody();

            Rotate(KeyCode.UpArrow, 0, false);
            Rotate(KeyCode.DownArrow, 0, true);

            Rotate(KeyCode.RightArrow, 1, false);
            Rotate(KeyCode.LeftArrow, 1, true);
        }
        else print("dead(((");
    }
    void ForwardRigidbody()
    {
            rb.velocity = transform.forward * moveSpeed;
    }
    void Rotate(KeyCode key,short rotateAxis, bool isNegative)
    {
        if (isNegative == true) rotateAmount = -rotateAmount;
        if (Input.GetKey(key))
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
    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisionObject;
        if (collision.transform.parent == null) collisionObject = collision.gameObject;
        else collisionObject = collision.gameObject;

        if (collisionObject.CompareTag("Apple"))
        {
            snakeLogic.maxSegments++;
            Destroy(collision.transform.parent.gameObject);
        }
        else if (collisionObject.CompareTag("Obstacle")) isAlive = false;
        else return;
    }
}
