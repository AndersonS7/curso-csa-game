using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;

    private Rigidbody2D rig;

    private bool _isRunning;
    private bool _isRolling;
    private bool _isCutting;
    private float initialSpeed;
    private Vector2 _direction;

    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    public bool isRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    public bool IsCutting
    {
        get { return _isCutting; }
        set { _isCutting = value; }
    }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
    }

    private void Update()
    {
        OnInput();
        OnRun();
        OnRoll();
        OnCutting();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    #region Movement
    void OnCutting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            IsCutting = true;
            speed = 0;
        }

        if (Input.GetMouseButtonUp(0))
        {
            IsCutting = false;
            speed = initialSpeed;
        }
    }

    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove()
    {
        rig.MovePosition(rig.position + direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            _isRunning = false;
        }
    }

    void OnRoll()
    {
        if (Input.GetMouseButtonDown(1))
        {
            speed = runSpeed;
            isRolling = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            speed = initialSpeed;
            isRolling = false;
        }
    }

    #endregion
}
