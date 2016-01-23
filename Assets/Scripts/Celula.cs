﻿using UnityEngine;
using System.Collections;

public class Celula : MonoBehaviour {
    public Transform largura;
    public Transform altura;
    public Recurso recurso;

    void Start()
    {
        recurso = new Recurso();
    }


    public float GetLargura() {
        return largura.position.x - this.transform.position.x;
    }

    public float GetAltura() {
        return altura.position.y - this.transform.position.y;
    }
}
