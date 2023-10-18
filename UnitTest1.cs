using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCsharp
{
    public class Tests
    {

        IWebDriver driver;
        // String test_url = "http://prelive.aptimea.com/form/questionnaire";
        //String test_url = "https://lavrov21.thkit.ee/vormid/form.html";
        String test_url = "https://lavrov21.thkit.ee/ankeet2.html";

        private readonly Random _random = new Random();

        [SetUp]
        public void start_browser()
        {
            driver = new FirefoxDriver(@"C:/Users/Laptop/source/repos/SeleniumCsharp/drivers");
            driver.Manage().Window.Maximize();


        }

        [Test]
        public void test_page1()
        {
            driver.Url = test_url;
            //driver.Navigate().GoToUrl("http://prelive.aptimea.com/form/questionnaire");
            //driver.Navigate().GoToUrl("https://lavrov21.thkit.ee/vormid/form.html");
            driver.Navigate().GoToUrl("https://lavrov21.thkit.ee/ankeet2.html");

            Thread.Sleep(5500);


            var reset = driver.FindElement(By.XPath("//input[@type='reset']"));
            reset.Click();
            driver.SwitchTo().DefaultContent();
           

            Thread.Sleep(3000);

            for (int a = 0; a < 1; a++)
            {

                Thread.Sleep(2500);
                var sText = driver.FindElements(By.XPath("//input[@type='text']"));
                for (int i = 0; i < sText.Count; i++)
                {
                    try { sText[i].Click(); sText[i].SendKeys("Lainen"); } catch (Exception) { Console.WriteLine("Error,unable to fill in  one of  the input field"); }
                }

                Thread.Sleep(3000);


                var els = driver.FindElements(By.XPath(".//input[@type='radio']"));
                Thread.Sleep(1000);

                //if (els.Count >= 2)
                //{}

                    var randomIndex = _random.Next(0, els.Count);
                    var selectedRadio = els[randomIndex];
                if (selectedRadio.Enabled)
                {

                    try { selectedRadio.Click(); }

                    catch (Exception ex) { Console.WriteLine("Error,button disabled"); }
                }
                else
                {
                     Console.WriteLine("Error,button disabled"); 
                }




                // if (selectedRadio.Enabled)
                //{
                //     selectedRadio.Click();
                // }
                // else
                // {
                //                        Console.WriteLine("Error,button disabled"); 


                // // Raise an exception to fail the test when a radio button is disabled
                // //throw new Exception($"Radio button '{selectedRadio.GetAttribute("name")}' is disabled.");
                // }
            



                Thread.Sleep(2500);
                var sEmail = driver.FindElements(By.XPath("//input[@type='email']"));
                for (int i = 0; i < sEmail.Count; i++)
                {
                    try { sEmail[i].Click(); sEmail[i].SendKeys("Lap@mail.com"); } catch (Exception) { Console.WriteLine("Error,unable to fill in  email field"); }
                }


                Thread.Sleep(2500);
                var Select = driver.FindElements(By.XPath("//input[@type='checkbox']"));
                for (int i = 0; i < Select.Count; i++)
                {
                    try { Select[i].Click(); } catch (Exception) { Console.WriteLine("Error,checkbox did not work"); }

                }
                Thread.Sleep(2500);
                var sSelect = driver.FindElements(By.XPath("//select"));
                for (int i = 0; i < sSelect.Count; i++)
                {
                    try { sSelect[i].Click(); sSelect[i].FindElements(By.XPath(".//*"))[2].Click(); } catch (Exception) { Console.WriteLine("Error,unable to choose select option"); }
                }

                Thread.Sleep(2500);


                var File = driver.FindElement(By.XPath("//input[@type='file']"));

                try
                {
                    File.SendKeys(@"C:\\Users\\Laptop\\Desktop\\img\\autumn.png");
                }
                catch (Exception) { Console.WriteLine("Error,unable to upload file"); }

                Thread.Sleep(3000);
                var password = driver.FindElements(By.XPath("//input[@type='password']"));


                for (int i = 0; i <password.Count; i++)
                {
                    try {  password[i].SendKeys("12345"); } catch (Exception) { Console.WriteLine("Error,unable to fill in password field"); }
                }


                var reg = driver.FindElement(By.XPath("//input[@type='button']"));
                try { reg.Click(); } catch (Exception) { Console.WriteLine("Error, button is functional"); }

                Thread.Sleep(6000);
                driver.SwitchTo().DefaultContent();










                //driver.findElement(By.id("dateSelector")).click();

                //button to move next in calendar

                //var sTextArea = driver.FindElements(By.XPath("//textarea"));
                //for (int i = 0; i < sTextArea.Count; i++)
                //{
                //    try { sTextArea[i].Click(); sTextArea[i].SendKeys("LappolainenMartin"); } catch (Exception) { }
                //}
                //var sNum = driver.FindElements(By.XPath("//input[@type='number']"));
                //for (int i = 0; i < sNum.Count; i++)
                //{
                //    try { sNum[i].Click(); sNum[i].SendKeys("1"); } catch (Exception) { }
                //}


                //IWebElement sButtonE = driver.FindElement(By.XPath("//*[@value='Sauvegarder brouillon']"));
                //try { sButtonE.Click(); } catch (Exception) { }
                //Thread.Sleep(2500);
                //IWebElement sButton = driver.FindElement(By.XPath("//*[@value='Suivant']"));
                //try { sButton.Click(); } catch (Exception) { }
            }
            //Thread.Sleep(2500);

            //IWebElement sButton3 = driver.FindElement(By.XPath("//*[@value='Finaliser']"));
            //try { sButton3.Click(); } catch (Exception) { }

            //Thread.Sleep(2500);

            //IWebElement sButton4 = driver.FindElement(By.XPath("//a[@href='/user/login']"));
            //try { sButton4.Click(); } catch (Exception) { }

            //Thread.Sleep(2500);

            //IWebElement sButton5 = driver.FindElement(By.XPath("//*[@value='Se connecter']"));
            //try { sButton5.Click(); } catch (Exception) { }
            //Thread.Sleep(8000);
        }
        [TearDown]
           public void close_Browser()
        {
            driver.Quit();
        }
    }





    //public class Tests
    //    {


    //        [Test]
    //        public static void start_browser()
    //        {
    //            // Create a WebDriver instance (in this case, Firefox)
    //            IWebDriver driver = new FirefoxDriver(@"C:/Users/Laptop/source/repos/SeleniumCsharp/drivers");

    //            // Navigate to the webpage with the form
    //            driver.Navigate().GoToUrl("https://lavrov21.thkit.ee/ankeet2.html");

    //            try
    //            {
    //                // Find and fill in the form fields
    //                driver.FindElement(By.Id("Name")).SendKeys("John");
    //                driver.FindElement(By.Id("FamilyName")).SendKeys("Doe");
    //                driver.FindElement(By.Id("email")).SendKeys("johndoe@example.com");
    //                driver.FindElement(By.Id("address")).SendKeys("123 Main St");

    //                // Handle radio buttons (e.g., Male)
    //                IWebElement maleRadioButton = driver.FindElement(By.Id("male"));
    //                if (maleRadioButton.Enabled)
    //                {
    //                    maleRadioButton.Click();
    //                }

    //                // Handle checkboxes (e.g., Student)
    //                IWebElement studentCheckBox = driver.FindElement(By.Id("valik2"));
    //                if (studentCheckBox.Enabled && !studentCheckBox.Selected)
    //                {
    //                    studentCheckBox.Click();
    //                }

    //                // Select values from dropdowns (e.g., Start date)
    //                SelectElement startPeriodDropdown = new SelectElement(driver.FindElement(By.Id("startperiod")));
    //                startPeriodDropdown.SelectByValue("01");

    //                SelectElement startYearDropdown = new SelectElement(driver.FindElement(By.Id("startyear")));
    //                startYearDropdown.SelectByValue("2023");

    //                // Handle file upload (you may need to adjust this)
    //                driver.FindElement(By.Id("doc")).SendKeys("C:\\path\\to\\your\\file.txt");

    //                // Set passwords
    //                driver.FindElement(By.Id("password")).SendKeys("your_password");
    //                driver.FindElement(By.Id("password1")).SendKeys("your_password");

    //                // Accept terms and conditions checkbox
    //                IWebElement agreementCheckbox = driver.FindElement(By.Id("agreement"));
    //                if (agreementCheckbox.Enabled && !agreementCheckbox.Selected)
    //                {
    //                    agreementCheckbox.Click();
    //                }

    //                // Click the "Register" button
    //                driver.FindElement(By.CssSelector("input[type='button'][value='Register']")).Click();
    //            }
    //            catch (Exception ex)
    //            {
    //                Console.WriteLine("An exception occurred: " + ex.Message);
    //            }
    //            finally
    //            {
    //                // Close the WebDriver
    //                //driver.Quit();
    //            }
    //        }
    //    }
}

