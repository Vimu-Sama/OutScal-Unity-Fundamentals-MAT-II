using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Physics")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jmpSpeed = 10f;
    Rigidbody2D rb;
    [HideInInspector]public bool isJumping = false;
    Vector2 jump = new Vector3(0,0) ;
    float getHorizontal;
    [Header("Animator")]
    Animator anim;
    [Header("Firing")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletPos;
    [SerializeField] GameManagerScript gameManager;
    tagType tagofTrigger;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();
    }
    private void Update()
    {
        getHorizontal = Input.GetAxisRaw("Horizontal");
        if (getHorizontal == 0)
        {
            anim.SetBool("Run", false);
        }
        else
        {
            if(getHorizontal<0)
            {
                transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x)*(-1), transform.localScale.y);
            }
            else
            {
                transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
            }
            anim.SetBool("Run", true);
        }
        
        transform.position = new Vector2(transform.position.x + getHorizontal*moveSpeed * Time.deltaTime, transform.position.y);

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            jump = new Vector3(0f, jmpSpeed);
            rb.AddForce(jump, ForceMode2D.Impulse);
            isJumping = true;
        }
        anim.SetBool("Jump", isJumping);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.GetComponent<EnumDefiner>())
            return ;
        tagofTrigger = col.GetComponent<EnumDefiner>().GetTagType();
        if ((tagofTrigger== tagType.enemy || tagofTrigger==tagType.laser))
        {
            GetComponent<PlayerDeathScript>().DisablePlayer();
        }
        else if(tagofTrigger== tagType.intelCollectible)
        {
            gameManager.UpdateIntelCount();
            Destroy(col.gameObject);
        }

    }
    void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity, this.gameObject.transform);
    }

}
