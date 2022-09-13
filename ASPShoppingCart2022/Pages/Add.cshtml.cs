using Microsoft.AspNetCore.Http;
using ASPShoppingCart2022.Models;
using ASPShoppingCart2022.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPShoppingCart2022.Pages
{
    public class AddModel : PageModel
    {
        public CartItem Item { get; set; }
        private List<CartItem> Cart { get; set; } = new List<CartItem>();

        public string ItemName { get; set; }
        public int ItemAmount { get; set; }
        public float ItemUnitPrice { get; set; }

        // Services
        private readonly ISessionStorage<CartItem> _sessionStorage;

        public AddModel(ISessionStorage<CartItem> sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public ActionResult OnPost()
        {
            try
            {
                ItemName = Request.Form["item-name"].ToString();
                ItemAmount = Int16.Parse(Request.Form["item-amount"]);
                ItemUnitPrice = float.Parse(Request.Form["item-price"]);
            }
            catch
            {
                return RedirectToPage("Index", new { alertMessege = "Položka nebyla přidána, data nejsou validní." });
            }

            Item = new CartItem();
            Item.Name = ItemName;
            Item.Amount = ItemAmount;
            Item.UnitPrice = ItemUnitPrice;

            if (HttpContext.Session.GetString("cart") != null)
            {
                Cart = (HttpContext.Session.Get<List<CartItem>>("cart"));
                Cart.Add(Item);
            }
            else
            {
                Cart.Add(Item);
            }

            HttpContext.Session.Set<List<CartItem>>("cart", Cart);

            return RedirectToPage("Index", new { cartItem = Item });
        }
    }
}
