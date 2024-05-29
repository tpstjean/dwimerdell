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

    private Rigidbody2D _rbody;
    // private BoxCollider2D _collider;

    // Start is called before the first frame update
    void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
        // _collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        _rbody.velocity = new Vector2(MOVE_SPEED * Input.GetAxis("Horizontal"), MOVE_SPEED * Input.GetAxis("Vertical"));
    }
}
