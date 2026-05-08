using System.Collections;
using UnityEngine;

public class Corgi : MonoBehaviour
{
    public Sprite NormalSprite;
    public Sprite DrunkSprite;
    public UI Ui;
    
    private SpriteRenderer corgieSpriteRenderer;
    private bool isDrunk = false;
    private bool isPlastered = false;
    private Coroutine soberUpCoroutine;

    private int randomMoveCounter = 0;
    private int lastRandomDirection = 0;
    public void Awake()
    {
        corgieSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (isPlastered)
        {
            MoveRandomly();
        }
    }

    private void MoveRandomly()
    {
        int direction = lastRandomDirection;
        
        if (randomMoveCounter == 0)
        {
            direction = Random.Range(0, 4);
            randomMoveCounter = Random.Range(GameParameters.CorgiMinimumRandomMoveLength,
                GameParameters.CorgiMaximumRandomMoveLength);
            lastRandomDirection = direction;
        }

        switch (direction)
        {
            case 0:
                Move(Vector2.up);
                break;
            case 1:
                Move(Vector2.down);
                break;
            case 2:
                Move(Vector2.left);
                break;
            case 3:
                Move(Vector2.right);
                break;
        }
        
        randomMoveCounter--;
    }

    public void MoveManually(Vector2 direction)
    {
        if (isPlastered)
            return;
        Move(direction);
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
        
        return direction;
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
            AddPointToScore();
            Destroy(other.gameObject);
        }
        
        if (other.tag == "Pill")
        {
            SoberUp();
            Destroy(other.gameObject);
        }
    }

    private void AddPointToScore()
    {
        ScoreKeeper.AddPoint();
        Ui.ShowScore();
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Moonshine")
        {
            GetPlastered();
            Destroy(other.gameObject);
        }
    }

    private void GetPlastered()
    {
        isPlastered = true;
        Inebriate();
    }

    private void GetDrunk()
    {
        isDrunk = true;
        Inebriate();
    }
    
    private void Inebriate()
    {
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
        isPlastered = false;
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
