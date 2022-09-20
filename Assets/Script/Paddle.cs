using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    public float speed;
    public Vector2 moveDir;
    private float objectWidth;
    private Rect cameraRect;
    [SerializeField]
    private float maxBounceAngle = 75f;
    void Start()
    {
        var bottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
        var topRight = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight));
        cameraRect = new Rect(bottomLeft.x, bottomLeft.y, topRight.x - bottomLeft.x, topRight.y - bottomLeft.y);
        objectWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }
    void OnMove(InputValue value)
    { 
        moveDir = value.Get<Vector2>();
    }

    public void Update() {
        this.transform.position += new Vector3(moveDir.x, 0, 0) * speed * Time.deltaTime;
        this.transform.position = new Vector2(
        Mathf.Clamp(this.transform.position.x, cameraRect.xMin + objectWidth, cameraRect.xMax - objectWidth),
        this.transform.position.y);
    }

    public void OnCollisionEnter2D(Collision2D col) {
        Ball ball = col.gameObject.GetComponent<Ball>();
        if (ball != null) {
            Vector3 paddlePos = this.transform.position;
            Vector2 contactPoint = col.GetContact(0).point;
            
            float offset = paddlePos.x - contactPoint.x;
            float width = col.otherCollider.bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.rigidbody2D.velocity);
            float bounceAngle = (offset / width) * maxBounceAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -maxBounceAngle, maxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.rigidbody2D.velocity = rotation * Vector2.up * ball.rigidbody2D.velocity.magnitude;
        }
    }
    public void OnTriggerEnter2D(Collider2D col) {
        if (col != null) {
            col.GetComponent<IPowerUp>().SetPower(this.gameObject);
            Destroy(col.gameObject);
        }
    }
}
