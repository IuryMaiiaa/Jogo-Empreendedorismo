using UnityEngine;
using System.Collections;

public class LoadSlotScript : MonoBehaviour, InterfaceBotao{
    public Transform NavePosicao;
    public int setSlotLoad;

    public void botaoAcao()
    {
        GameObject.FindObjectOfType<StartGame>().loadGame(setSlotLoad);
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
