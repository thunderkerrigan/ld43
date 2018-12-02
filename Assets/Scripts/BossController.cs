using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Principal;
using UnityEngine.Tilemaps;
using System.Reflection;
using System;


namespace Gamekit2D
{
[RequireComponent(typeof(CharacterController2D))]
[RequireComponent(typeof(Animator))]
public class BossController : MonoBehaviour {


    // variable to hold a reference to our SpriteRenderer component
    private SpriteRenderer mySpriteRenderer;
    private Transform playerPos;
    private Transform bossPos;
	private float flipper;
    protected Animator m_Animator;
    protected Vector2 m_MoveVector;
    protected readonly int m_HashHorizontalSpeedPara = Animator.StringToHash("HorizontalSpeed");
    protected readonly int m_HashVerticalSpeedPara = Animator.StringToHash("VerticalSpeed");
    protected readonly int m_HashGroundedPara = Animator.StringToHash("Grounded");

    protected CharacterController2D m_CharacterController2D;
	// Use this for initialization
	void Start () {
      
	}

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
            m_CharacterController2D = GetComponent<CharacterController2D>();
            m_Animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
      //  m_CharacterController2D.Move(m_MoveVector * Time.deltaTime);
      //m_Animator.SetFloat(m_HashHorizontalSpeedPara, m_MoveVector.x);
        m_Animator.SetFloat(m_HashVerticalSpeedPara, m_MoveVector.y);

    }

    public bool IsFalling()
    {
        return m_MoveVector.y < 0f && !m_Animator.GetBool(m_HashGroundedPara);
    }


    public bool CheckForGrounded()
    {
        bool wasGrounded = m_Animator.GetBool(m_HashGroundedPara);
        bool grounded = m_CharacterController2D.IsGrounded;


        return grounded;
    }




	// Update is called once per frame
	void Update () {

      
      

            playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
			bossPos = GetComponent<Transform>();
            Vector3 localScale = bossPos.localScale;

            // if the A key was pressed this frame
            if (playerPos.position.x > bossPos.position.x )
            {
                // flip the sprite
                //  mySpriteRenderer.flipX = true;
                flipper =  localScale.x * -1;
           		localScale.x = flipper;
                Debug.Log("Je flip" );
            }
			else 
			{
                // Dont flip the sprite
                //mySpriteRenderer.flipX = false;
                localScale.x *= 1;
                Debug.Log("Je déflip");
			}
	}
}
}
