namespace Core.Persistence.Repositories;

public class Entity
{
    public int Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public Entity()
    {
    }

    public Entity(int id) : this()
    {
        Id = id;
    }
    public Entity(int id, DateTime createdAt) : this(id)
    {
        CreatedAt = createdAt;
    }
}