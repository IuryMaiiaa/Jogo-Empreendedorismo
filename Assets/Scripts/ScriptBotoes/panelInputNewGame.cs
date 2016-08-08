using UnityEngine;
using System.Collections;

public class panelInputNewGame : MonoBehaviour {
    private int slotInt;
    public UnityEngine.UI.InputField inputSlot;
    public GameObject panelAnterior;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update() {
        if(Input.GetKey(KeyCode.Escape))
        {
            GameObject.FindObjectOfType<MenuGerenciamento>().ativarPanel(panelAnterior);
        }
    }

    public void setSaveAndNewGame()
    {
        if(slotInt==1)
        {
            GameObject.FindObjectOfType<StartGame>().setSlot1(inputSlot.text);
            newGame();
        } else if(slotInt==2)
        {
            GameObject.FindObjectOfType<StartGame>().setSlot2(inputSlot.text);
            newGame();
        } else if(slotInt==3)
        {
            GameObject.FindObjectOfType<StartGame>().setSlot3(inputSlot.text);
            newGame();
        }

    }


    public void setSlotInt(int slotInt)
    {
        this.slotInt = slotInt;
    }

    public void newGame()
    {
        GameObject.FindObjectOfType<StartGame>().NewGame(slotInt);
    }

}
