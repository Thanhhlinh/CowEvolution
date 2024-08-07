using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour
{
    public int tier;
    public Transform pos;
    private ICommandPoop dissapearCommand;
    // Start is called before the first frame update
    void Start()
    {
        dissapearCommand = new DissapearCommand(this);
        dissapearCommand.Execute();
    }

    public IEnumerator Dissapear()
    {
        yield return new WaitForSeconds(1);
        GameManager.Instance.AddCoins((int)Mathf.Pow(10, tier), pos);
        Destroy(gameObject);
    }
}
