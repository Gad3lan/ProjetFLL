using UnityEngine;
using System.Collections;
using UnityEngine.iOS;

public class MoveOnTap : MonoBehaviour
{
    public int vie = 10;
    
    private Vector3 position;
    private float width;
    private float height;
    // Start is called before the first frame update
    void Awake()
    {
        width = (float)Screen.width;
        height = (float)Screen.height;

        // Position used for the cube.
        position = new Vector3(width/2, height/2, 0.0f);
    }

    bool estPlein(bool[] liste)
    {
        for (int i = 0; i < liste.Length; i++)
        {
            if (!liste[i])
            {
                return false;
            }
        }

        return true;
    }

    bool[] remplisListeAleatoire(bool[] liste)
    {
        int rdm = Random.Range(0, liste.Length);
        liste[rdm] = true;
        return liste;
    }
    
    void Start()
    {
        GetComponent<SpriteRenderer>().color = Color.green;
        bool[] liste = {false, false, false, false};
        while (!estPlein(liste))
        {
            liste = remplisListeAleatoire(liste);
        }

        for (int i = 0; i < liste.Length; i++)
        {
            Debug.Log(liste[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            vie--;
            GetComponent<SpriteRenderer>().color = Color.Lerp(Color.red, Color.green, vie / 10f);
            if (vie <= 0)
            {
                Destroy(this.gameObject);
            }
        }
        if (Input.touchCount > 0)
        {
            Debug.Log("Touch");
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 pos = touch.position;
                pos.x = -1 * (pos.x - width) / (width/2.0f);
                pos.y = (pos.y - height) / (height/2.0f);
                Debug.Log(pos);
                position = new Vector3(-pos.x, pos.y, 0.0f);

                this.transform.position = position;
            }
        }
    }
}
