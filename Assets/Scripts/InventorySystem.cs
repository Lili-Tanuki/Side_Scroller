using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
    public List<InventoryItem> inventory { get; private set; }

    private void Awake()
    {
        inventory = new List<InventoryItem>();
        m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
    }

    public InventoryItem Get(InventoryItemData referenceData)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            return value; 
        }
        return null;
    }

    public void Add(InventoryItemData refenceData)
    {
        if(m_itemDictionary.TryGetValue(refenceData,out InventoryItem value))
        {
            value.AddToStack();
        }
        else
        {
            InventoryItemData newItem = new InventoryItemData(refenceData);
            inventory.Add(newItem);
            m_itemDictionary.Add(refenceData, newItem);
        }
    }


}
[Serializable]

public class InventoryItem
{
    public InventoryItemData data { get; private set; }
    public int stackSize { get; private set; }

    public InventoryItem(InventoryItemData source)
    {
        data = source;
        AddToStack();
    }

    public void AddToStack()
    {
        stackSize++;
    }

    public void RemoveFromStack()
    {
        stackSize--;
    }
}