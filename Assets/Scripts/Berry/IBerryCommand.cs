using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBerryCommand
{
    IEnumerator ExecuteCoroutine(Cow cow);
}

public class BerryIndex0Command : IBerryCommand
{
    private Color color;
    private float timer;

    public BerryIndex0Command(Color color, float timer)
    {
        this.color = color;
        this.timer = timer;
    }


    public IEnumerator ExecuteCoroutine(Cow cow)
    {
        // Example for index 0
        Color colorOld = cow.GetComponent<SpriteRenderer>().color;
        cow.GetComponent<SpriteRenderer>().color = color;
        cow.eatBerry = true;
        yield return new WaitForSeconds(timer);
        cow.GetComponent<SpriteRenderer>().color = colorOld;
        cow.eatBerry = false;
        cow.Evolve();
        GameManager.Instance.sumTreeBerry--;
    }
}

public class BerryIndex1Command : IBerryCommand
{
    private Color color;
    private float timer;

    public BerryIndex1Command(Color color, float timer)
    {
        this.color = color;
        this.timer = timer;
    }


    public IEnumerator ExecuteCoroutine(Cow cow)
    {
        // Example for index 1
        Color colorOld = cow.GetComponent<SpriteRenderer>().color;
        cow.GetComponent<SpriteRenderer>().color = color;
        cow.eatBerry = true;
        yield return new WaitForSeconds(timer);
        cow.GetComponent<SpriteRenderer>().color = colorOld;
        cow.eatBerry = false;
        GameManager.Instance.sumTreeBerry--;
    }
}

public class BerryIndex2Command : IBerryCommand
{
    private Color color;
    private float timer;

    public BerryIndex2Command(Color color, float timer)
    {
        this.color = color;
        this.timer = timer;
    }

    public IEnumerator ExecuteCoroutine(Cow cow)
    {
        Color colorOld = cow.GetComponent<SpriteRenderer>().color;
        cow.GetComponent<SpriteRenderer>().color = color;
        cow.ContinuousPoop(true);
        cow.eatBerry = true;
        cow.ContinuousPoop(true);
        yield return new WaitForSeconds(timer);
        cow.GetComponent<SpriteRenderer>().color = colorOld;
        cow.ContinuousPoop(false);
        cow.eatBerry = false;
        cow.ContinuousPoop(false);
        GameManager.Instance.sumTreeBerry--;
    }
}

public class BerryIndex3Command : IBerryCommand
{
    private Color color;
    private float timer;

    public BerryIndex3Command(Color color, float timer)
    {
        this.color = color;
        this.timer = timer;
    }

    public IEnumerator ExecuteCoroutine(Cow cow)
    {
        Color colorOld = cow.GetComponent<SpriteRenderer>().color;
        cow.GetComponent<SpriteRenderer>().color = color;
        cow.eatBerry = true;
        cow.PoopDiamond();
        yield return new WaitForSeconds(5);
        cow.PoopDiamond();
        yield return new WaitForSeconds(timer);
        cow.GetComponent<SpriteRenderer>().color = colorOld;
        cow.eatBerry = false;
        GameManager.Instance.sumTreeBerry--;
    }
}
