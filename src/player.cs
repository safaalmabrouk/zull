class Player
{
    public Room CurrentRoom {get; set;}
    private int health;

    public Player()
    {
        CurrentRoom = null;
        health = 100;
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
        return health >0;
    }
    public int GetHealth()
    {
        return health;
    }
}