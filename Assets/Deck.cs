using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections.Specialized;

[Serializable]
public struct CardType 
{
    public string Name;
    public Sprite Image;
    public Mesh BuildingMesh;
}

public class Deck : MonoBehaviour
{

    private GameObject canvas;

    public CardType[] CardTypes;
    public int[] Cards;


    public float BottomMargin;
    public float CardGap;

    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.transform.GetChild(0) is Transform canvas)
        {
            this.canvas = canvas.gameObject;
            if(this.canvas.GetComponent<RectTransform>() is RectTransform rectTr)
            {
                float deckWidth = (Cards.Length - 1) * CardGap;
                Vector3 left = new Vector3((rectTr.rect.width - deckWidth) * 0.5f, BottomMargin, 0);
                Vector3 position = left;
                foreach(var cardId in Cards)
                {
                    var card = createCardUi(cardId, position);
                    card.transform.SetParent(this.canvas.transform);
                    position += new Vector3(CardGap, 0, 0);
                }
            }
        }
    }

    GameObject createCardUi(int id, Vector3 position)
    {
        GameObject card = new($"Card{id}");
        card.AddComponent<Image>().sprite = CardTypes[id].Image;
        if(card.GetComponent<RectTransform>() is RectTransform rectTr)
        {
            card.transform.localPosition = position;
            UnityEngine.Debug.Log("Found transform");
        }
        return card;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
