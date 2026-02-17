class Item
{
    // fields
    public int Weight { get; }
    public string Description { get; }

    // constructor
    public Item(int weight, string description)
    {
        this.Weight = weight;
        this.Description = description;
    }
}