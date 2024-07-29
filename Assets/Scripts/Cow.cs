using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour,IDataPersistence
{
    public int tier, poopTier,speed;
    public ParticleSystem evolveEffect;
    public Poop poop;
    public PoopDiamond poopDiamond;
    public bool isDragged , hasDestination;
    Vector3 offSet , destination;

    public bool eatBerry = false;

    private Coroutine poopCoroutine;
    
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        DataPersistenceManager.Instance.Register(this);
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetCow();
        InvokeRepeating("Take_Poop",1,3);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!isDragged)
        {
            if(hasDestination)
            {

                if(Vector3.Distance(transform.position,destination) > 0.1f)
                {
                    Vector3 direction = destination - transform.position;
                    if (direction.x > 0)
                    {
                        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                    }
                    else if (direction.x < 0)
                    {
                        transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                    }
                    if (tier >= 6 && tier <=11)
                    {
                        if(destination.z >= 0)
                        {
                            destination.z = -12;
                        }
                        transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y,-12), destination, speed * Time.deltaTime);
                        
                    }else if (tier > 11)
                    {
                        transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, -22), destination, speed * Time.deltaTime);
                    }
                    else
                    {
                        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
                    }
                    
                }
                else
                {
                    hasDestination = false;
                }
            }
            else
            {
                if(tier >= 6 && tier <= 11)
                {
                    destination = new Vector3(Random.Range(GameManager.Instance.fence.bounds.center.x - 3.3f, GameManager.Instance.fence.bounds.center.x + 3f), Random.Range(GameManager.Instance.fence.bounds.center.y - 4.5f, GameManager.Instance.fence.bounds.center.y + 4.7f), -12);
                    hasDestination = true;
                }else if (tier >11)
                {
                    destination = new Vector3(Random.Range(GameManager.Instance.fence.bounds.center.x - 3.3f, GameManager.Instance.fence.bounds.center.x + 3f), Random.Range(GameManager.Instance.fence.bounds.center.y - 4.5f, GameManager.Instance.fence.bounds.center.y + 4.7f), -22);
                    hasDestination = true;
                }
                else
                {
                    destination = new Vector3(Random.Range(GameManager.Instance.fence.bounds.center.x - 3.3f, GameManager.Instance.fence.bounds.center.x + 3f), Random.Range(GameManager.Instance.fence.bounds.center.y - 4.5f, GameManager.Instance.fence.bounds.center.y + 4.7f), 0);
                    hasDestination = true;
                }
                
            }
        }
        CheckColor();
    }

    public void CheckColor()
    {
        if(ChangeColorCow.Instance != null)
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
        GetComponent<SpriteRenderer>().sprite = GameManager.Instance.cow_Sprites[tier];   
        poopTier = tier;
    }

    public void Evolve()
    {
        if(GameManager.Instance.index == 2 && eatBerry)
        {
            GameManager.Instance.AddCoins((int)Mathf.Pow(10, poopTier), transform);
            GameManager.Instance.AddCoins((int)Mathf.Pow(10, poopTier), transform);
            GameManager.Instance.AddCoins((int)Mathf.Pow(10, poopTier), transform);
            GameManager.Instance.AddCoins((int)Mathf.Pow(10, poopTier), transform);
            GameManager.Instance.AddCoins((int)Mathf.Pow(10, poopTier), transform);
        }
        evolveEffect.Play();
        if (AudioManager.Instance.soundEffectToggle.isOn)
        {
            AudioManager.Instance.PlayEvolveSound();
        }
        tier++;
        GameManager.Instance.CheckTier(tier);
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
        PoopDiamond poop = Instantiate(poopDiamond,transform.position, Quaternion.identity);
        poop.pos = transform;   
    }

    public void Take_Poop()
    {
        if (AudioManager.Instance.soundEffectToggle.isOn)
        {
            AudioManager.Instance.PlayPoopSound();
        }  
        Poop newPoop = Instantiate(poop,transform.position,Quaternion.identity);
        newPoop.pos = transform;
        int index = Random.Range(0, 2);
        if (tier >= 6)
        {
            newPoop.tier = 4;
        }
        else
        {
            if (index == 1)
            {
                newPoop.tier = poopTier + 1;
            }
            else
            {
                newPoop.tier = poopTier;
            }
        }
        
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
        if(isDragged)
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

    private void OnTriggerStay2D(Collider2D collision)
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

    public void LoadData(GameData data)
    {
        /*foreach (CowData cowData in data.cows)
        {
            tier = cowData.tiers;
            poopTier = cowData.poopTiers;
            speed = cowData.speeds;
        }*/
    }

    public void SaveData(GameData data)
    {
        if (this == null)
        {
            Debug.LogWarning("Attempted to save a Cow object that has been destroyed.");
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
