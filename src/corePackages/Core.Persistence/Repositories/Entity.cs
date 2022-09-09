namespace Core.Persistence.Repositories;

public class Entity
{
    public int Id { get; set; }
    public virtual DateTime? CreatedAt { get; set; }
    public virtual DateTime? UpdatedAt { get; set; }
    public virtual DateTime? DeletedAt { get; set; }

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