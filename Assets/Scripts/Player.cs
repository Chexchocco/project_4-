using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float Switch_duration;


    public event_stage Estage;
    public Stage_manager stage;
    float fast_move_count = 3.0f;
    float cool_down = 10.0f;
    private bool isJumping = false;
    SpriteRenderer rend;
    public bool can_move;
    public bool on_event;
    public GameObject recallPrefab;

    Vector3 recall_pos;
    float punch;
    public float maxSpeed;
    Rigidbody2D rigid;
    public Event_manager eManager;
    public Transform pTransform;

    //
    public Animator anime;
    float recall_pro;
    bool can_recall;
    public DialogueManager Dialogue_manager;
    public GameObject Interaction_object;
    public bool Can_Interact;
    public GameObject Respwan_object;
    public bool Can_rewind;

    public float rewind_cooldown = 0.0f;



    // Start is called before the first frame update
    void Start()
    {
        can_recall = true;
        rend = GetComponent<SpriteRenderer>();
        anime = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        can_move = true;
        recall_pro = 1.0f;
        Can_rewind = true;
        punch = 0.0f;
        rigid = GetComponent<Rigidbody2D>();
        

    }




    // Update is called once per frame
    void Update()
    {
        if ( (can_move == true) && (on_event ==false ) )
        {
            float h = Input.GetAxisRaw("Horizontal");
            if ((Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.D))))
            {
                rigid.AddForce(Vector2.right * h * 5, ForceMode2D.Impulse);

                //Max Speed
                if (rigid.velocity.x > maxSpeed) //Right Max Speed
                    rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);

                else if (rigid.velocity.x < maxSpeed * (-1)) //Left Max Speed
                    rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
            }
            if ((Input.GetKey(KeyCode.Q)) && (fast_move_count == 3.0f))
            {

            }                
            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                anime.SetBool("Moving", false);
            }
            if ((Input.GetKey(KeyCode.D)) && (Input.GetKey(KeyCode.A))                 ) 
            {
                anime.SetBool("Moving", false);
            }
            else if (Input.GetKey(KeyCode.D))
            {

                rend.flipX = true;
                anime.SetBool("Moving", true);

            }
            else if (Input.GetKey(KeyCode.A))
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
            if (Input.GetKeyDown(KeyCode.E) &&( can_recall == true)) 
            {
                anime.SetTrigger("Recall");
                anime.SetBool("Recall_process", true);
                can_move = false;
                rigid.gravityScale = 0;
                rigid.bodyType = RigidbodyType2D.Static;
                can_recall = false;
            }
            

            recall_trace();

        }

        if (Input.GetKeyDown(KeyCode.F) )
        {
            if ((Can_Interact == true))
            {
                if (Interaction_object.name.Equals("ori"))
                {
                    Dialogue_manager.Interaction(Interaction_object);
                    if (Dialogue_manager.On_action == true)
                    {
                        on_event = true;
                    }
                    else
                    {
                        on_event = false;
                    }
                }
                else if (Interaction_object.name.Equals("tip"))
                {
                    Dialogue_manager.Interaction(Interaction_object);
                    if (Dialogue_manager.On_action == true)
                    {
                        on_event = true;
                    }
                    else
                    {
                        on_event = false;
                    }
                }
                else if (Interaction_object.name.Equals("switch_stone"))
                {
                    Estage.platform_switch = true;
                    Estage.switch_time= Switch_duration;
                    anime.SetTrigger("punching");
                   

                }
                else if (Interaction_object.name.Equals("stage_stone"))
                {
                    stage.next_Stage = true;
                    anime.SetTrigger("punching");


                }
                else if (Interaction_object.name.Equals("end"))
                {
                    Dialogue_manager.Interaction(Interaction_object);
                    if (Dialogue_manager.On_action == true)
                    {
                        on_event = true;
                    }
                    else
                    {
                        on_event = false;
                    }
                }
            }
            else
            {
                
            }
        }
        if (can_move == false)
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

        if(maxSpeed == 8.0f)
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
        /* if(rewind_cooldown > 0)
        {
            rewind_cooldown -= Time.deltaTime;
            if(rewind_cooldown <= 0)
            {
                Can_rewind = true;
            }
        }*/ 
        if (punch > 0)
        {
            punch -= Time.deltaTime;
            if (punch <= 0)
            {
                on_event = false;
            }
        }



    }
  
    
    void Jump()
    {
        if (!isJumping)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 20, 0), ForceMode2D.Impulse);
            isJumping = true;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        anime.SetBool("Landing", true);

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interaction_object"))
        {
           
            Can_Interact = true;
            Interaction_object = collision.gameObject;
        }
        if (collision.gameObject.CompareTag("boundary"))
        {
            SceneManager.LoadScene("Stage" + stage.number);
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Interaction_object"))
        {
            Can_Interact = false;
            Interaction_object = collision.gameObject;
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
                // pTransform = collision.gameObject.transform;

                // transform.parent = pTransform; //오브젝트의 페어런트를 pTransform으로 지정하여 줍니다.
                
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
