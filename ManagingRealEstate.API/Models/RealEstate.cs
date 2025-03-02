namespace ManagingRealEstate.API.Models;

public sealed class RealEstate
{
    private RealEstate(Guid id, string title, string description, decimal price, string location)
    {
        Id = id;
        Title = title;
        Description = description;
        Price = price;
        Location = location;
    }

    private RealEstate() { }

    public Guid Id { get; }
    public string Title { get;  private set; } = default!;
    public string Description { get;  private set; } = default!;
    public decimal Price { get; private set; } = default!;
    public string Location { get;  private set; } = default!;

    public static RealEstate Create(string title, string description, decimal price, string location)
    {
        RealEstate realEstate = new RealEstate(Guid.NewGuid(), title, description, price, location);

        // Raise DomainEvent.

        return realEstate;
    }

    public void Update(string title, string description, decimal price, string location)
    {
        Title = title;
        Description = description;
        Price = price;
        Location = location;

        // Raise DomainEvent.
    }
}