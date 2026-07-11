using System;
using System.Collections.Generic;

namespace backend_netcore_dotnet06.Models.DBUser;

public partial class User
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string HashPassword { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Fullname { get; set; }

    public bool Deleted { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
