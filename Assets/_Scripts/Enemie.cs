﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Enemie : MonoBehaviour
{
    public int vie = 10;
    private int vieActueille;
    private Gradient gradient = new Gradient();
    public Slider barreDeVie;

    void attaque(int degats)
    {
        if (Input.GetKeyDown("space"))
        {
            vieActueille -= degats;
            if (vieActueille <= 0)
            {
                Destroy(barreDeVie);
                Destroy(this);
            }
            else
            {
                barreDeVie.value = (1f * vieActueille) / vie;
                barreDeVie.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color =
                gradient.Evaluate(1f * vieActueille / vie);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        vieActueille = vie;
        barreDeVie.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.green;
        GradientColorKey[] colorKey = new GradientColorKey[3];
        colorKey[0].color = Color.red;
        colorKey[0].time = 0.0f;
        colorKey[1].color = Color.yellow;
        colorKey[1].time = 0.5f;
        colorKey[2].color = Color.green;
        colorKey[2].time = 1.0f;
        gradient.colorKeys = colorKey;
    }

    // Update is called once per frame
    void Update()
    {
        attaque(1);
    }
}