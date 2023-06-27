using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _particalsExplosion;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rb.velocity = transform.right * _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null)
        {
            Instantiate(_particalsExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
