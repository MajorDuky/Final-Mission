using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public Color TeamColor;
    [SerializeField] private string savePath = "/savefile.json";

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + savePath, json);
    }
    public void LoadColor()
    {
        if (File.Exists(Application.persistentDataPath + savePath))
        {
            string json = File.ReadAllText(Application.persistentDataPath + savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            TeamColor = data.TeamColor;
        }
    }
}

[System.Serializable]
public class SaveData
{
    public Color TeamColor;
}
