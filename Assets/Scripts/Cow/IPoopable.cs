using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface cho pooping
public interface IPoopable
{
    void TakePoop(Transform transform, GameObject cow);
    void TakePoopDiamond(Transform transform);
}

public class CowPooping : IPoopable
{

    private Poop poop;
    private PoopDiamond poopDiamond;
    private int tier;

    public CowPooping(Poop poop, PoopDiamond poopDiamond, int tier)
    {

        this.poop = poop;
        this.poopDiamond = poopDiamond;
        this.tier = tier;
    }

    public void TakePoop(Transform transform, GameObject cow)
    {
        if (AudioManager.Instance.soundEffectToggle.isOn)
        {
            AudioManager.Instance.PlayPoopSound();
        }
        Poop newPoop = GameObject.Instantiate(poop, transform.position, Quaternion.identity);
        newPoop.pos = transform;
        newPoop.GetComponent<SpriteRenderer>().sortingOrder = cow.GetComponent<SpriteRenderer>().sortingOrder;
        newPoop.tier = tier >= 4 ? 4 : (Random.Range(0, 2) == 1 ? tier + 1 : tier);
    }

    public void TakePoopDiamond(Transform transform)
    {
        PoopDiamond poop = GameObject.Instantiate(poopDiamond, transform.position, Quaternion.identity);
        poop.pos = transform;
    }
}
