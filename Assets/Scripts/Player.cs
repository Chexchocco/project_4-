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
    private bool can_move;
   
    public GameObject recallPrefab;

    Vector3 recall_pos;

    public float maxSpeed;
    Rigidbody2D rigid;

    public Transform pTransform;

    //
    private Animator anime;
    float recall_pro;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        anime = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        can_move = true;
        recall_pro = 1.0f;
    }


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void Update()
    {
        if(can_move == true)
        {
            float h = Input.GetAxisRaw("Horizontal");
            rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

            //Max Speed
            if (rigid.velocity.x > maxSpeed) //Right Max Speed
                rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);

            else if (rigid.velocity.x < maxSpeed * (-1)) //Left Max Speed
                rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);

            if ((Input.GetKey(KeyCode.Q)) && (fast_move_count == 3.0f))
                maxSpeed = 10.0f;
            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                anime.SetBool("Moving", false);
            }
            if ((Input.GetKey(KeyCode.RightArrow)) && (Input.GetKey(KeyCode.LeftArrow)))
            {
                anime.SetBool("Moving", false);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {

                rend.flipX = true;
                anime.SetBool("Moving", true);

            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {

                rend.flipX = false;
                anime.SetBool("Moving", true);

            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
                anime.SetBool("Landing", false);
                anime.SetTrigger("Jumping");
            }
            if (Input.GetKeyDown(KeyCode.E))
            {

                anime.SetTrigger("Recall");
                anime.SetBool("Recall_process", true);
                can_move = false;
                rigid.gravityScale = 0;
                rigid.bodyType = RigidbodyType2D.Static;
            }
        }
        if(can_move == false)
        {
            recall_pro -= Time.deltaTime;
            if(recall_pro <= 0)
            {
                Recall();
                can_move = true;
                rigid.gravityScale = 5;
                recall_pro = 1.0f;
                anime.SetBool("Recall_process", false);
                rigid.bodyType = RigidbodyType2D.Dynamic;
                
            }
        }

        if(maxSpeed == 10.0f)
        {
            fast_move_count -= Time.deltaTime ;
            if (fast_move_count <= 0.0f)
            {
                cool_down = 10.0f;
                maxSpeed = 5.0f;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        anime.SetBool("Landing", true);

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
