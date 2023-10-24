using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;

namespace ProjectAutoTest
{
    [TestClass]
    public class Register
    {
        IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            // Khởi tạo trình duyệt Chrome
            driver = new ChromeDriver();
        }
        [TestMethod]
        public void TestRegister()
        {
            // Mở trang web
            driver.Navigate().GoToUrl("https://localhost:5197/");
            IWebElement registerButton = driver.FindElement(By.XPath("//a[contains(text(), 'Register To Create Account')]"));
            registerButton.Click();
            //Đợi mở modal
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            // Tìm các phần tử tương ứng với tên người dùng và mật khẩu
            IWebElement UserNameRegisterField = driver.FindElement(By.Id("UserNameRegister"));
            IWebElement PassWordRegisterField = driver.FindElement(By.Id("PassWordRegister"));
            IWebElement ConfirmPassWordRegisterField = driver.FindElement(By.Id("ConfirmPassWordRegister"));
            IWebElement EmailRegisterField = driver.FindElement(By.Id("EmailRegister"));
            // Nhập tên người dùng và mật khẩu
            UserNameRegisterField.SendKeys("admin32415");
            PassWordRegisterField.SendKeys("123456");
            ConfirmPassWordRegisterField.SendKeys("123456");
            EmailRegisterField.SendKeys("admin32415@gmail.com");
            //Nút lưu
            IWebElement loginButton = driver.FindElement(By.Id("submitRegister"));
            loginButton.Click();
            // Đợi một chút để trang web xử lý đăng nhập
            System.Threading.Thread.Sleep(2000);
            // Kiểm tra kết quả sau đăng nhập, ví dụ: kiểm tra URL hoặc một phần tử trên trang đã đăng nhập
            string actualUrl = driver.Url;
            string expectedUrl = "https://localhost:5197/";
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
