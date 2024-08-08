using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMove : MonoBehaviour
{
    public bool isAlive = true;
    PlayerSnake snakeLogic;
    Rigidbody rb;
    [SerializeField] float moveSpeed = 0.5f;
    [SerializeField] int rotateAmount;

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

            Rotate(KeyCode.UpArrow, false, true);
            Rotate(KeyCode.DownArrow, false, false);

            Rotate(KeyCode.RightArrow, true, true);
            Rotate(KeyCode.LeftArrow, true, false);
        }
        else print("dead(((");
    }
    void ForwardRigidbody()
    {
        rb.velocity = transform.forward * moveSpeed;
    }

    void Rotate(KeyCode key, bool rotateAxis/*false for x, true for y*/, bool isNegative)
    {
        int rotateValue = rotateAmount;
        Vector3 rotateVector = Vector3.zero;
        if (isNegative)
        {
            rotateValue = -rotateAmount;
        }

        //print(rotateAmount + comma + key + comma + rotateAxis + comma + isNegative);
        if (Input.GetKeyDown(key))
        {
            if(rotateAxis == false)
            {
                rotateVector = Vector3.right * rotateValue;
                transform.Rotate(rotateVector);
            }
            else if(rotateAxis == true)
            {
                rotateVector = Vector3.up * rotateValue;
                transform.Rotate(rotateVector);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisionObject;
        if (collision.transform.parent == null) collisionObject = collision.gameObject;
        else collisionObject = collision.transform.parent.gameObject;

        if (collisionObject.CompareTag("Apple"))
        {
            snakeLogic.maxSegments++;
            Destroy(collision.transform.parent.gameObject);
        }
        else if (collisionObject.CompareTag("Obstacle"))
        {
            isAlive = false;
            Time.timeScale = 0;
        }
        else return;
    }
}
