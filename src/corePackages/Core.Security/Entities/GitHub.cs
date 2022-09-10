using Core.Persistence.Repositories;

namespace Core.Security.Entities;

public sealed class GitHub : Entity
{
    public string ProfileUserName { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }

    public string ProfileUrl
        => string.Format("https://github.com/{0}", ProfileUserName);

    public GitHub()
    {
        new User();
    }
    public GitHub(int id, string profileUserName, int userId) : this()
    {
        Id = id;
        ProfileUserName = profileUserName;
        UserId = userId;
    }
}
