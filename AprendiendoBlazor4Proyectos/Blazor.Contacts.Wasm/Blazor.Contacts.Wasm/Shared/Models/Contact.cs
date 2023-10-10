using System;
using System.Collections.Generic;

namespace Blazor.Contacts.Wasm.Shared.Models;

public partial class Contact
{
    public long Id { get; set; }

    public string FirsName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Address { get; set; }
}
