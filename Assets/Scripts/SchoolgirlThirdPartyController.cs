using UnityEngine;
using System;
using System.Collections;

public class SchoolgirlThirdPartyController : MonoBehaviour 
{
	private Animator animator;
    private bool walking = false;
    private bool jumping = false;

	void Start()
	{
		animator = GetComponent<Animator>();
	}

	void Update()
	{
        if (!Input.anyKey)
        {
            if (walking)
            {
                this.walking = false;
                animator.SetInteger("Walking", 0);
            }
        }
        else
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (horizontal != 0 || vertical != 0)
            {
                this.walking = true;
                animator.SetInteger("Walking", 1);
            }

            if (Input.GetKeyDown("space"))
            {
                this.jumping = true;
                animator.SetInteger("Jump", 1);
            }
        }
	}
}

