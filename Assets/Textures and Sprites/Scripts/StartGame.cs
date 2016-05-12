using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class StartGame : MonoBehaviour {
    public String gameSaveSlot1;
    public String gameSaveId1;

    public String gameSaveSlot2;
    public String gameSaveId2;

    public String gameSaveSlot3;
    public String gameSaveId3;

    public int idDisponivel;

    public String AtualSave;
    private SaveAtual saveAtual;


    // Use this for initialization
    void Start () {
        saveAtual = (SaveAtual)GameObject.FindObjectOfType<SaveAtual>();
        Load();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void NewGame(int slotInt)
    {
        saveAtual.setGameStartType("new");
        if(slotInt==1)
        {
            Save();
            saveAtual.setSave(gameSaveSlot1);
            saveAtual.setSaveAtualId(gameSaveId1);
            saveAtual.dontDestroy();
            Application.LoadLevel(1);
        } else if(slotInt == 2)
        {
            Save();
            saveAtual.setSave(gameSaveSlot2);
            saveAtual.setSaveAtualId(gameSaveId2);
            saveAtual.dontDestroy();
            Application.LoadLevel(1);
        } else if (slotInt == 3)
        {
            Save();
            saveAtual.setSave(gameSaveSlot3);
            saveAtual.setSaveAtualId(gameSaveId3);
            saveAtual.dontDestroy();
            Application.LoadLevel(1);
        }

    }

    public void loadGame(int slotInt)
    {
        saveAtual.setGameStartType("load");
        if (slotInt == 1 && gameSaveId1!= "null")
        {
            Save();
            saveAtual.setSave(gameSaveSlot1);
            saveAtual.setSaveAtualId(gameSaveId1);
            saveAtual.dontDestroy();
            Application.LoadLevel(1);
        }
        else if (slotInt == 2 && gameSaveId2 != "null")
        {
            Save();
            saveAtual.setSave(gameSaveSlot2);
            saveAtual.setSaveAtualId(gameSaveId2);
            saveAtual.dontDestroy();
            Application.LoadLevel(1);
        }
        else if (slotInt == 3 && gameSaveId3 != "null")
        {
            Save();
            saveAtual.setSave(gameSaveSlot3);
            saveAtual.setSaveAtualId(gameSaveId3);
            saveAtual.dontDestroy();
            Application.LoadLevel(1);
        }
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/GameSaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/GameSaveData.dat", FileMode.Open);

            GameSaveData gameSaveData = (GameSaveData)bf.Deserialize(file);
            file.Close();

            this.gameSaveSlot1 = gameSaveData.gameSaveDataName1;
            this.gameSaveId1 = gameSaveData.gameSaveId1;

            this.gameSaveSlot2 = gameSaveData.gameSaveDataName2;
            this.gameSaveId2 = gameSaveData.gameSaveId2;

            this.gameSaveSlot3 = gameSaveData.gameSaveDataName3;
            this.gameSaveId3 = gameSaveData.gameSaveId3;

            this.idDisponivel = gameSaveData.idDisponivel;
        } else
        {
            this.gameSaveSlot1 = "game slot 1";
            this.gameSaveId1 = "null";

            this.gameSaveSlot2 = "game slot 2";
            this.gameSaveId2 = "null";

            this.gameSaveSlot3 = "game slot 3";
            this.gameSaveId3 = "null";

            this.idDisponivel = 0;
        }

    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/GameSaveData.dat");

        GameSaveData data = new GameSaveData();

        data.gameSaveDataName1 = this.gameSaveSlot1;
        data.gameSaveId1 = this.gameSaveId1;

        data.gameSaveDataName2 = this.gameSaveSlot2;
        data.gameSaveId2 = this.gameSaveId2;

        data.gameSaveDataName3 = this.gameSaveSlot3;
        data.gameSaveId3 = this.gameSaveId3;

        data.idDisponivel = this.idDisponivel;
        bf.Serialize(file, data);
        file.Close();
    }

    public void setSlot1(String saveName)
    {
        gameSaveSlot1 = saveName;
        gameSaveId1 = "save" + idDisponivel;
        idDisponivel++;
    }

    public void setSlot2(String saveName)
    {
        gameSaveSlot2 = saveName;
        gameSaveId2 = "save" + idDisponivel;
        idDisponivel++;
    }

    public void setSlot3(String saveName)
    {
        gameSaveSlot3 = saveName;
        gameSaveId3 = "save" + idDisponivel;
        idDisponivel++;
    }
}


[Serializable]
public class GameSaveData
{
    public String gameSaveDataName1;
    public String gameSaveId1;

    public String gameSaveDataName2;
    public String gameSaveId2;

    public String gameSaveDataName3;
    public String gameSaveId3;

    public int idDisponivel;
}
