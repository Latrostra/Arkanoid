using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [HideInInspector]
    public Rigidbody2D rigidbody2D;
    private void Awake() {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        Invoke("StartBall", 1f);
    }

    private void StartBall() {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        this.rigidbody2D.AddForce(force.normalized * this.speed);
    }
}
