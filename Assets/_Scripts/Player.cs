using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable]
public struct Attaque
{
    public int degat;
    public Button bouton;

    private Attaque((int degat, Button bouton) paire)
    {
        this.degat = paire.degat;
        this.bouton = paire.bouton;
    }

    public static implicit operator Attaque((int degat, Button bouton) paire)
    {
        return new Attaque(paire);
    }
}

public class Player : MonoBehaviour
{
    [SerializeField]
    public List<Attaque> attacks;

    public Enemie enemie;

    public int vie = 10;
    private int vieActueille;
    private Gradient gradient = new Gradient();
    public Slider barreDeVie;

    public void subitDegats(int degats)
    {
        vieActueille -= degats;
        if (vieActueille <= 0)
        {
            Destroy(barreDeVie.gameObject);
            Destroy(this.gameObject);
            SceneManager.LoadScene("Carte");
        }
        else
        {
            barreDeVie.value = (1f * vieActueille) / vie;
            barreDeVie.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color =
                gradient.Evaluate(1f * vieActueille / vie);
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
        foreach (var attack in attacks)
        {
            attack.bouton.onClick.AddListener(() =>
            {
                enemie.subitDegats(attack.degat);
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
