using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField]private PlayerInput input;
    [SerializeField]private float moveSpeed = 10f;
    [SerializeField]private float paddingX = 0.2f;
    [SerializeField]private float paddingY = 0.2f;
    private Rigidbody2D m_Rigidbody;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        input.onMove += Move;
        input.onStopMove += StopMove;
    }

    private void OnDisable()
    {
        input.onMove -= Move;
        input.onStopMove -= StopMove;
    }

    private void Start()
    {
        m_Rigidbody.gravityScale = 0f;
        input.EnableGameplayInput();
    }

    private void Move(Vector2 moveInput)
    {
        m_Rigidbody.velocity = moveInput*moveSpeed;
        StartCoroutine(MovePositionLimitCoroutine());
    }

    private void StopMove()
    {
        m_Rigidbody.velocity = Vector2.zero;
        StopCoroutine(MovePositionLimitCoroutine());
    }

    IEnumerator MovePositionLimitCoroutine()
    {
        while (true) {
            transform.position = Viewport.Instance.PlayerMoveablePosition(transform.position, paddingX, paddingY);

            yield return null;
        }
    }
}