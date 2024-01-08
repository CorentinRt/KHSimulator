using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorBinding : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private EntityHealth _entityHealth;
    [SerializeField] private EntityGold _entityGold;
    [SerializeField] private HitEntity _hitEntity;
    

    // Methods

    void StartPlayerMoveAnimation()
    {
        _animator.SetBool("Walking", true);
    }
    void StopPlayerMoveAnimation()
    {
        _animator.SetBool("Walking", false);
    }

    void StartPlayerAttack()
    {
        _animator.SetTrigger("Attack");
    }


    // Start is called before the first frame update
    void Start()
    {
        _playerMove.OnStartMove += StartPlayerMoveAnimation;
        _playerMove.OnStopMove += StopPlayerMoveAnimation;

        _playerAttack.OnStartAttack += StartPlayerAttack;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
