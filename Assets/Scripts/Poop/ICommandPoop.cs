using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommandPoop
{
    void Execute();
    void ExecuteDiamond();
}

public class DissapearCommand : ICommandPoop
{
    private Poop poop;

    public DissapearCommand(Poop poop)
    {
        this.poop = poop;
    }

    public void Execute()
    {
        if (poop.tier >= 4)
        {
            poop.tier = 4;
        }
        poop.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.poop_Sprites[poop.tier];
        poop.StartCoroutine(poop.Dissapear());
    }

    public void ExecuteDiamond()
    {

    }
}

public class DissapearDiamondCommand : ICommandPoop
{
    private PoopDiamond poop;

    public DissapearDiamondCommand(PoopDiamond poop)
    {
        this.poop = poop;
    }

    public void Execute()
    {

    }

    public void ExecuteDiamond()
    {
        poop.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.poop_Sprites[5];
        poop.StartCoroutine(poop.Dissapear());
    }
}