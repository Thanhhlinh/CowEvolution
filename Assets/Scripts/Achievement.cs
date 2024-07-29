using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievement : MonoBehaviour
{
    public GameObject[] imageSuccess;
    public Button[] getRewardBTN;
    public int[] amountDiamondsMission;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckMission();
        CheckMissionDone();
    }

    public void CheckMission()
    {
        if (GameManager.Instance.highest_Tier >= 0)
        {
            getRewardBTN[0].interactable = true;
        }
        else
        {
            getRewardBTN[0].interactable = false;
        }


        if (GameManager.Instance.highest_Tier >= 1)
        {
            getRewardBTN[1].interactable = true;

        }
        else
        {
            getRewardBTN[1].interactable = false;
        }


        if (GameManager.Instance.highest_Tier >= 2)
        {
            getRewardBTN[2].interactable = true;
            
        }
        else
        {
            getRewardBTN[2].interactable = false;
        }


        if (GameManager.Instance.highest_Tier >= 3)
        {
            getRewardBTN[3].interactable = true;
        }
        else
        {
            getRewardBTN[3].interactable = false;
        }


        if (GameManager.Instance.highest_Tier >= 4)
        {
            getRewardBTN[4].interactable = true;
        }
        else
        {
            getRewardBTN[4].interactable = false;
        }


        if (GameManager.Instance.highest_Tier >= 5)
        {
            getRewardBTN[5].interactable = true;
        }
        else
        {
            getRewardBTN[5].interactable = false;
        }


        if (GameManager.Instance.highest_Tier >= 6)
        {
            getRewardBTN[6].interactable = true;
        }
        else
        {
            getRewardBTN[6].interactable = false;
        }


        if (GameManager.Instance.highest_Tier >= 7)
        {
            getRewardBTN[7].interactable = true;

        }
        else
        {
            getRewardBTN[7].interactable = false;
        }

        if (GameManager.Instance.highest_Tier >= 8)
        {
            getRewardBTN[8].interactable = true;
        }
        else
        {
            getRewardBTN[8].interactable = false;
        }


        if (GameManager.Instance.highest_Tier >= 9)
        {
            getRewardBTN[9].interactable = true;

        }
        else
        {
            getRewardBTN[9].interactable = false;
        }


        if (GameManager.Instance.highest_Tier >= 10)
        {
            getRewardBTN[10].interactable = true;

        }
        else
        {
            getRewardBTN[10].interactable = false;
        }



        if (GameManager.Instance.highest_Tier >= 11)
        {
            getRewardBTN[11].interactable = true;

        }
        else
        {
            getRewardBTN[11].interactable = false;
        }


        if (GameManager.Instance.highest_Tier >= 12)
        {
            getRewardBTN[12].interactable = true;

        }
        else
        {
            getRewardBTN[12].interactable = false;
        }

        if (GameManager.Instance.highest_Tier >= 13)
        {
            getRewardBTN[13].interactable = true;
        }
        else
        {
            getRewardBTN[13].interactable = false;
        }


        if (GameManager.Instance.highest_Tier >= 14)
        {
            getRewardBTN[14].interactable = true;

        }
        else
        {
            getRewardBTN[14].interactable = false;
        }


        if (GameManager.Instance.highest_Tier >= 15)
        {
            getRewardBTN[15].interactable = true;

        }
        else
        {
            getRewardBTN[15].interactable = false;
        }

        if (GameManager.Instance.highest_Tier >= 16)
        {
            getRewardBTN[16].interactable = true;

        }
        else
        {
            getRewardBTN[16].interactable = false;
        }

        if (GameManager.Instance.highest_Tier >= 17)
        {
            getRewardBTN[17].interactable = true;

        }
        else
        {
            getRewardBTN[17].interactable = false;
        }

   
    }
    public void CheckMissionDone()
    {
        if (GameManager.Instance.mission[0])
        {
            getRewardBTN[0].gameObject.SetActive(false);
            getRewardBTN[0].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
        }
        if (GameManager.Instance.mission[1])
        {
            getRewardBTN[1].gameObject.SetActive(false);
            getRewardBTN[1].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
        }
        if (GameManager.Instance.mission[2])
        {
            getRewardBTN[2].gameObject.SetActive(false);
            getRewardBTN[2].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
        }
        if (GameManager.Instance.mission[3])
        {
            getRewardBTN[3].gameObject.SetActive(false);
            getRewardBTN[3].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
        }
        if (GameManager.Instance.mission[4])
        {
            getRewardBTN[4].gameObject.SetActive(false);
            getRewardBTN[4].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
        }
        if (GameManager.Instance.mission[5])
        {
            getRewardBTN[5].gameObject.SetActive(false);
            getRewardBTN[5].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
        }
        if (GameManager.Instance.mission[6])
        {
            getRewardBTN[6].gameObject.SetActive(false);
            getRewardBTN[6].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
        }
        if (GameManager.Instance.mission[7])
        {
            getRewardBTN[7].gameObject.SetActive(false);
            getRewardBTN[7].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
        }
        if (GameManager.Instance.mission[8])
        {
            getRewardBTN[8].gameObject.SetActive(false);
            getRewardBTN[8].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
        }
        if (GameManager.Instance.mission[9])
        {
            getRewardBTN[9].gameObject.SetActive(false);
            getRewardBTN[9].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
        }
        if (GameManager.Instance.mission[10])
        {
            getRewardBTN[10].gameObject.SetActive(false);
            getRewardBTN[10].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
        }
        if (GameManager.Instance.mission[11])
        {
            getRewardBTN[11].gameObject.SetActive(false);
            getRewardBTN[11].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
        }
        if (GameManager.Instance.mission[12])
        {
            getRewardBTN[12].gameObject.SetActive(false);
            getRewardBTN[12].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
        }
        if (GameManager.Instance.mission[13])
        {
            getRewardBTN[13].gameObject.SetActive(false);
            getRewardBTN[13].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
        }
        if (GameManager.Instance.mission[14])
        {
            getRewardBTN[14].gameObject.SetActive(false);
            getRewardBTN[14].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
        }
        if (GameManager.Instance.mission[15])
        {
            getRewardBTN[15].gameObject.SetActive(false);
            getRewardBTN[15].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
        }
        if (GameManager.Instance.mission[16])
        {
            getRewardBTN[16].gameObject.SetActive(false);
            getRewardBTN[16].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
        }
        if (GameManager.Instance.mission[17])
        {
            getRewardBTN[17].gameObject.SetActive(false);
            getRewardBTN[17].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
        }
    }
    public void GetReward01()
    {
        GameManager.Instance.AddDiamonds(amountDiamondsMission[0], null);
        GameManager.Instance.mission[0] = true;
        getRewardBTN[0].gameObject.SetActive(false);
        getRewardBTN[0].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
        
        
    }

    public void GetReward02()
    {
        GameManager.Instance.AddDiamonds(amountDiamondsMission[0], null);
        GameManager.Instance.mission[1] = true;
        getRewardBTN[1].gameObject.SetActive(false);
        getRewardBTN[1].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
    }

    public void GetReward03()
    {
        GameManager.Instance.AddDiamonds(amountDiamondsMission[0],null);
        GameManager.Instance.mission[2] = true;
        getRewardBTN[2].gameObject.SetActive(false);
        getRewardBTN[2].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
    }

    public void GetReward04()
    {
        GameManager.Instance.AddDiamonds(amountDiamondsMission[0], null);
        GameManager.Instance.mission[3] = true;
        getRewardBTN[3].gameObject.SetActive(false);
        getRewardBTN[3].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
    }

    public void GetReward05()
    {
        GameManager.Instance.AddDiamonds(amountDiamondsMission[0], null);
        GameManager.Instance.mission[4] = true;
        getRewardBTN[4].gameObject.SetActive(false);
        getRewardBTN[4].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
    }
    public void GetReward06()
    {
        GameManager.Instance.AddDiamonds(amountDiamondsMission[0], null);
        GameManager.Instance.mission[5] = true;
        getRewardBTN[5].gameObject.SetActive(false);
        getRewardBTN[5].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
    }
    public void GetReward07()
    {
        GameManager.Instance.AddDiamonds(amountDiamondsMission[0], null);
        GameManager.Instance.mission[6] = true;
        getRewardBTN[6].gameObject.SetActive(false);
        getRewardBTN[6].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
    }

    public void GetReward08()
    {
        GameManager.Instance.AddDiamonds(amountDiamondsMission[0], null);
        GameManager.Instance.mission[7] = true;
        getRewardBTN[7].gameObject.SetActive(false);
        getRewardBTN[7].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
    }

    public void GetReward09()
    {
        GameManager.Instance.AddDiamonds(amountDiamondsMission[0], null);
        GameManager.Instance.mission[8] = true;
        getRewardBTN[8].gameObject.SetActive(false);
        getRewardBTN[8].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
    }

    public void GetReward10()
    {
        GameManager.Instance.AddDiamonds(amountDiamondsMission[0], null);
        GameManager.Instance.mission[9] = true;
        getRewardBTN[9].gameObject.SetActive(false);
        getRewardBTN[9].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
    }

    public void GetReward11()
    {
        GameManager.Instance.AddDiamonds(amountDiamondsMission[0], null);
        GameManager.Instance.mission[10] = true;
        getRewardBTN[10].gameObject.SetActive(false);
        getRewardBTN[10].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
    }

    public void GetReward12()
    {
        GameManager.Instance.AddDiamonds(amountDiamondsMission[0], null);
        GameManager.Instance.mission[11] = true;
        getRewardBTN[11].gameObject.SetActive(false);
        getRewardBTN[11].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
    }

    public void GetReward13()
    {
        GameManager.Instance.AddDiamonds(amountDiamondsMission[0], null);
        GameManager.Instance.mission[12] = true;
        getRewardBTN[12].gameObject.SetActive(false);
        getRewardBTN[12].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
    }

    public void GetReward14()
    {
        GameManager.Instance.AddDiamonds(amountDiamondsMission[0], null);
        GameManager.Instance.mission[13] = true;
        getRewardBTN[13].gameObject.SetActive(false);
        getRewardBTN[13].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
    }

    public void GetReward15()
    {
        GameManager.Instance.AddDiamonds(amountDiamondsMission[0], null);
        GameManager.Instance.mission[14] = true;
        getRewardBTN[14].gameObject.SetActive(false);
        getRewardBTN[14].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
    }

    public void GetReward16()
    {
        GameManager.Instance.AddDiamonds(amountDiamondsMission[0], null);
        GameManager.Instance.mission[15] = true;
        getRewardBTN[15].gameObject.SetActive(false);
        getRewardBTN[15].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
    }

    public void GetReward17()
    {
        GameManager.Instance.AddDiamonds(amountDiamondsMission[0], null);
        GameManager.Instance.mission[16] = true;
        getRewardBTN[16].gameObject.SetActive(false);
        getRewardBTN[16].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
    }

    public void GetReward18()
    {
        GameManager.Instance.AddDiamonds(amountDiamondsMission[0], null);
        GameManager.Instance.mission[17] = true;
        getRewardBTN[17].gameObject.SetActive(false);
        getRewardBTN[17].gameObject.transform.parent.gameObject.transform.Find("ImageSuccess").gameObject.SetActive(true);
    }
}
