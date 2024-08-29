using System.Collections;
using UnityEngine;


public abstract class StateBaseCow 
{
    public abstract void EnterState(Cow cow);
    public abstract void UpdateState(Cow cow);
}

public class CowMoveState : StateBaseCow
{
    public override void EnterState(Cow cow)
    {
        
    }

    public override void UpdateState(Cow cow)
    {
        if (!cow.isDragged && cow.hasDestination)
        {
            if (Vector3.Distance(cow.transform.position, cow.destination) > 0.1f)
            {
                Vector3 direction = cow.destination - cow.transform.position;
                if (direction.x > 0)
                {
                    cow.spriteRenderer.flipX = false;
                    if (cow.currentHat != null)
                    {
                        cow.hatPosition.localScale = Vector3.one;
                    }
                }
                else if (direction.x < 0)
                {
                    cow.spriteRenderer.flipX = true;
                    if (cow.currentHat != null)
                    {
                        cow.hatPosition.localScale = new Vector3(-1, 1, 1);
                    }
                }
                float zPosition = cow.tier >= 6 && cow.tier <= 11 ? -12 : cow.tier > 11 ? -22 : cow.transform.position.z;
                cow.transform.position = Vector3.MoveTowards(new Vector3(cow.transform.position.x, cow.transform.position.y, zPosition), cow.destination, cow.speed * Time.deltaTime);
            }
            else
            {
                cow.SwitchState(cow.idleState);
            }
        }
        
    }
}
public class CowIdleState : StateBaseCow
{
    public override void EnterState(Cow cow)
    {
        cow.Take_Poop();
    }

    public override void UpdateState(Cow cow)
    {
        cow.hasDestination = false;
        
        cow.StartCoroutine(WaitPoop(cow));
    }
    IEnumerator WaitPoop(Cow cow)
    {
        yield return new WaitForSeconds(Random.Range(1, 4));
        SetRandomDestination(cow);
        cow.SwitchState(cow.moveState);
    }

    public void SetRandomDestination(Cow cow)
    {
        if (!cow.hasDestination)
        {
            cow.destination = GetRandomPosition(cow);
            cow.hasDestination = true;
        }
    }
    private Vector3 GetRandomPosition(Cow cow)
    {
        float x = Random.Range(SpawnManager.Instance.fence.bounds.center.x - 3.3f, SpawnManager.Instance.fence.bounds.center.x + 3f);
        float y = Random.Range(SpawnManager.Instance.fence.bounds.center.y - 4.5f, SpawnManager.Instance.fence.bounds.center.y + 4.7f);
        if (cow.tier >= 6 && cow.tier <= 11)
        {
            return new Vector3(x, y, -12);
        }
        else if (cow.tier > 11)
        {
            return new Vector3(x, y, -22);
        }
        else
        {
            return new Vector3(x, y, 0);
        }
    }
}

