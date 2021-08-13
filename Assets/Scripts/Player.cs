using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 10.0f;
    float xMove = 0;
    float yMove = 0;
    private bool isJumping = false;
    private bool left_move = false;
    private bool right_move = false;

    Collision2D collision1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        xMove = 0;
        yMove = 0;

        if (Input.GetKey(KeyCode.RightArrow))
            xMove += speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow))
            xMove -= speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        Move(xMove);


    }
    void Move(float xMove)
    {
        if ((!right_move) && (xMove > 0))
        {
            this.transform.Translate(new Vector3(xMove, 0, 0));
        }
        else if ((!left_move) && (xMove < 0))
        {
            this.transform.Translate(new Vector3(xMove, 0, 0));
        }
    }
    void Jump()
    {
        if (!isJumping)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 20, 0), ForceMode2D.Impulse);
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.contacts.Length > 0)
        {
            ContactPoint2D contact = collision.contacts[0];
            if (Vector3.Dot(contact.normal, Vector3.up) > 0.5)
            {
                isJumping = false;

            }

        }
        Collider2D col = GetComponents<BoxCollider2D>()[0];

        if (col == collision.otherCollider)
        {
            right_move = true;
        }

        col = GetComponents<BoxCollider2D>()[1];
        if (col == collision.otherCollider)
        {
            left_move = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Platform"))
        {
            isJumping = true;

        }

        Collider2D col = GetComponents<BoxCollider2D>()[0];

        if (col == collision.otherCollider)
        {
            right_move = false;
        }

        col = GetComponents<BoxCollider2D>()[1];
        if (col == collision.otherCollider)
        {
            left_move = false;
        }


    }

}
