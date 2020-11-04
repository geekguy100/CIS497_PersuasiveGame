/*****************************************************************************
// File Name :         UIItemContainer.cs
// Author :            Kyle Grenier
// Creation Date :     11/3/2020
//
// Brief Description : A class that is used to control updating the UI associated with boxes.
*****************************************************************************/
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIItemContainer : MonoBehaviour
{
    private bool occupied = false;
    public bool Occupied { get { return occupied; } }

    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI countText;

    //TODO: Try to initialize to -1 with cast so I dont have to use NULL type.
    private Item.Type itemType = Item.Type.NULL;
    public Item.Type ItemType { get { return itemType; } }

    private int count = 0;
    public int Count
    {
        get { return count; }
        set
        {
            count = value;
            print("UICONTAINER: Count for type " + itemType.ToString() + " is now " + count);
            if (count == 0)
            {
                Color transparent = Color.white;
                transparent.a = 0;

                itemImage.color = transparent;
                countText.text = string.Empty;
            }
            else
            {
                countText.text = "x" + count;
                if (itemImage.color.a == 0)
                {
                    Color white = Color.white;
                    itemImage.color = white;
                }
            }
        }
    }

    [SerializeField] private Sprite fruitCan;
    [SerializeField] private Sprite peasCan;
    [SerializeField] private Sprite beansCan;
    [SerializeField] private Sprite soupCan;

    private void Awake()
    {
        Unload();
    }

    private void Unload()
    {
        Count = 0;
    }

    /// <summary>
    /// Fills the UI space with the item type.
    /// </summary>
    /// <param name="itemType">The item type to fill the space with.</param>
    public void FillSpace(Item.Type itemType)
    {
        switch (itemType)
        {
            case Item.Type.Fruit:
                itemImage.sprite = fruitCan;
                break;
            case Item.Type.Peas:
                itemImage.sprite = peasCan;
                break;
            case Item.Type.Beans:
                itemImage.sprite = beansCan;
                break;
            case Item.Type.Soup:
                itemImage.sprite = soupCan;
                break;

            default:
                Debug.LogWarning("Trying to fill item space of item type not specified.");
                break;
        }

        this.itemType = itemType;
        Count = 1;
        occupied = true;
    }
}