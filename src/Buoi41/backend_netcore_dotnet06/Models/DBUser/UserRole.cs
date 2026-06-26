using System;
using System.Collections.Generic;

namespace backend_netcore_dotnet06.Models.DBUser;

public partial class UserRole
{
    public Guid IdUser { get; set; }

    public int IdRole { get; set; }

    public string? Desc { get; set; }

    public virtual Role IdRoleNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
