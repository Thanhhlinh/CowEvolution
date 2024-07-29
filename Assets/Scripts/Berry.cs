using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berry : MonoBehaviour
{
    public bool isDragged;
    public float timer = 10f;
    public Color color;
    Vector3 offSet;
    GameObject cow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseUp()
    {
        isDragged = false;
    }

    private void OnMouseDrag()
    {
        isDragged = true;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)) + offSet;
    }

    private void OnMouseDown()
    {
        offSet = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDragged)
        {
            if (collision.CompareTag("Cow"))
            {
                cow = collision.gameObject;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;

                StartCoroutine(cowEffect());
            }
        }
    }

    IEnumerator cowEffect()
    {
        if(GameManager.Instance.index == 0)
        {
            Color colorOld = cow.GetComponent<SpriteRenderer>().color;
            cow.GetComponent<SpriteRenderer>().color = color;
            cow.GetComponent<Cow>().eatBerry = true;
            yield return new WaitForSeconds(timer);
            cow.GetComponent<SpriteRenderer>().color = colorOld;
            cow.GetComponent<Cow>().eatBerry = false;
            cow.GetComponent<Cow>().Evolve();
            GameManager.Instance.sumTreeBerry--;
            Destroy(gameObject);
        }else if(GameManager.Instance.index == 1)
        {
            Color colorOld = cow.GetComponent<SpriteRenderer>().color;
            cow.GetComponent<SpriteRenderer>().color = color;
            cow.GetComponent<Cow>().eatBerry = true;
            yield return new WaitForSeconds(timer);
            cow.GetComponent<SpriteRenderer>().color = colorOld;
            cow.GetComponent<Cow>().eatBerry = false;


            GameManager.Instance.sumTreeBerry--;
            Destroy(gameObject);

        }
        else if(GameManager.Instance.index == 2)
        {
            Color colorOld = cow.GetComponent<SpriteRenderer>().color;
            cow.GetComponent<SpriteRenderer>().color = color;
            cow.GetComponent<Cow>().ContinuousPoop(true);
            cow.GetComponent<Cow>().eatBerry = true;
            yield return new WaitForSeconds(timer);
            cow.GetComponent<SpriteRenderer>().color = colorOld;
            cow.GetComponent<Cow>().eatBerry = false;
            cow.GetComponent<Cow>().ContinuousPoop(false);
            GameManager.Instance.sumTreeBerry--;
            Destroy(gameObject);
        }
        else if (GameManager.Instance.index == 3)
        {
            Color colorOld = cow.GetComponent<SpriteRenderer>().color;
            cow.GetComponent<SpriteRenderer>().color = color;
            cow.GetComponent<Cow>().eatBerry = true;
            cow.GetComponent<Cow>().PoopDiamond();
            yield return new WaitForSeconds(5);
            cow.GetComponent<Cow>().PoopDiamond();
            yield return new WaitForSeconds(timer);
            cow.GetComponent<SpriteRenderer>().color = colorOld;
            cow.GetComponent<Cow>().eatBerry = false;



            GameManager.Instance.sumTreeBerry--;
            Destroy(gameObject);

        }

    }
}
