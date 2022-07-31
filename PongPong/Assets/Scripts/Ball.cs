using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public float speed = 200.0f;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        ResetPosition();
        AddStartingForce();
    }

    public void ResetPosition() // reset pozycji i velocity
    {
        _rigidbody.position = Vector3.zero;
        _rigidbody.velocity = Vector3.zero;

    }

    public void AddStartingForce() // coinflip logic of direction
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) :
            Random.Range(0.5f, 1.0f);
        // przyspieszanie 'ball'
        Vector2 direction = new Vector2(x, y);
        _rigidbody.AddForce(direction * this.speed);
    }

    public void AddForce(Vector2 force)
    {
        _rigidbody.AddForce(force);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PowerUp")
        {
            Vector2 direction = new Vector2(0.2f, 0.2f);
            _rigidbody.AddForce(direction * this.speed);
        }
    }
}