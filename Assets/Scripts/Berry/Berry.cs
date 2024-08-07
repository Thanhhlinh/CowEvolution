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

    private IBerryCommand berryCommand;
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
                if (IsCowInMap1(cow))
                {
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    SetCommand();
                    StartCoroutine(ExecuteCommandCoroutine());
                }
                else
                {
                    Debug.Log("Cow is not in map 1");
                }
            }
        }
    }

    private void SetCommand()
    {
        switch (GameManager.Instance.index)
        {
            case 0:
                berryCommand = new BerryIndex0Command(color, timer);
                break;
            case 1:
                berryCommand = new BerryIndex1Command(color, timer);
                break;
            case 2:
                berryCommand = new BerryIndex2Command(color, timer);
                break;
            case 3:
                berryCommand = new BerryIndex3Command(color, timer);
                break;
            default:
                throw new System.ArgumentOutOfRangeException();
        }
    }

    private IEnumerator ExecuteCommandCoroutine()
    {
        if (berryCommand != null)
        {
            yield return StartCoroutine(berryCommand.ExecuteCoroutine(cow.GetComponent<Cow>()));
            Destroy(gameObject);
        }
    }
    private bool IsCowInMap1(GameObject cow)
    {

        return cow.transform.position.z == 0;

    }
}
