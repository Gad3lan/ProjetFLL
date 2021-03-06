using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemieCarte : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        PlayerPrefs.SetString("nomEnnemi", "test");
        PlayerPrefs.SetInt("niveauEnnemi", 42);
        
        SceneManager.LoadScene("Combat");
    }
}
