using UnityEngine;
using System.Collections;

public class MenuPrincipalComportamento : MonoBehaviour {
    public GameObject[] BotoesReferencia;
    public int curentIndex;
    public GameObject naveSprite;

	// Use this for initialization
	void Start () {
        curentIndex = 0;
        //naveSprite.transform.position = BotoesReferencia[curentIndex].transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown("down"))
        {
            indexValueDown();
        } else if(Input.GetKeyDown("up"))
        {
            indexValueUp();
        }
        
	
	}

    public void indexValueDown()
    {
        if((curentIndex+1) < BotoesReferencia.Length)
        {
            curentIndex++;
            naveSprite.transform.position = BotoesReferencia[curentIndex].transform.position;
        }
    }

    public void indexValueUp()
    {
        if ((curentIndex - 1) >= 0)
        {
            curentIndex--;
            naveSprite.transform.position = BotoesReferencia[curentIndex].transform.position;
        }
    }
}
