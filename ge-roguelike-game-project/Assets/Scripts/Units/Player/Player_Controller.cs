using System;
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
    public bool loading;
    
    // Start is called before the first frame update
    void Start()
    {
        _charDataController = new CharData_Controller(charName);
        _movementController = new Movement_Controller(gameObject.GetComponent<Rigidbody2D>());
        _animator = GetComponent<Animator>();
        spell.GetComponent<BaseSpell>().Init();
        FindObjectOfType<UIManager>().SetMaxHP(_charDataController._CharData.MAXHp);
    }

    // Update is called once per frame
    void Update()
    {
        loading = GameObject.Find("Canvas").GetComponent<GameSession>().loading;
        Debug.Log(loading);
        //Movement
        if (!loading)
        {
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
}
