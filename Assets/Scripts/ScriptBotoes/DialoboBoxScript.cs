using UnityEngine;
using System.Collections;

public class DialoboBoxScript : MonoBehaviour {
    public GameObject dialogoBox;
    public GameObject minhaturaNPC;
    public GameObject menuStatus;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void falaPerssonagem()
    {
        dialogoBox.SetActive(true);
        minhaturaNPC.SetActive(true);
        menuStatus.SetActive(false);
    }

    public void fecharDialogo()
    {
        dialogoBox.SetActive(false);
        minhaturaNPC.SetActive(false);
        menuStatus.SetActive(true);
    }
}
