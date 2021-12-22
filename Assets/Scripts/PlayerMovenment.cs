using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovenment : MonoBehaviour
{
    private float Dashdir;
    private float playermoveX;
    private bool playerjump;
    private float playerattack;
    public Rigidbody2D mybody;
    private bool OnGround = true;
    private bool Win = false;
    private string Ground_Tag = "Ground";
    private string Enemy_Tag = "Enemy";
    private string WALK_ANIMATION = "Walk";
    private string JUMP_ANIMATION = "Jump";
    private string JUMPATTACK_ANIMATION = "JumpAttack";
    private string DASH_ANIMATION = "Dash";
    private string DEATH_ANIMATION = "Death";
    private string DIZZY_ANIMATION = "Dizzy";
    private string STRIKE_ANIMATION = "Strike"; 
    private string WIN_ANIMATION = "Win";
    private string IDLE_ANIMATION = "Idle";
    private string HURT_ANIMATION = "Hurt";
    private string ATTACK_ANIMATION = "Attack";
    private string BLOCK_ANIMATION = "Block";
    private string CROUCH_ANIMATION = "Crouch";
    private string CAST_ANIMATION = "Cast";
    
    private Animator anim;
    private SpriteRenderer sr;

    [SerializeField]
    public float JumpForce = 10f;

    [SerializeField]
    public float MoveForce = 10f;
    [SerializeField]
    public float DASH_TIME = 1f;
    void Start()
    {
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
        sr = GetComponent<SpriteRenderer>();
    }

    void PlayerMoveKeyboard()
    {
        playermoveX = Input.GetAxisRaw("Horizontal");
            transform.position += Time.deltaTime * (new Vector3(playermoveX, 0f, 0f)) * MoveForce; 
    }

    void PlayerJump()
    {
        playerjump = Input.GetButtonDown("Jump");
        if (playerjump && OnGround )
        {
            mybody.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            anim.SetBool(JUMP_ANIMATION, true);
            OnGround = false;
        }
    }

    void AnimatePlayer()
    {
        if (playermoveX > 0)
        {
            sr.flipX = false;
            anim.SetBool(WALK_ANIMATION, true);
        }
        else if ( playermoveX < 0)
        {
            sr.flipX = true;
            anim.SetBool(WALK_ANIMATION, true);
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    private void Attack()
    {
        if(Input.GetButtonDown("LeftClick"))
        {
            anim.SetBool(IDLE_ANIMATION, false);
            anim.SetBool(ATTACK_ANIMATION, true);
        }
        else 
        {
            anim.SetBool(ATTACK_ANIMATION, false);
        }
    }

    private void Dash()
    {
        if(Input.GetButtonDown("RightClick"))
        {
            anim.SetBool(DASH_ANIMATION, true);
            anim.SetBool(CROUCH_ANIMATION, true);
        }
        if(Input.GetButtonUp("RightClick"))
        {
            anim.SetBool(CROUCH_ANIMATION, false);
        }
        else
        {
            anim.SetBool(DASH_ANIMATION, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag(Ground_Tag))
        {
            OnGround = true;
            anim.SetBool(JUMP_ANIMATION, false);
        }
        if(collision.gameObject.CompareTag(Enemy_Tag))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D trigger) 
    {
        if(trigger.CompareTag("Finish"))
        {
            anim.SetBool(WIN_ANIMATION, true);
            Win = true;
            sr.flipX= true;
            transform.position = new Vector3(2.64f,16.33f,0f);
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }
    }

    void Update()
    {
        if(!Win)
        {
            AnimatePlayer();
            PlayerMoveKeyboard();
            Attack();
            Dash();
            PlayerJump();
        }
    }
    
    private void FixedUpdate() {
        if(!Win)
        {

        }
    }
}
