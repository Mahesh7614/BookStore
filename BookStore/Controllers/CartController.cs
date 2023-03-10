
using BookStoreManager.Interface;
using BookStoreModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("BookStore/[controller]")]
    [Authorize(Roles = Role.User)]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartManager cartManager;
        public CartController(ICartManager cartManager)
        {
            this.cartManager = cartManager;
        }
        [HttpPost]
        [Route("BookStore/AddToCart")]
        public IActionResult AddToCart(CartModel cartModel)
        {
            try
            {
                cartModel.UserID = Convert.ToInt32(User.FindFirst("UserID").Value);
                CartModel cartData = this.cartManager.AddToCart(cartModel);
                if (cartData != null)
                {
                    return this.Ok(new { success = true, message = "Book Added to Cart Successfully", result = cartData });
                }
                return this.Ok(new { success = true, message = "Book Already Exists to Cart" });
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }
        [HttpPut]
        [Route("BookStore/UpdateCart")]
        public IActionResult UpdateCart(CartModel cartModel)
        {
            try
            {
                cartModel.UserID = Convert.ToInt32(User.FindFirst("UserID").Value);
                CartModel cartData = this.cartManager.UpdateCart(cartModel);
                if (cartData != null)
                {
                    return this.Ok(new { success = true, message = "Cart Updated Successfully", result = cartData });
                }
                return this.Ok(new { success = true, message = "Cart Not Updated" });
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }
        [HttpDelete]
        [Route("BookStore/DeleteCart")]
        public IActionResult DeleteCart(int CartID)
        {
            try
            {
                int UserID = Convert.ToInt32(User.FindFirst("UserID").Value);
                bool cartDelete = this.cartManager.DeleteCart(CartID, UserID);
                if (cartDelete)
                {
                    return this.Ok(new { success = true, message = "Cart Deleted Successfully", result = cartDelete });
                }
                return this.Ok(new { success = true, message = "Enter Valid CartID" });
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }
        [HttpGet]
        [Route("BookStore/GetAllCart")]
        public IActionResult GetAllCart()
        {
            try
            {
                int UserID = Convert.ToInt32(User.FindFirst("UserID").Value);
                List<CartModel> cartData = this.cartManager.GetAllCart(UserID);
                if (cartData != null)
                {
                    return this.Ok(new { success = true, message = "Carts Get Successfully", result = cartData });
                }
                return this.Ok(new { success = true, message = "Cart is Empty" });
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}
