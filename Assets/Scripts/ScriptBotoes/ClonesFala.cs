using UnityEngine;
using System.Collections;

public class ClonesFala : MonoBehaviour {
    public DialoboBoxScript DialogoBox;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void chamarFalaNpc()
    {
        DialogoBox.falaPerssonagem();
    }
}
