using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgboolaBuyingTShirt.Test
{
    public class Agboola_Webdrive
    {
        [Test]
        public void WebdriveSaucedemo()
        {
            // Step 1: Navigate to the Sauce Labs Sample Application (https://www.saucedemo.com/) in Incognito mode.
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--incognito");
            IWebDriver driver = new ChromeDriver(options);

            //Maximize the browser window for better view
            driver.Manage().Window.Maximize();

            // Navigate to Sauce Labs Sample Application
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            // Step 2:  Enter valid credentials to log in.
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();

            // Step 3:  Verify that the login is successful and the user is redirected to the products page.
            IWebElement productsPageTitle = driver.FindElement(By.ClassName("title"));
            if (productsPageTitle.Text != "Products")
            {
                Console.WriteLine("Login failed. Exiting...");
                driver.Quit();
                return;
            }

            Thread.Sleep(1000);

            // Step 4: Select a T-shirt by clicking on its image.
            driver.FindElement(By.CssSelector(".inventory_item:nth-child(3) .inventory_item_img")).Click();

            // Step 5:  Verify that the T-shirt details page is displayed.
            IWebElement tshirtDetailsPageTitle = driver.FindElement(By.CssSelector(".inventory_details_name"));
            if (!tshirtDetailsPageTitle.Displayed)
            {
                Console.WriteLine("T-shirt details page not displayed. Exiting...");
                driver.Quit();
                return;
            }
            Thread.Sleep(1000);

            // Step 6:  Click the "Add to Cart" button.
            driver.FindElement(By.CssSelector(".btn_inventory")).Click();

            // Step 7:  Verify that the T-shirt is added to the cart successfully.
            IWebElement cartItem = driver.FindElement(By.CssSelector(".shopping_cart_badge"));
            if (cartItem.Text != "1")
            {
                Console.WriteLine("T-shirt not added to cart. Exiting...");
                driver.Quit();
                return;
            }

            Thread.Sleep(1000);

            // Step 8: Navigate to the cart by clicking the cart icon or accessing the cart page directly.
            driver.FindElement(By.CssSelector(".shopping_cart_link")).Click();

            // Step 9:  Verify that the cart page is displayed.
            IWebElement cartPageTitle = driver.FindElement(By.CssSelector(".title"));
            if (cartPageTitle.Text != "Your Cart")
            {
                Console.WriteLine("Cart page not displayed. Exiting...");
                driver.Quit();
                return;
            }

            Thread.Sleep(1000);

            // Step 10: Review the items in the cart and ensure that the T-shirt is listed with the correct details (name, price, quantity, etc.).
            IWebElement cartItemName = driver.FindElement(By.CssSelector(".inventory_item_name"));
            if (cartItemName.Text != "Sauce Labs Bolt T-Shirt")
            {
                Console.WriteLine("T-shirt details in cart are incorrect. Exiting...");
                driver.Quit();
                return;
            }

            Thread.Sleep(1000);

            // Step 11: Click the "Checkout" button.
            driver.FindElement(By.CssSelector(".checkout_button")).Click();

            // Step 12: Verify that the checkout information page is displayed.
            IWebElement checkoutPageTitle = driver.FindElement(By.CssSelector(".title"));
            if (checkoutPageTitle.Text != "Checkout: Your Information")
            {
                Console.WriteLine("Checkout page not displayed. Exiting...");
                driver.Quit();
                return;
            }

            Thread.Sleep(1000);

            // Step 13: Enter the required checkout information (e.g., name, shipping address, payment details).
            driver.FindElement(By.Id("first-name")).SendKeys("Agboola");
            driver.FindElement(By.Id("last-name")).SendKeys("Daramola");
            driver.FindElement(By.Id("postal-code")).SendKeys("NG");

            Thread.Sleep(1000);

            // Step 14:  Click the "Continue" button.
            driver.FindElement(By.Id("continue")).Click();

            // Step 15: Verify that the order summary page is displayed, showing the T-shirt details and the total amount
            IWebElement checkoutInfoPageTitle = driver.FindElement(By.CssSelector(".title"));
            IWebElement totalPageTitle = driver.FindElement(By.CssSelector(".summary_total_label"));
            IWebElement cartItemNameConfirm = driver.FindElement(By.CssSelector(".inventory_item_name"));
                if (checkoutInfoPageTitle.Text != "Checkout: Your Information" && totalPageTitle != null && cartItemNameConfirm.Text != "Sauce Labs Bolt T-Shirt")
                    {
                Console.WriteLine("Summary page not displayed. Exiting...");
                driver.Quit();
                return;
                    }

            Thread.Sleep(1000);

            // Step 16: Click the "Finish" button
            driver.FindElement(By.Id("finish")).Click();

            Thread.Sleep(1000);

            // Step 15: Verify that the order summary page is displayed, showing the T-shirt details and the total amount
            IWebElement confirmationPageTitle = driver.FindElement(By.CssSelector(".complete-header"));
            if (confirmationPageTitle.Text != "Thank you for your order")
            {
                driver.Quit();
                return;
            }

            Thread.Sleep(1000);

            driver.Quit();
        }
    }
}
