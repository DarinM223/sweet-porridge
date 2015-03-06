using UnityEngine;
using System;
using System.Collections;

public class SchoolgirlThirdPartyController : MonoBehaviour 
{
	private Animator animator;

	void Start()
	{
		animator = GetComponent<Animator>();
	}

	void Update()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		if (horizontal != 0) 
		{
		}

		if (vertical != 0) 
		{
		}
	}
}

