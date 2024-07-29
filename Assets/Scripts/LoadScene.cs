using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public DataPersistenceManager dataPersistenceManager;
    

    private void Start()
    {
        LoadGame();
    }

    private void Update()
    {
    }

    private void LoadGame()
    {
        dataPersistenceManager.LoadGame();
        using (StreamReader reader = new StreamReader(dataPersistenceManager.saveFilePath))
        {
            string encryptedJson = reader.ReadToEnd();
            string json = EncryptionUtility.Decrypt(encryptedJson);
            GameData data = JsonUtility.FromJson<GameData>(json);
            foreach (CowData cowData in data.cows)
            {
                GameManager.Instance.SpawnCowLoadLevel(cowData.positions, cowData.tiers);
            }
        }
        /*string encryptedJson = File.ReadAllText(dataPersistenceManager.saveFilePath);
        string json = EncryptionUtility.Decrypt(encryptedJson);
        GameData data = JsonUtility.FromJson<GameData>(json);
        foreach (CowData cowData in data.cows)
        {
            GameManager.Instance.SpawnCowLoadLevel(cowData.positions,cowData.tiers);
        }*/
    }
}
