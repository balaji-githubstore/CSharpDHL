using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAutomation
{
    class Program
    {
        static void Main(string[] args)
        {


            //  AppiumOptions opt = new AppiumOptions();


            //  opt.AddAdditionalCapability("deviceName", "emulator-5554");
            //  opt.AddAdditionalCapability("platformName", "Android");
            // // opt.AddAdditionalCapability("browserName", "chrome");
            //  opt.AddAdditionalCapability("udid", "emulator-5554");
            //  opt.AddAdditionalCapability("app", @"E:\DHLe-MobileV0.1.6.apk");
            ////  opt.AddAdditionalCapability("automationName", "UIAutomator2");


            //  AndroidDriver<IWebElement> driver = 
            //      new AndroidDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), opt);
            //  driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            //driver.Url = "https://magento.com/";

            //driver.FindElementByXPath("(//button)[1]").Click();

            //driver.FindElementByXPath("//span[text()='My Account']").Click();



            //click on my account
            //send email
            //pass
            //click on login
            AndroidDriver<IWebElement> driver = null;
            try
            {

              //  AppiumBuilder appiumBuilder

                AppiumOptions opt = new AppiumOptions();


                opt.AddAdditionalCapability(MobileCapabilityType. "deviceName", "emulator-5554");
                opt.AddAdditionalCapability("platformName", "Android");
                //opt.AddAdditionalCapability("browserName", "chrome");
                opt.AddAdditionalCapability("udid", "emulator-5554");
                // opt.AddAdditionalCapability("app", @"E:\DHLe-MobileV0.1.6.apk");
                opt.AddAdditionalCapability("automationName", "UIAutomator2");

                opt.AddAdditionalCapability("appPackage", "org.khanacademy.android");
                opt.AddAdditionalCapability("appActivity", "org.khanacademy.android.ui.library.MainActivity");

                opt.AddAdditionalCapability("noReset", true);

                driver =
                    new AndroidDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), opt);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                if (driver.FindElementsByAndroidUIAutomator("UiSelector().text(\"Dismiss\")").Count > 0)
                {
                    driver.FindElementByAndroidUIAutomator("UiSelector().text(\"Dismiss\")").Click();
                }

                driver.FindElementById("org.khanacademy.android:id/tab_bar_button_profile").Click();


                driver.FindElementByAndroidUIAutomator("UiSelector().textContains(\"Sign up\")").Click();

                driver.FindElementByAndroidUIAutomator("UiSelector().textContains(\"Birth\")").Click();

                ReadOnlyCollection<IWebElement> dateEle = driver.FindElementsById("android:id/numberpicker_input");

                //foreach(IWebElement ele in dateEle)
                //{
                //    Console.WriteLine(ele.Text);
                //}

                dateEle[0].Click();

                dateEle[0].Clear();

                dateEle[0].SendKeys("Aug");

                driver.FindElementByAndroidUIAutomator("UiSelector().textContains(\"OK\")").Click();

                driver.FindElementByAndroidUIAutomator("UiSelector().text(\"Home\")").Click();

                Size size= driver.Manage().Window.Size;
                int width = size.Width;

                int height = size.Height;

                while(driver.FindElementsByAndroidUIAutomator("UiSelector().textContains(\"College\")").Count ==0)
                {
                    //scroll
                    TouchAction action = new TouchAction(driver);
                    //action.Tap(100, 500, 6).Perform();
                    //action.Press(width / 2, 3 * height / 4).MoveTo(width / 2, height / 4).Release().Perform();

                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    dic.Add("command", "input touchscreen swipe 250 800 250 400");


                    driver.ExecuteScript("mobile:shell", dic);

                }

                driver.FindElementByAndroidUIAutomator("UiSelector().textContains(\"College\")").Click();


                //IWebDriver d = new ChromeDriver();
                //ITakesScreenshot ts = (ITakesScreenshot)d;
                //ts.GetScreenshot().SaveAsFile("Error.png"); ;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

              //  string path = Directory.GetParent(Directory.GetCurrentDirectory()).Name;

               
                
                driver.GetScreenshot().SaveAsFile("Error.png");
            }
           
         
            



        }
    }
}
