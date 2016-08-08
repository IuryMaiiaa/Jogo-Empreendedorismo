using UnityEngine;
using System.Collections;

public class RandomSpriteSolo : MonoBehaviour {
    public SpriteRenderer soloSprite;
    public Sprite[] solo;

	// Use this for initialization
	void Start () {
        float valor = Random.value * 100000;
        int valorInteiro = (int)valor;
        valorInteiro = valorInteiro % 4;
        soloSprite.sprite = solo[valorInteiro];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
