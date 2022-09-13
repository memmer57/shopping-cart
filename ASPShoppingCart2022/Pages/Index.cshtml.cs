using ASPShoppingCart2022.Models;
using ASPShoppingCart2022.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Session;
using System.ComponentModel;

namespace ASPShoppingCart2022.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<CartItem> Cart { get; set; } = new List<CartItem>();
        public string AlertMessege;

        // Services
        private readonly ISessionStorage<CartItem> _sessionStorage;

        public IndexModel(ILogger<IndexModel> logger, ISessionStorage<CartItem> sessionStorage)
        {
            _logger = logger;
            _sessionStorage = sessionStorage;
        }

        public IActionResult OnGet(CartItem cartItem, string alertMessege)
        {
            if (HttpContext.Session.GetString("cart") != null)
            {
                Cart = (HttpContext.Session.Get<List<CartItem>>("cart"));
            }

            if (alertMessege != null)
            {
                AlertMessege = alertMessege;
            }

            return Page();
        }

        public IActionResult OnGetClear()
        {
            HttpContext.Session.Remove("cart");
            return RedirectToPage("Index", new { alertMessege = "Košík byl vyprázdněn." });
        }

        public IActionResult OnGetDelete(int val)
        {
            Cart = (HttpContext.Session.Get<List<CartItem>>("cart"));
            Cart.RemoveAt(val);
            HttpContext.Session.Set<List<CartItem>>("cart", Cart);
            return RedirectToPage("Index", new { alertMessege = "Předmět byl z košíku smazán." });
        }
    }
}