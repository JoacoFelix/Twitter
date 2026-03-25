using System;
using System.Collections.Generic;

namespace Twitter.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public long Followers { get; set; }

    public long Follows { get; set; }

    public long LikesReceived { get; set; }

    public virtual ICollection<Publicacion> Publicacions { get; set; } = new List<Publicacion>();
}
