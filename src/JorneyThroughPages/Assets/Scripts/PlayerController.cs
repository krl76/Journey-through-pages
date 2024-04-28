using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Transform _flyCheck;
    [SerializeField] private Transform _cam;
    [SerializeField] private Animator _animator;

    [Header("SFX")] 
    [SerializeField] private GameObject _prefabAudio;
    [SerializeField] private AudioClip[] _clips;
    [SerializeField] private int _moveTime, time;

    //private AudioSource _audioSource;
    
    private float _groundCheckRadius = 0.3f;
    private float _speed = 8f;
    private float _turnSpeed = 2500f;
    private float _jumpForce = 500f;

    private Rigidbody _rigidbody;
    private Vector3 _direction;

    private GravityBody _gravityBody;
    private bool isGrounded = true;
    private bool isFlyAnim = false;
    private bool isJumped = false;

    void Start()
    {
        _rigidbody = transform.GetComponent<Rigidbody>();
        _gravityBody = transform.GetComponent<GravityBody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        _direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        isGrounded = Physics.CheckSphere(_groundCheck.position, _groundCheckRadius, _groundMask);
        isFlyAnim = Physics.CheckSphere(_flyCheck.position, _groundCheckRadius, _groundMask);

        _animator.SetBool("isJumping", !isGrounded && Input.GetKey(KeyCode.Space));
        _animator.SetBool("isFalling", !isGrounded && !isFlyAnim);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumped = true;
            _rigidbody.AddForce(-_gravityBody.GravityDirection * _jumpForce, ForceMode.Impulse);
        }

        if (isJumped && isGrounded)
        {
            isJumped = false;
            _rigidbody.velocity = Vector3.zero;
        }
    }

    void FixedUpdate()
    {
        bool isRunning = _direction.magnitude > 0.1f;

        if (isRunning)
        {

            Vector3 direction = transform.forward * _direction.z;
            _rigidbody.MovePosition(_rigidbody.position + direction * (_speed * Time.fixedDeltaTime));
            Quaternion rightDirection = Quaternion.Euler(0f, _direction.x * (_turnSpeed * Time.fixedDeltaTime), 0f);
            Quaternion newRotation = Quaternion.Slerp(_rigidbody.rotation, _rigidbody.rotation * rightDirection, Time.fixedDeltaTime * 3f); ;
            _rigidbody.MoveRotation(newRotation);
            Audio();
            if (time > 0)
            {
                time--;
            }
        }

        _animator.SetBool("isRunning", isRunning);
    }

    private void Audio()
    {
        if(time != 0) return;
        time = _moveTime;
        AudioSource audio = GameObject.Instantiate(_prefabAudio).GetComponent<AudioSource>();
        if (!isGrounded && !isFlyAnim)
        {
            audio.Stop();
            return;
        }
        audio.clip = _clips[Random.Range(1,3)];
        audio.Play();
        Destroy(audio, 5);
    }
}