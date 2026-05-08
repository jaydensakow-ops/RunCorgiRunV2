using System.Collections;
using UnityEngine;

public class Corgi : MonoBehaviour
{
    public Sprite NormalSprite;
    public Sprite DrunkSprite;
    private SpriteRenderer corgieSpriteRenderer;
    private bool isDrunk = false;
    private Coroutine soberUpCoroutine;

    public void Awake()
    {
        corgieSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Move(Vector2 direction)
    {
        direction = ApplyDrunkenness(direction);
        FaceCorrectDirection(direction);
        
        Vector2 moveAmount = direction * GameParameters.CorgiMoveSpeed * Time.deltaTime;
        corgieSpriteRenderer.transform.Translate(moveAmount);

        corgieSpriteRenderer.transform.position = SpriteTools.ConstrainToScreen(corgieSpriteRenderer);
    }

    private Vector2 ApplyDrunkenness(Vector2 direction)
    {
        if (!isDrunk)
            return direction;

        direction.x = direction.x * -1;
        direction.y = direction.y * -1;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Beer")
        {
            GetDrunk();
            Destroy(other.gameObject);
        }
        
        if (other.tag == "Bone")
        {
            
        }
        
        if (other.tag == "Pill")
        {
            
        }
    }

    private void GetDrunk()
    {
        isDrunk = true;
        ChangeToDrunkSprite();
        StartSoberingUp();
    }

    private void StartSoberingUp()
    {
        if (soberUpCoroutine != null)
        {
            StopCoroutine(soberUpCoroutine);
        }
        soberUpCoroutine = StartCoroutine(CountdownUntilSober());
    }

    IEnumerator CountdownUntilSober()
    {
        yield return new WaitForSeconds(GameParameters.CorgiDrunkSeconds);
        SoberUp();
    }

    private void SoberUp()
    {
        isDrunk = false;
        ChangeToNormalSprite();
    }

    private void ChangeToNormalSprite()
    {
        corgieSpriteRenderer.sprite = NormalSprite;
    }

    private void ChangeToDrunkSprite()
    {
        corgieSpriteRenderer.sprite = DrunkSprite;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
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
