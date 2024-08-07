using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable
{
    void Move(Vector3 destination, float speed);
}

public class CowMovement : IMoveable
{
    private Transform transform;
    private SpriteRenderer spriteRenderer;
    private Transform hatPosition;
    private GameObject currentHat;
    private int tier;

    public CowMovement(Transform transform, SpriteRenderer spriteRenderer, Transform hatPosition, GameObject currentHat, int tier)
    {
        this.transform = transform;
        this.spriteRenderer = spriteRenderer;
        this.hatPosition = hatPosition;
        this.currentHat = currentHat;
        this.tier = tier;
    }

    public void Move(Vector3 destination, float speed)
    {

        Vector3 direction = destination - transform.position;
        if (direction.x > 0)
        {
            spriteRenderer.flipX = false;
            if (currentHat != null)
            {
                hatPosition.localScale = Vector3.one;
            }
        }
        else if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
            if (currentHat != null)
            {
                hatPosition.localScale = new Vector3(-1, 1, 1);
            }
        }
        float zPosition = tier >= 6 && tier <= 11 ? -12 : tier > 11 ? -22 : transform.position.z;
        transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, zPosition), destination, speed * Time.deltaTime);

    }
}
