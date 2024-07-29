using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class GameManager : MonoBehaviour,IDataPersistence
{
    public static GameManager Instance;

    public GameObject[] cow_Prefabs;
    public GameObject crate_Prefab , boxEvolutionBar_Prefab;
    public GameObject[] treeBerry_Prefab;
    public GameObject newCowUI;
    public TextMeshProUGUI newCowName;
    public Image newCowImg;
    public Image fillCrateImage , fillTreeBerryImage;

    public SpriteRenderer fence;

    public string[] cow_Names;
    public Sprite[] cow_Sprites, poop_Sprites;

    public int coins ,diamonds;
    public int highest_Tier;
    public int sumCrate= 0,sumTreeBerry=0;

    public float repeatInterval = 5f;
    public float currentEvolutionBar = 0,maxEvolutionBar = 12f;
    public int index;
    public GameObject animationCoinPrefab;
    public GameObject animationDiamondPrefab;

    public int levelCrate = 0, levelBerry = 0, levelMagnet = 0, levelEvolutionBar = 0;

    public bool boughtMagnet = false;
    public bool boughtCrate = false,fullfillCrate =false;
    public bool boughtBerryDelivery = false, fullfillBerryDelivery = false;
    public bool boughtEvolutionBar = false;
    bool fullCrate,fullTreeBerry;
    public float timerSpawnTreeBerry = 10f;

    public float evolveInterval = 10f; // Khoảng thời gian giữa các lần tiến hóa tự động
    public bool isAutoEvolveEnabled = false;

    public Slider sliderEvolutionBar;
    public bool unboxEvolutionBar = false;
    public GameObject evolutionBarUI;

    public bool[] mission;
    private void Awake()
    {
        Instance = this;
        Application.targetFrameRate = 60;


    }
    // Start is called before the first frame update
    void Start()
    {
        DataPersistenceManager.Instance.Register(this);
        AddCoins(600, null);
        AddDiamonds(0, null);
        StartCoroutine(AutoEvolve());
    }

    // Update is called once per frame
    void Update()
    {
        CheckUnBoxEvolutionBar();
        CheckTreeBerrySpawn();
        CheckCrateSpawn();
        if (fullfillBerryDelivery && fullTreeBerry == false)
        {
            StartFillEffectTreeBerry();
            fullfillBerryDelivery = false;
        }
        if (fillTreeBerryImage.fillAmount > 0.98f && fullTreeBerry ==false)
        {
            SpawnTreeBerry();
            fullfillBerryDelivery = true;
        }


        if (fullfillCrate && fullCrate == false)
        {
            StartFillEffectCrate();
            fullfillCrate = false;
        }
        if (fillCrateImage.fillAmount > 0.98f && fullCrate == false)
        {
            SpawnCrate();
            fullfillCrate = true;
        }

        if (boughtEvolutionBar)
        {
            sliderEvolutionBar.value = currentEvolutionBar / maxEvolutionBar;
            if(sliderEvolutionBar.value >= 1)
            {
                SpawnBoxEvolutionBar();
            }
        }
    }

    public void SpawnCow()
    {
        Vector3 position = new Vector3(Random.Range(fence.bounds.center.x - 3.3f,fence.bounds.center.x + 3f), Random.Range(fence.bounds.center.y - 4.5f, fence.bounds.center.y + 4.7f),0);
        Instantiate(cow_Prefabs[0], position, Quaternion.identity);
    }

    public void SpawnCowAt(Vector3 position)
    {
        Instantiate(cow_Prefabs[0], position, Quaternion.identity);
    }

    public void SpawnCowLoadLevel(Vector3 position , int level)
    {
        Instantiate(cow_Prefabs[level], position, Quaternion.identity);
    }

    public void ShopSpawnCow(GameObject prefab)
    {
        Vector3 position = new Vector3(Random.Range(fence.bounds.center.x - 3.3f, fence.bounds.center.x + 3f), Random.Range(fence.bounds.center.y - 4.5f, fence.bounds.center.y + 4.7f), 0);
        Instantiate(prefab, position, Quaternion.identity);
    }

    public void EvolutionBarSpawnCow(GameObject prefab , Vector3 position)
    {
        Instantiate(prefab, position, Quaternion.identity);
    }

    public void SpawnCrate()
    { 
        Vector3 position = new Vector3(Random.Range(fence.bounds.center.x - 3.3f, fence.bounds.center.x + 3f), Random.Range(fence.bounds.center.y - 4.5f, fence.bounds.center.y + 4.7f), 0);
        Instantiate(crate_Prefab, position, Quaternion.identity);
        fillCrateImage.fillAmount = 0;
        fillCrateImage.DOKill();
        sumCrate++;
        
    }

    public void SpawnTreeBerry()
    {
        index = Random.Range(0, treeBerry_Prefab.Length);
        Vector3 position = new Vector3(Random.Range(fence.bounds.center.x - 3.3f, fence.bounds.center.x + 3f), Random.Range(fence.bounds.center.y - 4.5f, fence.bounds.center.y + 4.7f), 0);
        Instantiate(treeBerry_Prefab[index], position, Quaternion.identity);
        fillTreeBerryImage.fillAmount = 0;
        fillTreeBerryImage.DOKill();
        sumTreeBerry++;
    }

    public void SpawnBoxEvolutionBar()
    {
        Vector3 position = new Vector3(Random.Range(fence.bounds.center.x - 3.3f, fence.bounds.center.x + 3f), Random.Range(fence.bounds.center.y - 4.5f, fence.bounds.center.y + 4.7f), 0);
        Instantiate(boxEvolutionBar_Prefab, position, Quaternion.identity);
        currentEvolutionBar = 0;
        sumCrate++;
    }

    public void StartMagnet()
    {
        boughtMagnet = true;
    }

    public void StartCrateSpawn()
    {
        boughtCrate = true;
        fullfillCrate = true;
    }
    public void StartEvolutionBarSpawn()
    {
        boughtEvolutionBar = true;
    }


    void StartFillEffectCrate()
    {
        fillCrateImage.fillAmount = 0;
        fillCrateImage.DOFillAmount(1f, repeatInterval);
        
    }
    public void StartBerryDeliverySpawn()
    {
        boughtBerryDelivery = true;
        fullfillBerryDelivery = true;
    }

    void StartFillEffectTreeBerry()
    {
        fillTreeBerryImage.fillAmount = 0;
        fillTreeBerryImage.DOFillAmount(1f, timerSpawnTreeBerry);
        
    }

    public void CheckCrateSpawn()
    {
        if(sumCrate < 7 && fullCrate== true)
        {
            fullCrate = false;
            
        }
        if (sumCrate >=7)
        {
            fullCrate = true;
        }
    }

    public void CheckTreeBerrySpawn()
    {
        if (sumTreeBerry < 1 && fullTreeBerry == true)
        {
            fullTreeBerry = false;
        }
        if (sumTreeBerry >= 1)
        {
            fullTreeBerry = true;
        }

    }

    public void CheckUnBoxEvolutionBar()
    {
        if(unboxEvolutionBar == true)
        {
            evolutionBarUI.SetActive(true);
        }
        else
        {
            evolutionBarUI.SetActive(false);
        }
    }
    public void AddCoins(int amount,Transform pos)
    {
        if (AudioManager.Instance.soundEffectToggle.isOn)
        {
            AudioManager.Instance.PlayAddCoinSound();
        }
        if (pos != null)
        {
            GameObject animationCoin = Instantiate(animationCoinPrefab, pos);
            TextMeshProUGUI textMeshPro = animationCoin.GetComponentInChildren<TextMeshProUGUI>();         
            if (textMeshPro != null)
            {
                textMeshPro.text = amount.ToString();
            }
            Destroy(animationCoin,1f);
        }
        coins += amount;
        Texts.Instance.ChangeTextCoins(coins);
    }

    public void SpendCoins(int amount)
    {
        if (AudioManager.Instance.soundEffectToggle.isOn)
        {
            AudioManager.Instance.PlaySpendCoinSound();
        }
        coins += amount;
        Texts.Instance.ChangeTextCoins(coins);
    }

    public void AddDiamonds(int amount, Transform pos)
    {
        if (pos != null)
        {
            GameObject animationDiamond = Instantiate(animationDiamondPrefab, pos);
            TextMeshProUGUI textMeshPro = animationDiamond.GetComponentInChildren<TextMeshProUGUI>();
            if (textMeshPro != null)
            {
                textMeshPro.text = amount.ToString();
            }
            Destroy(animationDiamond, 1f);
        }
        diamonds += amount;
        Texts.Instance.ChangeTextDiamonds(diamonds);
    }

    public void SpendDiamonds(int amount)
    {
        if (AudioManager.Instance.soundEffectToggle.isOn)
        {
            AudioManager.Instance.PlaySpendCoinSound();
        }
        diamonds += amount;
        Texts.Instance.ChangeTextDiamonds(diamonds);
    }

    public void CheckTier(int tier)
    {
        if(tier > highest_Tier)
        {
            highest_Tier = tier;
            StartCoroutine(newTier());
        }
    }

    IEnumerator newTier()
    {
        newCowUI.SetActive(true);
        newCowName.text = cow_Names[highest_Tier];
        newCowImg.sprite = cow_Sprites[highest_Tier];
        yield return new WaitForSeconds(2);
        newCowUI.SetActive(false);
    }


    private IEnumerator AutoEvolve()
    {
        while (true)
        {
            yield return new WaitForSeconds(evolveInterval);
            if (isAutoEvolveEnabled)
            {
                TryAutoEvolve();
            }
        }
    }

    private void TryAutoEvolve()
    {
        Cow[] cows = FindObjectsOfType<Cow>();

        // Bắt đầu từ cấp cao nhất và lùi dần
        for (int currentTier = GetHighestTier(cows); currentTier >= 0; currentTier--)
        {
            List<Cow> sameTierCows = new List<Cow>();

            foreach (var cow in cows)
            {
                if (cow.tier == currentTier)
                {
                    sameTierCows.Add(cow);
                }
            }

            if (sameTierCows.Count >= 2)
            {
                Cow cow1 = sameTierCows[0];
                Cow cow2 = sameTierCows[1];
                if (cow1.eatBerry == true)
                {
                    cow1.Evolve();
                    Destroy(cow2.gameObject);
                }
                else if (cow2.eatBerry == true)
                {
                    cow2.Evolve();
                    Destroy(cow1.gameObject);
                }
                else
                {
                    cow1.Evolve();
                    Destroy(cow2.gameObject);
                }          
                break;
            }
            else
            {
                sameTierCows.Clear();
            }
        }
    }

    private int GetHighestTier(Cow[] cows)
    {
        int highestTier = -1;
        foreach (var cow in cows)
        {
            if (cow.tier > highestTier)
            {
                highestTier = cow.tier;
            }
        }
        return highestTier;
    }

    public void LoadData(GameData data)
    {
        /*for (int i = 0; i < mission.Length; i++)
        {
            mission[i] = data.mission[i];
        }*/


        mission = data.mission;
        boughtMagnet = data.boughtMagnet;
        boughtBerryDelivery = data.boughtBerryDelivery;
        boughtEvolutionBar = data.boughtEvolutionBar;
        boughtCrate = data.boughtCrate;
        isAutoEvolveEnabled = data.isAutoEvolveEnabled;
        maxEvolutionBar = data.maxEvolutionBar;
        repeatInterval = data.repeatInterval;
        timerSpawnTreeBerry = data.timerSpawnTreeBerry;
        evolveInterval = data.evolveInterval;
        coins = data.coins;
        diamonds = data.diamonds;
        highest_Tier = data.highest_Tier;
        levelBerry = data.levelBerry ;
        levelCrate = data.levelCrate ;
        levelEvolutionBar = data.levelEvolutionBar;
        levelMagnet = data.levelMagnet;
        Texts.Instance.ChangeTextCoins(coins);
        Texts.Instance.ChangeTextDiamonds(diamonds);
        if (boughtCrate)
        {
            StartFillEffectCrate();
        }
        if (boughtBerryDelivery)
        {
            StartFillEffectTreeBerry();
        }
    }

    public void SaveData(GameData data)
    {
        data.boughtMagnet = boughtMagnet;
        data.boughtBerryDelivery = boughtBerryDelivery;
        data.boughtCrate = boughtCrate;
        data.boughtEvolutionBar = boughtEvolutionBar;
        data.isAutoEvolveEnabled = isAutoEvolveEnabled;
        data.maxEvolutionBar = maxEvolutionBar;
        data.repeatInterval = repeatInterval;
        data.timerSpawnTreeBerry = timerSpawnTreeBerry;
        data.evolveInterval = evolveInterval;
        data.coins = coins;
        data.diamonds = diamonds;
        data.highest_Tier = highest_Tier;
        data.levelBerry = levelBerry;
        data.levelCrate = levelCrate;
        data.levelEvolutionBar = levelEvolutionBar;
        data.levelMagnet = levelMagnet;
        data.mission = mission;
    }
}
