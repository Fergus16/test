using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static int health = 3; // Current health of the player
    public Image[] hearts;       // Heart UI elements
    public Sprite fullHeart;     // Sprite for a full heart
    public Sprite emptyHeart;    // Sprite for an empty heart

    void Awake()
    {
        health = 3; // Initialize health to max
    }

    void Update()
    {
        // Update all heart icons based on current health
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = i < health ? fullHeart : emptyHeart;
        }
    }
}





































/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{  
    //arry of healt
    public static int health = 3;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;


  void Awake()
  {
    health =3;
  }


    // Update is called once per frame
    void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for(int i = 0; i < health; i++)
         {
            hearts[i].sprite = fullHeart;
        }
    }
}


*/