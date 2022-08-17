using Microsoft.AspNetCore.Mvc;

namespace ProProsecco.Models.Cart
{
    public class CartDeleteCartItemModel
    {

        [BindProperty(Name = "item.Wine.Id", SupportsGet = true)]
        public long WineId { get; set; }
    }
}
