using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public EBirdType birdType;
  
    public float walkspeed;
    public float jumpPower;
    public float runSpeed;
    public AudioClip jumpAudio;

    [HideInInspector]
    public bool isPush = false;
    [HideInInspector]
    public Vector2 inputVec;
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriter;
    [HideInInspector]
    public bool isGrounded = true;

    private float speed;

    [HideInInspector]
    public bool isPlayingAnim = false;

    [HideInInspector]
    public bool isJump = false;

    private GameObject nearBox;
    private AudioSource audioSource;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        speed = walkspeed;
    }

    private void Update()
    {
        CheckGround();
    }

    private void FixedUpdate()
    {   
        anim.SetBool("isWalk", (inputVec.x != 0));

        if (GameManager.instance.isStop || isPlayingAnim)
        { 
            rigid.velocity = Vector2.zero;
            return;
        }
        rigid.velocity = new Vector2(inputVec.x * (isGrounded ? speed : walkspeed), rigid.velocity.y);

        if (birdType == EBirdType.John)
        {
            anim.SetBool("isRun", (speed > walkspeed));
        }

        anim.SetFloat("xPos", rigid.velocity.x);
    }

    public void Movement(InputAction.CallbackContext value)
    {
        inputVec = value.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext value)
    {
        if (GameManager.instance.isStop) return;
        if (isPlayingAnim) return;
        if (value.started)
        {
            if (birdType != EBirdType.Pigeon)
            {
                if (isGrounded)
                {
                    isJump = true;
                    rigid.velocity = new Vector2(rigid.velocity.x, jumpPower);
                    audioSource.clip = jumpAudio;
                    audioSource.Play();
                }
            }
            else
            {
                rigid.velocity = new Vector2(rigid.velocity.x, jumpPower);
                audioSource.clip = jumpAudio;
                audioSource.Play();
            }

        }
        if (value.canceled)
        {
            if (rigid.velocity.y > 0)
            {
                isJump = false;
                rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y * 0.6f);
            }
        }

    }

    public void Run(InputAction.CallbackContext value)
    {
        if (GameManager.instance.isStop) return;
        if (isPlayingAnim) return;
        if (value.started)
        {
            speed = runSpeed;
        }

        if (value.canceled)
        {
            speed = walkspeed;
        }
    }

    public void Push(InputAction.CallbackContext value)
    {
        if (GameManager.instance.isStop) return;
        if (isPlayingAnim) return;

        if (value.started)
        {
            isPush = true;
        }

        if (value.canceled)
        {
            isPush = false;
        }
    }

    public void LabberAction(Transform labberPos)
    {
        if (birdType != EBirdType.Pigeon && !isPlayingAnim)
        {
            isPlayingAnim = true;
            transform.position = labberPos.position;
            rigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            StartCoroutine(LabberAnim());
        }
    }


    IEnumerator LabberAnim()
    {
        anim.SetTrigger("DoLabber");
        yield return new WaitForSeconds(1.2f);
        rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
        isPlayingAnim = false;
    }

    void CheckGround()
    {
        //Debug.DrawRay(rigid.position, Vector2.down, Color.red, 2f);
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector2.down, 2f, LayerMask.GetMask("Floor"));

        if (rayHit.collider != null)
        {
            isGrounded = true;
            isJump = false;
            if (birdType == EBirdType.Pigeon)
                anim.SetBool("isFly", false);
        }
        else
        {
            isGrounded = false;
            if (birdType == EBirdType.Pigeon)
                anim.SetBool("isFly", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ÃÑ¾Ë ÇÇ°Ý 
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            if (GameManager.instance.isStop) return;
            GameManager.instance.OnDie();
        }
    }

    public void PushAnimation(bool isPlay)
    {
        if (isPlay)
        {
            anim.SetBool("isPush", true);
        }
        else
        {
            anim.SetBool("isPush", false);
        }
    }  
}
