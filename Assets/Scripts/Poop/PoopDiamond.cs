using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopDiamond : MonoBehaviour
{
    public Transform pos;
    private ICommandPoop dissapearCommand;
    // Start is called before the first frame update
    void Start()
    {
        dissapearCommand = new DissapearDiamondCommand(this);
        dissapearCommand.ExecuteDiamond();
    }

    public IEnumerator Dissapear()
    {
        yield return new WaitForSeconds(1);
        GameManager.Instance.AddDiamonds(1, pos);
        Destroy(gameObject);
    }
}
