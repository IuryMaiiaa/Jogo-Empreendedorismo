using UnityEngine;
using System.Collections;

public class SaveAtual : MonoBehaviour {
    private string saveAtual;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setSave(string newSave)
    {
        saveAtual = newSave;
    }

    public string getSave()
    {
        return saveAtual;
    }

    public void dontDestroy()
    {
        Object.DontDestroyOnLoad(this);
    }
}
