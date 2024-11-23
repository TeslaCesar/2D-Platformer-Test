

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Animator")]
    private Animator anim;
    private SpriteRenderer renderSprite;

    [Header("Movimiento")]
    public float moveSpeed;

    [Header("Componentes")]
    public Rigidbody2D CuerpoRigido;

    [Header("Salto")]
    public float saltoFuerza;
    private bool canDouble;

    [Header("Grounded")]
    private bool isGrounded;
    public Transform tierraCheckPoint;
    public LayerMask queCapaEs;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        renderSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

       

        CuerpoRigido.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), CuerpoRigido.velocity.y);

        isGrounded = Physics2D.OverlapCircle(tierraCheckPoint.position, .2f, queCapaEs);

        if(isGrounded){
            canDouble = true;
        }

        if(Input.GetButtonDown("Jump") )
        {

            if(isGrounded)
            {
                CuerpoRigido.velocity = new Vector2(CuerpoRigido.velocity.x, saltoFuerza);
            }
            else
            {
                if(canDouble){
                    CuerpoRigido.velocity = new Vector2(CuerpoRigido.velocity.x, saltoFuerza);
                    canDouble = false;
                }
            }
            
        }

        if(CuerpoRigido.velocity.x < 0){
            renderSprite.flipX = true;

        }
        else if(CuerpoRigido.velocity.x > 0){
            renderSprite.flipX = false;
        }

        anim.SetFloat("Speed", Mathf.Abs(CuerpoRigido.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
    }
}
