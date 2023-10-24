using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace ProjectAutoTest
{
    [TestClass]
    public class Login
    {
        IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            // Khởi tạo trình duyệt Chrome
            driver = new ChromeDriver();
        }

        [TestMethod]
        public void TestLoginWithValidCredentials()
        {
            // Mở trang web
            driver.Navigate().GoToUrl("https://localhost:5197/");

            // Tìm các phần tử tương ứng với tên người dùng và mật khẩu
            IWebElement usernameField = driver.FindElement(By.Id("UserName"));
            IWebElement passwordField = driver.FindElement(By.Id("Password"));

            // Nhập tên người dùng và mật khẩu
            usernameField.SendKeys("admin");
            passwordField.SendKeys("123456");

            // Tìm nút Đăng nhập và nhấn vào nó
            IWebElement loginButton = driver.FindElement(By.Id("btnLogin"));
            loginButton.Click();

            // Đợi một chút để trang web xử lý đăng nhập
            System.Threading.Thread.Sleep(2000);
            // Kiểm tra kết quả sau đăng nhập, ví dụ: kiểm tra URL hoặc một phần tử trên trang đã đăng nhập
            string actualUrl = driver.Url;
            string expectedUrl = "https://localhost:5197/Home";

            Assert.AreEqual(expectedUrl, actualUrl);
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Đóng trình duyệt sau khi hoàn thành kiểm thử
            driver.Quit();
        }
    }
}
