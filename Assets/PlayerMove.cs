using Cinemachine;
using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputSettings;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] InputActionReference _move;
    [SerializeField] float _speed;
    private Vector2 _moveDirection;

    // Event pour les dev
    public event Action OnStartMove;
    public event Action<int> OnHealthUpdate;

    // Event pour les GD
    [SerializeField] UnityEvent _onEvent;
    [SerializeField] UnityEvent _onEventPost;

    public Vector2 JoystickDirection { get; private set; }
    Coroutine MovementRoutine { get; set; }

    private void Start()
    {
        _move.action.started += StartMove;
        _move.action.performed += UpdateMove;
        _move.action.canceled += StopMove;
    }

    private void OnDestroy()
    {
        _move.action.started -= StartMove;
        _move.action.performed -= UpdateMove;
        _move.action.canceled -= StopMove;
    }

    private void StartMove(InputAction.CallbackContext context)
    {
        OnStartMove?.Invoke();
        MovementRoutine = StartCoroutine(MoveCoroutine(context.ReadValue<Vector2>()));
    }
    private void UpdateMove(InputAction.CallbackContext context)
    {
        if(_moveDirection != context.ReadValue<Vector2>())
        {
            Debug.Log("performed change");
            _moveDirection = context.ReadValue<Vector2>();
        }
        Debug.Log("performed");

        //MovementRoutine = StartCoroutine(MoveCoroutine(context.ReadValue<Vector2>()));
    }
    private void StopMove(InputAction.CallbackContext context)
    {
        OnStartMove?.Invoke();
        StopCoroutine(MovementRoutine);
    }

    IEnumerator MoveCoroutine(Vector2 dir)
    {
        while(true)
        {
            dir = _moveDirection;
            Vector3 tempDir = new Vector3(dir.x, 0f, dir.y);

            transform.position += tempDir * Time.deltaTime * _speed;

            yield return null;
        }

        yield return null;
    }
}
