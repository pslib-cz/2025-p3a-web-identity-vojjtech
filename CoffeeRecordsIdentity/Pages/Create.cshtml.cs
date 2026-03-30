using CoffeeRecordsIdentity.Data;
using CoffeeRecordsIdentity.InputModels;
using CoffeeRecordsIdentity.Models;
using CoffeeRecordsIdentity.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CoffeeRecordsIdentity.Pages
{
    [Authorize]
    public class CreateModel(ILogger<CreateModel> logger, ApplicationDbContext context, UserManager<CoffeeRecordsIdentityUser> userManager) : PageModel
    {
        private readonly ILogger<CreateModel> _logger = logger;
        private readonly ApplicationDbContext _context = context;
        private readonly UserManager<CoffeeRecordsIdentityUser> _userManager = userManager;

        [BindProperty]
        public CoffeeCupIM Input { get; set; } = new();

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _logger.LogInformation("OnPostAsync called with MachineNo: {MachineNo} and UserName: {UserName}", Input.MachineNo, Input.UserName);
            if (!ModelState.IsValid)
            {
                return Page();
            }


            var currentUser = await _userManager.GetUserAsync(User);

            var cc = new CoffeeCup
            {
                MachineNo = Input.MachineNo,
                UserName = currentUser?.UserName ?? Input.UserName,
                UserId = currentUser?.Id,
                Created = DateTime.Now
            };

            _logger.LogInformation("Creating CoffeeCup with MachineNo: {MachineNo}, UserName: {UserName}, UserId: {UserId}", cc.MachineNo, cc.UserName, cc.UserId);

            _context.Cups.Add(cc);
            await _context.SaveChangesAsync();
            _logger.LogInformation("CoffeeCup created with Id: {CoffeeCupId}", cc.CoffeeCupId);

            return RedirectToPage("./Index");
        }
    }
}
