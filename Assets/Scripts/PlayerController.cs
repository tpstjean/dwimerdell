using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
// [RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{

    [SerializeField] private float MOVE_SPEED;
    [SerializeField] private float DASH_SPEED;
    [SerializeField] private float DASH_TIME;
    [SerializeField] private float DASH_COOLDOWN;

    private Rigidbody2D _rbody;
    private BoxCollider2D _collider;

    private bool _isDashing;
    private bool _dashStopped;
    private double _dashCooldown;
    private double _timeSinceDash;

    // Start is called before the first frame update
    void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            HandleDash();
        }
        else
        {
            HandleCooldowns();
        }
    }

    void HandleDash()
    {
        if (_dashCooldown <= 0.0 && _rbody.velocity.magnitude >= 0.1f)
        {
            Debug.Log("Player is dashing");
            _isDashing = true;
            _dashStopped = false;
            _dashCooldown = DASH_COOLDOWN;
            _timeSinceDash = 0.0;
            _rbody.velocity *= DASH_SPEED;
        }


    }

    void HandleCooldowns()
    {
        if (_dashCooldown > 0.0) _dashCooldown -= Time.deltaTime;
        if (_timeSinceDash < DASH_TIME) _timeSinceDash += Time.deltaTime;
        if (_timeSinceDash >= DASH_TIME && !_dashStopped)
        {
            _dashStopped = true;
            _isDashing = false;
            _rbody.velocity = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (!_isDashing) _rbody.velocity = new Vector2(MOVE_SPEED * Input.GetAxis("Horizontal"), MOVE_SPEED * Input.GetAxis("Vertical"));
    }
}
