using System.Collections.Generic;

class Inventory
{
    // fields
    private int maxWeight;
    private Dictionary<string, Item> items;

    // constructor
    public Inventory(int maxWeight)
    {
        this.maxWeight = maxWeight;
        this.items = new Dictionary<string, Item>();
    }

    // methods
    public bool Put(string itemName, Item item)
    {
        if (item.Weight > FreeWeight())
            return false;

        items[itemName] = item;
        return true;
    }

    public Item Get(string itemName)
    {
        if (items.ContainsKey(itemName))
            return items[itemName];

        return null;
    }

    public void Remove(string itemName)
    {
        items.Remove(itemName);
    }

    public int TotalWeight()
    {
        int total = 0;
        foreach (Item item in items.Values)
        {
            total += item.Weight;
        }
        return total;
    }

    public int FreeWeight()
    {
        return maxWeight - TotalWeight();
    }

    public string Show()
    {
        if (items.Count == 0)
            return "No items";

        string result = "";
        foreach (string name in items.Keys)
        {
            result += name + " ";
        }
        return result;
    }
}