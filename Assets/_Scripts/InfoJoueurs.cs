using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public enum Classe
{
    tank,
    mage,
    distance,
    cac,
    soigneur
};

public class InfoJoueurs : MonoBehaviour
{
    public Classe classeJoueur = Classe.tank;
    public int niveau = 1;
    public int vie = 20;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        string path = "Assets/test.txt";
        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(niveau);
        writer.WriteLine(vie);
        writer.WriteLine(classeJoueur);
        writer.Close();
    }
}
