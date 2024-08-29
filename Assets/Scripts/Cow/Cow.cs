using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class Cow : MonoBehaviour, IDataPersistence
{
    public int tier, poopTier, speed;
    public ParticleSystem evolveEffect;
    public Poop poop;
    public PoopDiamond poopDiamond;
    public bool isDragged, hasDestination;
    public Vector3 offSet, destination;

    public bool eatBerry = false;

    private Coroutine poopCoroutine;

    public SpriteRenderer spriteRenderer;

    public Transform hatPosition;
    public GameObject currentHat;


    /*private IMoveable movement;*/
    private IPoopable pooping;
    private IHatManager hatManager;



    StateBaseCow currentStateCow;
    public CowIdleState idleState = new CowIdleState();
    public CowMoveState moveState = new CowMoveState();


    public void SwitchState(StateBaseCow state)
    {
        currentStateCow = state;
        state.EnterState(this);
    }



    // Start is called before the first frame update
    void Start()
    {
        AnimationCow();
        DataPersistenceManager.Instance.Register(this);
        spriteRenderer = GetComponent<SpriteRenderer>();
        /*movement = new CowMovement(transform, spriteRenderer, hatPosition, currentHat, tier);*/
        pooping = new CowPooping(poop, poopDiamond, tier);
        hatManager = new CowHatManager(hatPosition, currentHat);
        SetCow();

        currentStateCow = idleState;
        currentStateCow.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (tier >= 6 && tier <= 12)
        {
            gameObject.GetComponent<SortingGroup>().sortingOrder = 1;
        }
        else if (tier > 12)
        {
            gameObject.GetComponent<SortingGroup>().sortingOrder = 2;
        }

        /*if (!isDragged && hasDestination)
        {
            if (Vector3.Distance(transform.position, destination) > 0.1f)
            {
                movement.Move(destination, speed);
            }
            else
            {
                hasDestination = false;
                Take_Poop();
                StartCoroutine(WaitPoop());
            }
        }*/
        CheckColor();
        currentStateCow.UpdateState(this);
    }
    /*IEnumerator WaitPoop()
    {
        yield return new WaitForSeconds(2f);
        SetRandomDestination();
    }

    public void SetRandomDestination()
    {
        if (!hasDestination)
        {
            destination = GetRandomPosition();
            hasDestination = true;
        }
    }*/

    /*private Vector3 GetRandomPosition()
    {
        float x = Random.Range(SpawnManager.Instance.fence.bounds.center.x - 3.3f, SpawnManager.Instance.fence.bounds.center.x + 3f);
        float y = Random.Range(SpawnManager.Instance.fence.bounds.center.y - 4.5f, SpawnManager.Instance.fence.bounds.center.y + 4.7f);
        if (tier >= 6 && tier <= 11)
        {
            return new Vector3(x, y, -12);
        }
        else if (tier > 11)
        {
            return new Vector3(x, y, -22);
        }
        else
        {
            return new Vector3(x, y, 0);
        }
    }*/


    public void AnimationCow()
    {
        Vector3 targetScale = new Vector3(1.25f, 1.25f, 1);
        float duration = 1f;
        transform.DOScale(targetScale, duration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }
    public void CheckColor()
    {
        if (ChangeColorCow.Instance != null)
        {
            if (tier == 0 && eatBerry == false)
            {
                spriteRenderer.color = ChangeColorCow.Instance.colorCow[0];
            }
            else if (tier == 1 && eatBerry == false)
            {
                spriteRenderer.color = ChangeColorCow.Instance.colorCow[1];
            }
            else if (tier == 2 && eatBerry == false)
            {
                spriteRenderer.color = ChangeColorCow.Instance.colorCow[2];
            }
            else if (tier == 3 && eatBerry == false)
            {
                spriteRenderer.color = ChangeColorCow.Instance.colorCow[3];
            }
            else if (tier == 4 && eatBerry == false)
            {
                spriteRenderer.color = ChangeColorCow.Instance.colorCow[4];
            }
            else if (tier == 5 && eatBerry == false)
            {
                spriteRenderer.color = ChangeColorCow.Instance.colorCow[5];
            }
            else if (tier == 6 && eatBerry == false)
            {
                spriteRenderer.color = ChangeColorCow.Instance.colorCow[6];
            }
            else if (tier == 7 && eatBerry == false)
            {
                spriteRenderer.color = ChangeColorCow.Instance.colorCow[7];
            }
            else if (tier == 8 && eatBerry == false)
            {
                spriteRenderer.color = ChangeColorCow.Instance.colorCow[8];
            }
            else if (tier == 9 && eatBerry == false)
            {
                spriteRenderer.color = ChangeColorCow.Instance.colorCow[9];
            }
            else if (tier == 10 && eatBerry == false)
            {
                spriteRenderer.color = ChangeColorCow.Instance.colorCow[10];
            }
            else if (tier == 11 && eatBerry == false)
            {
                spriteRenderer.color = ChangeColorCow.Instance.colorCow[11];
            }
            else if (tier == 12 && eatBerry == false)
            {
                spriteRenderer.color = ChangeColorCow.Instance.colorCow[12];
            }
            else if (tier == 13 && eatBerry == false)
            {
                spriteRenderer.color = ChangeColorCow.Instance.colorCow[13];
            }
            else if (tier == 14 && eatBerry == false)
            {
                spriteRenderer.color = ChangeColorCow.Instance.colorCow[14];
            }
            else if (tier == 15 && eatBerry == false)
            {
                spriteRenderer.color = ChangeColorCow.Instance.colorCow[15];
            }
            else if (tier == 16 && eatBerry == false)
            {
                spriteRenderer.color = ChangeColorCow.Instance.colorCow[16];
            }
            else if (tier == 17 && eatBerry == false)
            {
                spriteRenderer.color = ChangeColorCow.Instance.colorCow[17];
            }
        }

    }

    public void SetCow()
    {
        hatPosition.localScale = Vector3.one;
        GetComponent<SpriteRenderer>().sprite = GameManager.Instance.cow_Sprites[tier];
        UpdateICommand();
        hasDestination = false;
        /*SetRandomDestination();*/
        GameManager.Instance.CheckTier(tier);
        UpdateHatOnLevelChange(tier);
        poopTier = tier;
    }

    public void Evolve()
    {
        if (AudioManager.Instance.soundEffectToggle.isOn)
        {
            AudioManager.Instance.PlayEvolveSound();
        }
        tier++;

        SetCow();
    }
    public void ContinuousPoop(bool isRunning)
    {
        if (isRunning)
        {
            if (poopCoroutine == null) // Kiểm tra nếu Coroutine chưa chạy
            {
                poopCoroutine = StartCoroutine(EffectPoop());
            }
        }
        else
        {
            if (poopCoroutine != null) // Kiểm tra nếu Coroutine đang chạy
            {
                StopCoroutine(poopCoroutine);
                poopCoroutine = null;
            }
        }
    }
    IEnumerator EffectPoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            Take_Poop();
        }
    }

    public void PoopDiamond()
    {
        pooping.TakePoopDiamond(transform);
    }

    public void Take_Poop()
    {
        pooping.TakePoop(transform, gameObject);
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
        Take_Poop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDragged)
        {
            if (collision.CompareTag("Cow"))
            {
                if (collision.GetComponent<Cow>().tier == tier)
                {
                    Evolve();
                    Destroy(collision.gameObject);
                }
            }
        }

    }


    public void EquipHat(GameObject hatPrefab)
    {

        if (spriteRenderer.flipX == true)
        {
            hatPosition.localScale = new Vector3(-1, 1, 1);
        }
        hatManager = new CowHatManager(hatPosition, currentHat);
        hatManager.EquipHat(hatPrefab, tier);
        currentHat = hatManager.GetCurrentHat();
        UpdateICommand();
    }

    public void RemoveCurrentHat()
    {
        hatManager.RemoveHat();
        currentHat = hatManager.GetCurrentHat();
        UpdateICommand();

    }
    public void UpdateHatOnLevelChange(int newTier)
    {

        hatManager.UpdateHatOnLevelChange(newTier);
        currentHat = hatManager.GetCurrentHat();
        UpdateICommand();
    }

    private void UpdateICommand()
    {
        pooping = new CowPooping(poop, poopDiamond, tier);
        /*movement = new CowMovement(transform, spriteRenderer, hatPosition, currentHat, tier);*/
        hatManager = new CowHatManager(hatPosition, currentHat);
    }


    public bool HasHat()
    {
        return currentHat != null;
    }

    public void LoadData(GameData data)
    {

    }

    public void SaveData(GameData data)
    {
        if (this == null)
        {
            return;
        }
        CowData cowData = new CowData
        {
            tiers = tier,
            poopTiers = poopTier,
            speeds = speed,
            positions = transform.position,
        };
        data.cows.Add(cowData);
    }

}
