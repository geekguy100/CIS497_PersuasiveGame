/*****************************************************************************
// File Name :         BoxBehaviour.cs
// Author :            Kyle Grenier
// Creation Date :     11/2/2020
//
// Brief Description : Behaviour for the boxes. Drop items into boxes to score points.
*****************************************************************************/
using UnityEngine;
using System.Collections.Generic;

public class BoxBehaviour : MonoBehaviour
{
    private Animator anim;

    //The maximum number of items this box can hold.
    private int maxItems;
    private int minItems;

    //The items that CAN be spawned.
    [SerializeField] private Item[] items;

    //The number of items in the box.
    private int itemCount = 0;

    private int id = -1;
    public int ID { get { return id; } }

    private GameObject canvas;
    private BoxManager boxManager;

    private Item itemOnBox = null;
    

    //The UIItemContainers used to display box contents.
    [SerializeField] private UIItemContainer[] displays = new UIItemContainer[4];
    private List<Item.Type> containedTypes = new List<Item.Type>();

    public void Init(int minItems, int maxItems, int id)
    {
        this.minItems = minItems;
        this.maxItems = maxItems;
        this.id = id;
        canvas = transform.GetChild(0).gameObject;
        anim = GetComponent<Animator>();
        boxManager = GameObject.FindGameObjectWithTag("BoxManager").GetComponent<BoxManager>();

        //Make sure the box is closed and all UI hidden 
        //until it has been moved into position.
        Close();
        
        SetupRequiredContents();
    }

    private void Update()
    {
        if (itemCount == 0)
        {
            itemCount = -1;
            boxManager.OnBoxFinish(this);
        }
    }

    private void SetupRequiredContents()
    {
        int numItems = Random.Range(minItems, maxItems);
        print("BOX: Chosen " + numItems + " between " + minItems + " and " + maxItems + " maxItems.");

        //Adds a random number of items within the bounds to the box.
        for (int i = 0; i < numItems; ++i)
        {
            int n = Random.Range(0, items.Length);
            AddItem(items[n]);
        }
    }

    /// <summary>
    /// Add an item to the contents of the box.
    /// </summary>
    /// <param name="item">The item to add</param>
    private void AddItem(Item item)
    {
        print("1. " + item.ItemType.ToString() + " is trying to be added...");


        //If this box already contains the item type we are trying to add,
        //find the appropriate UIItemContainer and just update its text.
        if (containedTypes.Contains(item.ItemType))
        {
            print("1a. " + item.ItemType.ToString() + " is already present. Updating count...");
            foreach(UIItemContainer container in displays)
            {
                if (container.ItemType == item.ItemType)
                {
                    print("1b. " + "Updated count for " + item.ItemType);
                    container.Count++;
                    break;
                }
            }
        }
        //Iterate through all containers and fill the first one that's not empty.
        else
        {
            print("2. " + item.ItemType + " is not present in the box. Adding to an open container.");
            foreach (UIItemContainer container in displays)
            {
                if (!container.Occupied)
                {
                    print("3. " + "Filling open container");
                    container.FillSpace(item.ItemType);
                    break;
                }
            }

            print("4. " + "Container filled! " + item.ItemType + " added to containedTypes List");
            containedTypes.Add(item.ItemType);
        }

        print("ENDING ADD OF " + item.ItemType);
        ++itemCount;
    }

    /// <summary>
    /// Decrementes the item count of the box if the item is present.
    /// </summary>
    /// <param name="item">The item to be added to the box.</param>
    private bool RemoveItem(Item item)
    {
        foreach (UIItemContainer container in displays)
        {
            //Only decrement from the UIItemContainer if we still need items of that type.
            if (container.ItemType == item.ItemType && container.Count > 0)
            {
                GameManager.Instance.SpawnParticle("correct", transform.position);

                GameManager.Instance.audSrc.PlayOneShot(GameManager.Instance.correct, 0.2f);
                container.Count--;
                itemCount--;

                Destroy(item.gameObject);

                return true;
            }
        }


        //Incorrect item
        GameManager.Instance.SpawnParticle("incorrect", transform.position);
        GameManager.Instance.audSrc.PlayOneShot(GameManager.Instance.incorrect, 0.2f);
        GameManager.Instance.timer.time -= 2f;
        Destroy(item.gameObject);
        return false;

        //Maybe use layers for the box trigger so we can keep track of what exactly the box can and cannot accept?
        //So we'd have layers for all the different types of cans.
    }

    public void Open()
    {
        canvas.SetActive(true);
        anim.SetBool("isComplete", false);
    }

    public void Close()
    {
        canvas.SetActive(false);
        anim.SetBool("isComplete", true);
    }

    /// <summary>
    /// IF an Item entered the trigger, updated itemOnBox to true.
    /// </summary>
    /// <param name="col">The Collider2D entering the trigger.</param>
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Item"))
        {
            itemOnBox = col.GetComponent<Item>();
        }
    }

    /// <summary>
    /// If an item exited the trigger, update itemOnBox to false.
    /// </summary>
    /// <param name="col">The Collider2D exiting the trigger.</param>
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Item"))
        {
            itemOnBox = null;
        }
    }

    /// <summary>
    /// If mouse down and itemOnBox, accept the item (put it into the box).
    /// </summary>
    private void OnMouseDown()
    {
        if (itemOnBox)
            RemoveItem(itemOnBox);
    }


}