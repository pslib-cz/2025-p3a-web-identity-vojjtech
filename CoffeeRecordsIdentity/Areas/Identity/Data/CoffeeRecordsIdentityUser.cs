using Microsoft.AspNetCore.Identity;

namespace CoffeeRecordsIdentity.Areas.Identity.Data;

public class CoffeeRecordsIdentityUser : IdentityUser
{
    public string Name { get; set; } = string.Empty;
}
