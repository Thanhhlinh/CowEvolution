using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public AchievementUI achievementUI;
    private List<Achievement> achievements = new List<Achievement>();
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;
        InitializeAchievements();
    }

    void Update()
    {
        CheckAchievements();
    }

    private void InitializeAchievements()
    {
        achievements.Add(new Achievement(0, 10));
        achievements.Add(new Achievement(1, 20));
        achievements.Add(new Achievement(2, 30));
        achievements.Add(new Achievement(3, 40));
        achievements.Add(new Achievement(4, 50));
        achievements.Add(new Achievement(5, 60));
        achievements.Add(new Achievement(6, 70));
        achievements.Add(new Achievement(7, 80));
        achievements.Add(new Achievement(8, 90));
        achievements.Add(new Achievement(9, 100));
        achievements.Add(new Achievement(10, 110));
        achievements.Add(new Achievement(11, 120));
        achievements.Add(new Achievement(12, 130));
        achievements.Add(new Achievement(13, 140));
        achievements.Add(new Achievement(14, 150));
        achievements.Add(new Achievement(15, 160));
        achievements.Add(new Achievement(16, 170));
        achievements.Add(new Achievement(17, 180));
    }

    private void CheckAchievements()
    {
        for (int i = 0; i < achievements.Count; i++)
        {
            var achievement = achievements[i];
            if (gameManager.mission[i])
            {
                achievement.Complete();
                achievementUI.UpdateButtonInteractable(i, false);
                achievementUI.ShowSuccessImage(i);
            }
            else if (!achievement.IsCompleted && gameManager.highest_Tier >= achievement.TierRequirement)
            {
                achievementUI.UpdateButtonInteractable(i, true);
            }
        }
    }

    public void ClaimReward(int index)
    {
        if (index >= 0 && index < achievements.Count)
        {
            var achievement = achievements[index];
            if (!achievement.IsCompleted)
            {
                gameManager.AddDiamonds(achievement.RewardAmount, null);
                gameManager.mission[index] = true;
                achievement.Complete();
                achievementUI.UpdateButtonInteractable(index, false);
                achievementUI.ShowSuccessImage(index);
            }
        }
    }
}
