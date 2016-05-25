using UnityEngine;
using System.Collections;

public class ControladorMenu : MonoBehaviour {

    public GameObject[] menus;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void fecharMenus()
    {
        foreach (GameObject menu in menus)
        {
            if(menu.active == true)
            {
                menu.SetActive(false);
            }
        }
    }
}
