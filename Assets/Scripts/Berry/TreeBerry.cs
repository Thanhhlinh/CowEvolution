using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBerry : MonoBehaviour
{
    public bool isPressed;
    public GameObject berryPrefab;

    private void OnMouseDown()
    {
        Destroy(gameObject);
        Instantiate(berryPrefab, transform.position, Quaternion.identity);
    }
}
