using UnityEngine;

public class Corgi : MonoBehaviour
{
    private SpriteRenderer corgieSpriteRenderer;

    public void Awake()
    {
        corgieSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Move(Vector2 direction)
    {
        FaceCorrectDirection(direction);
        
        Vector2 moveAmount = direction * GameParameters.CorgiMoveSpeed * Time.deltaTime;
        corgieSpriteRenderer.transform.Translate(moveAmount);
    }

    private void FaceCorrectDirection(Vector2 direction)
    {
        if (direction.x > 0)
        {
            corgieSpriteRenderer.flipX = false;
        }
        
        else if (direction.x < 0)
        {
            corgieSpriteRenderer.flipX = true;
        }
    }
}
