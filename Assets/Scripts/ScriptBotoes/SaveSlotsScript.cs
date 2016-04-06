using UnityEngine;
using System.Collections;

public class SaveSlotsScript : MonoBehaviour,InterfaceBotao {
    public Transform NavePosicao;
    public int setSlotSave;
    public GameObject inputSaveNamePanel;

    public void botaoAcao()
    {
        inputSaveNamePanel.SetActive(true);
        inputSaveNamePanel.GetComponent<panelInputNewGame>().setSlotInt(setSlotSave);
        GameObject.FindObjectOfType<MenuGerenciamento>().ativarPanel(inputSaveNamePanel);
    }

    public Transform getPosicaoNave()
    {
        return NavePosicao;
    }


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
