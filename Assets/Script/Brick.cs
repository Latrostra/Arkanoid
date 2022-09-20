using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int x;
    public int y;
    public BrickSO brickSO;
    private SpriteRenderer spriteRenderer;
    private int currentHealth;
    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = brickSO.Health;
        spriteRenderer.color = brickSO.Color[0];
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col != null) {
            ScoreManager.Instance.score.Value += 10 * currentHealth;
            currentHealth--;
            MapManager.Instance.OnHit(x, y);
            if (currentHealth <= 0) {
                MapManager.Instance.BrickDestroy(x, y, this.transform.position.x, this.transform.position.y);
                Destroy(this.gameObject);
                return;
            }
            if (brickSO.Color[brickSO.Health - currentHealth] != null) {
                spriteRenderer.color = brickSO.Color[brickSO.Health - currentHealth];
            }
        }
    }
}
