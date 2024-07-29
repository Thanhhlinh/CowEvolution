using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBerry : MonoBehaviour
{
    public bool isPressed;
    public GameObject berryPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        Instantiate(berryPrefab, transform.position, Quaternion.identity);
    }
}
