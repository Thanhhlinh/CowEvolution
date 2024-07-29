using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour
{
    public int tier;
    public Transform pos;
    // Start is called before the first frame update
    void Start()
    {
        SetPoop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPoop()
    {
        if (tier >=4)
        {
            tier = 4;
        }     
        GetComponent<SpriteRenderer>().sprite = GameManager.Instance.poop_Sprites[tier];
        StartCoroutine(Dissapear());
    }

    IEnumerator Dissapear()
    {
        yield return new WaitForSeconds(1);
        GameManager.Instance.AddCoins((int)Mathf.Pow(10, tier), pos);
        Destroy(gameObject);
    }
}
