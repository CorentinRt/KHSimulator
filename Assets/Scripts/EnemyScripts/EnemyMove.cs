using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private GameObject _target;

    [SerializeField] private float _speed;

    private Vector2 _moveDirection;

    [SerializeField] private EnemyMoveBrain _moveBrain;

    private Coroutine _moveCoroutine;

    public event Action OnStartMove;
    public event Action OnStopMove;


    void StartMove()
    {
        _target = _moveBrain.Target;
        OnStartMove?.Invoke();
        _moveCoroutine = StartCoroutine(MoveCoroutine());
        Vector2 tempVec = Vector2.zero;
        tempVec.x = _target.transform.position.x - transform.position.x;
        tempVec.y = _target.transform.position.z - transform.position.z;
        _moveDirection = tempVec;
    }
    void UpdateMove()
    {
        Vector2 tempVec = Vector2.zero;
        tempVec.x = _target.transform.position.x - transform.position.x;
        tempVec.y = _target.transform.position.z - transform.position.z;
        _moveDirection = tempVec;
    }
    void StopMove()
    {
        _target = null;
        OnStopMove?.Invoke();
        StopCoroutine(MoveCoroutine());
    }

    // Start is called before the first frame update
    void Start()
    {
        _moveBrain.OnDetectPlayer += StartMove;
    }
    private void OnDestroy()
    {
        _moveBrain.OnDetectPlayer -= StartMove;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MoveCoroutine()
    {
        while (_moveBrain.DetectPlayer)
        {
            Vector3 tempDir = new Vector3(_moveDirection.x, 0, _moveDirection.y);

            transform.parent.position += tempDir * Time.deltaTime * _speed;

            UpdateMove();

            yield return null;
        }

        StopMove();

        yield return null;
    }
}
