using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxEvolutionBarUI : MonoBehaviour
{ 
    public GameObject[] cowPrefabs;
    public float timeRandom = 2f;
    public int numberRandom;
    public Image imageRandom;
    public Button takeitBTN;
    private Sprite oldSprite;
    bool isRun;
    // Start is called before the first frame update
    void Start()
    {
        oldSprite = imageRandom.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRandom > 0)
        {
            timeRandom -= Time.deltaTime;
            takeitBTN.gameObject.SetActive(false);
        }
        else if(isRun == false) 
        {
            takeitBTN.gameObject.SetActive(true);
        }
        if(GameManager.Instance.unboxEvolutionBar == true && isRun == false)
        {
            StartCoroutine(EffectRandom()); 
        }
             
    }

    public void TakeIt()
    {
        SpawnManager.Instance.EvolutionBarSpawnCow(cowPrefabs[numberRandom], new Vector3(0,0,0));
        timeRandom = 5f;
        imageRandom.sprite = oldSprite;
        isRun = false;
        GameManager.Instance.unboxEvolutionBar = false;
    }

    IEnumerator EffectRandom()
    {
        isRun = true;
        while (timeRandom > 0)
        {
            yield return new WaitForSeconds(0.5f);
            
            if (GameManager.Instance.highest_Tier != 0)
            {
                numberRandom = Random.Range(0, GameManager.Instance.highest_Tier);

            }
            else
            {
                numberRandom = Random.Range(0, 1);
            }
            Debug.Log(timeRandom);
            imageRandom.GetComponent<Image>().sprite = GameManager.Instance.cow_Sprites[numberRandom];
        }
        isRun = false;
    }
}
