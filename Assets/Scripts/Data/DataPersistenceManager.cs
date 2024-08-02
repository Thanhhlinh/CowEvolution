using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    public static DataPersistenceManager Instance { get; private set; }

    private List<IDataPersistence> dataPersistences;
    public string saveFilePath;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        dataPersistences = new List<IDataPersistence>();
        saveFilePath = Path.Combine(Application.persistentDataPath, "gamedata.json");
    }

    public void Register(IDataPersistence dataPersistence)
    {
        if (!dataPersistences.Contains(dataPersistence))
        {
            dataPersistences.Add(dataPersistence);
        }
    }

    public void SaveGame()
    {
        GameData data = new GameData();
        foreach (IDataPersistence dataPersistence in dataPersistences)
        {
            dataPersistence.SaveData(data);
        }

        string json = JsonUtility.ToJson(data);
        
        string encryptedJson = EncryptionUtility.Encrypt(json);
        /*File.WriteAllText(saveFilePath, encryptedJson);*/
        using (StreamWriter writer = new StreamWriter(saveFilePath))
        {
            writer.Write(encryptedJson);
        }
    }

    public void LoadGame()
    {
        Debug.Log(saveFilePath);
        if (File.Exists(saveFilePath))
        {
            using (StreamReader reader = new StreamReader(saveFilePath))
            {
                string encryptedJson = reader.ReadToEnd();
                Debug.Log("JSON: " + encryptedJson);
                try
                {
                    string json = EncryptionUtility.Decrypt(encryptedJson);
                    GameData data = JsonUtility.FromJson<GameData>(json);
                    foreach (IDataPersistence dataPersistence in dataPersistences)
                    {
                        dataPersistence.LoadData(data);
                    }
                }
                catch (ArgumentException e)
                {
                    Debug.LogError("Failed to deserialize JSON to GameData: " + e.Message);
                }
            }
            

            /*string encryptedJson = File.ReadAllText(saveFilePath);
            Debug.Log("JSON: " + encryptedJson);

            try
            {
                string json = EncryptionUtility.Decrypt(encryptedJson);
                GameData data = JsonUtility.FromJson<GameData>(json);
                foreach (IDataPersistence dataPersistence in dataPersistences)
                {
                    dataPersistence.LoadData(data);
                }
            }
            catch (ArgumentException e)
            {
                Debug.LogError("Failed to deserialize JSON to GameData: " + e.Message);
            }*/
        }
    }

    private void OnApplicationQuit()
    {  
        SaveGame();
    }
}
