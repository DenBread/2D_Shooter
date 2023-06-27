using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // ���������� �������� � ������� ����������
    // ������ ������
    // ��������
    // ��������

    [SerializeField] private float _speedMove;
    [SerializeField] private float _speedUp;
    [SerializeField] private Transform _pointShoot;
    [SerializeField] private GameObject _bulletPrefabs;
    private GameObject _bullet;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Flip();
        Shoot();
    }

    private void Move()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        

        _rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * _speedMove * Time.deltaTime, _rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(new Vector2(0, _speedUp), ForceMode2D.Impulse);
        }
    }

    private void Flip()
    {
        if(_rb.velocity.x < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180f, 0));
        }
        if(_rb.velocity.x > 0)
        {
            transform.rotation = Quaternion.identity;
        }
    }

    private void Shoot()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Shoot");
            _bullet = Instantiate(_bulletPrefabs, _pointShoot.transform.position, Quaternion.Euler(transform.rotation.eulerAngles));
        }
    }

    
}
