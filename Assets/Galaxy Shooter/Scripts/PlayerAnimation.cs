using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;

    private Player _players;

	// Use this for initialization
	void Start ()
    {
        _anim = GetComponent<Animator>();
        _players = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (_players.isPlayerOne == true)
        {
            if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow)))
            {
                _anim.SetBool("Turn_Left", true);
                _anim.SetBool("Turn_Right", false);
            }
            else if (Input.GetKeyUp(KeyCode.A) || (Input.GetKeyUp(KeyCode.LeftArrow)))
            {
                _anim.SetBool("Turn_Left", false);
                _anim.SetBool("Turn_Right", false);
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                _anim.SetBool("Turn_Right", true);
                _anim.SetBool("Turn_Left", false);
            }
            else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                _anim.SetBool("Turn_Right", false);
                _anim.SetBool("Turn_Left", false);
            }
        }
        else if (_players.isPlayerTwo == true)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                _anim.SetBool("Turn_Left", true);
                _anim.SetBool("Turn_Right", false);
            }
            else if (Input.GetKeyUp(KeyCode.J))
            {
                _anim.SetBool("Turn_Left", false);
                _anim.SetBool("Turn_Right", false);
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                _anim.SetBool("Turn_Right", true);
                _anim.SetBool("Turn_Left", false);
            }
            else if (Input.GetKeyUp(KeyCode.L))
            {
                _anim.SetBool("Turn_Right", false);
                _anim.SetBool("Turn_Left", false);
            }
        }
        
	}
}
