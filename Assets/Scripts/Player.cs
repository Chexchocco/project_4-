using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update


    float fast_move_count = 3.0f;
    float cool_down = 10.0f;
    private bool isJumping = false;
    SpriteRenderer rend;
   
    public GameObject recallPrefab;

    Vector3 recall_pos;

    //

    public float maxSpeed;
    Rigidbody2D rigid;


    public Transform pTransform;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        //Max Speed
        if (rigid.velocity.x > maxSpeed) //Right Max Speed
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);

        else if (rigid.velocity.x < maxSpeed * (-1)) //Left Max Speed
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);

        if ((Input.GetKey(KeyCode.Q)) && (fast_move_count ==3.0f))
            maxSpeed = 20.0f;
        if ((Input.GetKey(KeyCode.RightArrow)) && (Input.GetKey(KeyCode.LeftArrow))) 
        { 

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rend.flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rend.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Recall();
        }

        if(maxSpeed == 20.0f)
        {
            fast_move_count -= Time.deltaTime ;
            if (fast_move_count <= 0.0f)
            {
                cool_down = 10.0f;
                maxSpeed = 10.0f;
            }
        }
        
        if(cool_down > 0)
        {
            cool_down -= Time.deltaTime;
            if (cool_down <= 0)
            {
                fast_move_count = 3.0f;
            }
        }

        recall_trace();

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
                pTransform = collision.gameObject.transform;

                transform.parent = pTransform; //오브젝트의 페어런트를 pTransform으로 지정하여 줍니다.

            }

        }
        


       

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Platform"))
        {
            isJumping = true;
            transform.parent = null; //오브젝트의 페어런트를 해제합니다. 즉 페어런트가 없는 상태로 됩니다.
            
        }

        


    }

    void recall_trace()
    {

        GameObject Recall = GameObject.Instantiate(recallPrefab);
        Recall.GetComponent<recall>().init(this);
    }
    void Recall()
    {
        recall_pos = GameObject.FindWithTag("recall_point").transform.position;
        gameObject.transform.position = recall_pos;
        Destroy(GameObject.FindWithTag("recall_point"));
    }
}
