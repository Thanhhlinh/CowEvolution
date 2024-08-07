
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;
    public GameObject crate_Prefab, boxEvolutionBar_Prefab;
    public GameObject[] cow_Prefabs;
    public GameObject[] treeBerry_Prefab;
    public SpriteRenderer fence;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }

    
    public void SpawnCow()
    {
        Vector3 position = new Vector3(Random.Range(fence.bounds.center.x - 3.3f, fence.bounds.center.x + 3f), Random.Range(fence.bounds.center.y - 4.5f, fence.bounds.center.y + 4.7f), 0);
        Instantiate(cow_Prefabs[0], position, Quaternion.identity);
    }

    public void SpawnCowAt(Vector3 position)
    {
        Instantiate(cow_Prefabs[0], position, Quaternion.identity);
    }

    public void SpawnCowLoadLevel(Vector3 position, int level)
    {
        Instantiate(cow_Prefabs[level], position, Quaternion.identity);
    }

    public void ShopSpawnCow(GameObject prefab)
    {
        Vector3 position = new Vector3(Random.Range(fence.bounds.center.x - 3.3f, fence.bounds.center.x + 3f), Random.Range(fence.bounds.center.y - 4.5f, fence.bounds.center.y + 4.7f), 0);
        Instantiate(prefab, position, Quaternion.identity);
    }

    public void EvolutionBarSpawnCow(GameObject prefab, Vector3 position)
    {
        Instantiate(prefab, position, Quaternion.identity);
    }

    public void SpawnCrate()
    {
        Vector3 position = new Vector3(Random.Range(fence.bounds.center.x - 3.3f, fence.bounds.center.x + 3f), 9, 0);
        Instantiate(crate_Prefab, position, Quaternion.identity);
        GameManager.Instance.fillCrateImage.fillAmount = 0;
        GameManager.Instance.fillCrateImage.DOKill();
        GameManager.Instance.sumCrate++;

    }

    public void SpawnTreeBerry()
    {
        GameManager.Instance.index = Random.Range(0, treeBerry_Prefab.Length);
        Vector3 position = new Vector3(Random.Range(fence.bounds.center.x - 3.3f, fence.bounds.center.x + 3f), Random.Range(fence.bounds.center.y - 4.5f, fence.bounds.center.y + 4.7f), 0);
        Instantiate(treeBerry_Prefab[GameManager.Instance.index], position, Quaternion.identity);
        GameManager.Instance.fillTreeBerryImage.fillAmount = 0;
        GameManager.Instance.fillTreeBerryImage.DOKill();
        GameManager.Instance.sumTreeBerry++;
    }

    public void SpawnBoxEvolutionBar()
    {
        Vector3 position = new Vector3(Random.Range(fence.bounds.center.x - 3.3f, fence.bounds.center.x + 3f), Random.Range(fence.bounds.center.y - 4.5f, fence.bounds.center.y + 4.7f), 0);
        Instantiate(boxEvolutionBar_Prefab, position, Quaternion.identity);
        GameManager.Instance.currentEvolutionBar = 0;
        GameManager.Instance.sumCrate++;
    }
}
