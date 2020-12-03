﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public string charName;
    [SerializeField] private GameObject spell;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Camera cam;
    private Movement_Controller _movementController;
    public CharData_Controller _charDataController;
    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        _charDataController = new CharData_Controller(charName);
        //Test Purpose
        _charDataController.ResetData(charName);
        //
        _movementController = new Movement_Controller(gameObject.GetComponent<Rigidbody2D>());
        _animator = GetComponent<Animator>();
        spell.GetComponent<BaseSpell>().Init();
    }

    // Update is called once per frame
    void Update()
    {    
        //Movement
        _movementController.move(_charDataController._CharData.MoveSpeed, cam);
        _animator.SetBool("isWalking", _movementController.isWalking);

        //Shooting
        if (Input.GetButtonDown("Fire1"))
        {
            _animator.SetBool("isShooting", true);
            spell.GetComponent<BaseSpell>().Shoot(firePoint);
        }
        else
        {
            _animator.SetBool("isShooting", false);
        }
    }
}