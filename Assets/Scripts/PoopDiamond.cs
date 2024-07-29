using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopDiamond : MonoBehaviour
{
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
        
        GetComponent<SpriteRenderer>().sprite = GameManager.Instance.poop_Sprites[5];
        StartCoroutine(Dissapear());
    }

    IEnumerator Dissapear()
    {
        yield return new WaitForSeconds(1);
        GameManager.Instance.AddDiamonds(1, pos);
        Destroy(gameObject);
    }
}
