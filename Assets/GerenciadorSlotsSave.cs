using UnityEngine;
using System.Collections;

public class GerenciadorSlotsSave : MonoBehaviour {
    public UnityEngine.UI.Text SlotTextUm;
    public UnityEngine.UI.Text SlotTextDois;
    public UnityEngine.UI.Text SlotTextTres;
    public UnityEngine.UI.Text loadSlotTextUm;
    public UnityEngine.UI.Text loadSlotTextDois;
    public UnityEngine.UI.Text loadSlotTextTres;
    public StartGame start;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        SlotTextUm.text = start.gameSaveSlot1;
        SlotTextDois.text = start.gameSaveSlot2;
        SlotTextTres.text = start.gameSaveSlot3;
        loadSlotTextUm.text = start.gameSaveSlot1;
        loadSlotTextDois.text = start.gameSaveSlot2;
        loadSlotTextTres.text = start.gameSaveSlot3;
    }
}
