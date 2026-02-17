using System.Collections.Generic;
using System.ComponentModel;
using System.Net.ServerSentEvents;

class Room
{
	// Private fields
	private string description;
	private Dictionary<string, Room> exits; // stores exits of this room.
	private List<Item> items;

	// Create a room described "description". Initially, it has no exits.
	// "description" is something like "in a kitchen" or "in a court yard".
	public Room(string desc)
	{
		description = desc;
		exits = new Dictionary<string, Room>();
		items = new List<Item>();

	}

	// Define an exit for this room.
	public void AddExit(string direction, Room neighbor)
	{
		exits.Add(direction, neighbor);
	}

	public void AddItem(Item item)
	{
		items.Add(item);
	}

	public Item GetItem(string description)
	{
		foreach (Item item in items)
		{
			if (item.Description == description)
				return item;
		}
		return null;
	} 

	public void RemoveItem(Item item)
	{
		items.Remove(item);
	}


	private string GetItemsString()
	{
		if (items.Count == 0)
		return "No items here.";

		string result = "Items:";
		foreach (Item item in items)
		{
			result += " " + item.Description;
		}
		return result;
	}

	// Return the description of the room.
	public string GetShortDescription()
	{
		return description;
	}

	// Return a long description of this room, in the form:
	//     You are in the kitchen.
	//     Exits: north, west
	public string GetLongDescription()
	{
		string str = "You are ";
		str += description;
		str += ".\n";
		str += GetExitString();
		str += "\n" + GetItemsString();
		return str;
	}

	// Return the room that is reached if we go from this room in direction
	// "direction". If there is no room in that direction, return null.
	public Room GetExit(string direction)
	{
		if (exits.ContainsKey(direction))
		{
			return exits[direction];
		}
		return null;
	}

	// Return a string describing the room's exits, for example
	// "Exits: north, west".
	private string GetExitString()
	{
		string str = "Exits: ";
		str += String.Join(", ", exits.Keys);

		return str;
	}
}
