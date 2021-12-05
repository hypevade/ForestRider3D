using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarComtroller : MonoBehaviour
{
    private float _speed;
    private Rigidbody _rb;
    [SerializeField]
    private float _startSpeed;
    [SerializeField]
    private GameObject patr;
    //[SerializeField]
    //private GameObject _leftDot;
    //private Rigidbody _leftRb;
    //[SerializeField]
    //private GameObject _rightDot;
    //private Rigidbody _rightRb;
    private bool _isMoveBack;
    private bool _speedIsZero;//sp1
    private Vector3 _startBackPos;
    private float timer = 1f;
    private float tempSpeed;
    private float _angle = 90f;


    void Start()
    {
        _speed = _startSpeed;
        tempSpeed = _startSpeed;
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = _speed * Vector3.right;
        //_leftRb = _leftDot.GetComponent<Rigidbody>();
        //_rightRb = _rightDot.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!GameManager.instance.GameIsPaused && GameManager.instance.GameIsStarted && !GameManager.instance.GameIsOver)
        {
            _speedIsZero = false;
            _speed = tempSpeed;
            _angle = 90f;
        }
        else
        {
            if (!_speedIsZero)
            {
                _speedIsZero = true;
                tempSpeed = _speed;
                _angle = 0f;
            }
            _speed = 0f;
        }

        if (transform.rotation.eulerAngles.y > 150 ||
            transform.rotation.eulerAngles.y < -80)
        {
            if (!_isMoveBack)
                _startBackPos = transform.position;
            _isMoveBack = true;
        }
        else
            _isMoveBack = false;

        if (_isMoveBack && Vector3.Distance(transform.position, _startBackPos) > 5)
            GameManager.instance.GameIsOver = true;

        if (GameManager.instance.TurnLeft)
        {
            transform.Rotate(0, -_angle, 0);
            _rb.velocity = _speed * transform.forward;
            GameManager.instance.TurnLeft = false;
        }
        if (GameManager.instance.TurnRight)
        {
            transform.Rotate(0, _angle, 0);
            _rb.velocity = _speed * transform.forward;
            GameManager.instance.TurnRight = false;
        }
        _speed += 0.01f;
        _rb.velocity = _speed * transform.forward;

        if (GameManager.instance.GameIsOver)
            patr.SetActive(true);
           
    }

    private void FixedUpdate()
    {
        if (timer < 0f)
        {
            timer = 1f;
            if (!GameManager.instance.GameIsPaused && GameManager.instance.GameIsStarted && !GameManager.instance.GameIsOver)
                GameManager.instance.GameScore += _speed;
        }
        timer -= Time.deltaTime;
    }
}