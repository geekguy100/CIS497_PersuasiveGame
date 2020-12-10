/*****************************************************************************
// File Name :         Item.cs
// Author :            Kyle Grenier
// Creation Date :     11/3/2020
//
// Brief Description : Item functionality for selecting what type of item the food is.
*****************************************************************************/
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum Type {Fruit, Peas, Beans, Soup, NULL };
    [SerializeField] private Type itemType;

    public Type ItemType { get { return itemType; } }

//    public bool isBeingHeld;
}