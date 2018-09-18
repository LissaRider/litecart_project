using NUnit.Framework;

namespace LitecartTests
{
    [TestFixture]
    public class CartTests : TestBase
    {
        [Test]
        public void AddToCartAndRemoveFromCart()
        {
            for (int i = 0; i < 3; i++)
            {                
                app.AddProductToCart();
            }            
            app.RemoveFromCart();
        }
    }
}
