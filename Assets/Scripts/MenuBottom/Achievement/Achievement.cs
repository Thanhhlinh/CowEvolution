using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievement : MonoBehaviour
{
    public int TierRequirement { get; private set; }
    public int RewardAmount { get; private set; }
    public bool IsCompleted { get; private set; }

    public Achievement(int tierRequirement, int rewardAmount)
    {
        TierRequirement = tierRequirement;
        RewardAmount = rewardAmount;
        IsCompleted = false;
    }

    public void Complete()
    {
        IsCompleted = true;
    }

}
