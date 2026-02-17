using System;

class Player
{
    public Room CurrentRoom { get; set; }
    private int health;
    private Inventory backpack;

    public Player()
    {
        CurrentRoom = null;
        health = 100;
        backpack = new Inventory(25);
    }

    public void Damage(int amount)
    {
        health -= amount;
    }

    public void Heal(int amount)
    {
        health += amount;
    }

    public bool IsAlive()
    {
        return health > 0;
    }

    public int GetHealth()
    {
        return health;
    }
	
	public bool TakeFromChest(string itemName)
	{
    Item item = CurrentRoom.Chest.Get(itemName);

    if (item == null)
    	{
        	Console.WriteLine("Item is not in Room");
        	return false;
    	}

    bool ok = backpack.Put(itemName, item);
    if (!ok)
    	{
        	Console.WriteLine("Item doesn't fit in your inventory");
       	 	return false;
   	 	}

    CurrentRoom.Chest.Remove(itemName);

    Console.WriteLine($"You took {itemName}");
    return true;
	}

	public bool DropToChest(string itemName)
	{
    Item item = backpack.Get(itemName);

    if (item == null)
   	 	{
    	    Console.WriteLine("You don't have that Item");
       	 return false;
    	}

    bool ok = CurrentRoom.Chest.Put(itemName, item);
    if (!ok)
    	{
        	Console.WriteLine("Item doesn't fit in the Room");
        	return false;
    	}

    backpack.Remove(itemName);

    Console.WriteLine($"You dropped {itemName}");
    return true;
	}
}