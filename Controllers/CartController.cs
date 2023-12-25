using MyBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using MyBookStore.Data;

namespace MyBookStore.Controllers
{
    public class CartController : Controller
    {
        private readonly Cart _cart;
        private readonly MyBookStoreContext _context;
        public CartController(MyBookStoreContext context, Cart cart)
        {
            _context = context;
            _cart = cart;
        }
        public Book GetBookById(int id)
        {
            return _context.Books.FirstOrDefault(b => b.Id == id);
        }
        public IActionResult Index()
        {
            var items = _cart.GetAllCartItems();
            _cart.CartItems = items;

            return View(_cart);
        }
        public IActionResult AddToCart(int id)
        {
            var selectedBook = GetBookById(id);

            if (selectedBook != null)
            {
                _cart.AddToCart(selectedBook, 1);
            }

            return RedirectToAction("Index", "Store");
        }
        public IActionResult RemoveFromCart(int id)
        {
            var selectedBook = GetBookById(id);

            if (selectedBook != null)
            {
                _cart.RemoveFromCart(selectedBook);
            }

            return RedirectToAction("Index");
        }
        public IActionResult ReduceQuantity(int id)
        {
            var selectedBook = GetBookById(id);

            if (selectedBook != null)
            {
                _cart.ReduceQuantity(selectedBook);
            }

            return RedirectToAction("Index");
        }

        public IActionResult IncreaseQuantity(int id)
        {
            var selectedBook = GetBookById(id);

            if (selectedBook != null)
            {
                _cart.IncreaseQuantity(selectedBook);
            }

            return RedirectToAction("Index");
        }
        public IActionResult ClearCart()
        {
            _cart.ClearCart();

            return RedirectToAction("Index");
        }

    }
}
