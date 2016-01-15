using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class StartGame : MonoBehaviour {
    public String gameSaveSlot1;
    public String gameSaveSlot2;
    public String gameSaveSlot3;
    public String AtualSave;


    // Use this for initialization
    void Start () {
        Load();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void NewGame()
    {
        Application.LoadLevel(1);
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/GameSaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/GameSaveData.dat", FileMode.Open);

            GameSaveData gameSaveData = (GameSaveData)bf.Deserialize(file);
            file.Close();

            this.gameSaveSlot1 = gameSaveData.gameSaveData1;
            this.gameSaveSlot2 = gameSaveData.gameSaveData2;
            this.gameSaveSlot3 = gameSaveData.gameSaveData3;
        } else
        {
            this.gameSaveSlot1 = "game slot 1";
            this.gameSaveSlot2 = "game slot 2";
            this.gameSaveSlot3 = "game slot 3";
        }

    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/GameSaveData.dat");

        GameSaveData data = new GameSaveData();

        data.gameSaveData1 = this.gameSaveSlot1;
        data.gameSaveData2 = this.gameSaveSlot2;
        data.gameSaveData3 = this.gameSaveSlot3;

        bf.Serialize(file, data);
        file.Close();
    }
}


[Serializable]
public class GameSaveData
{
    public String gameSaveData1;
    public String gameSaveData2;
    public String gameSaveData3;
}
