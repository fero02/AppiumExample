using Applitools;
using Applitools.Appium;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;
using System;

namespace ApplitoolsTutorial
{

    [TestFixture]
    public class BasicDemo
    {

        private AndroidDriver<AndroidElement> driver;
        private Eyes eyes;
        [Test]
        public void FirstTest()
        {
            {
                // Set the desired capabilities.
                //moje poco
                AppiumOptions options = new AppiumOptions();
                options.AddAdditionalCapability(MobileCapabilityType.DeviceName, "101c43a8");
                options.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "10");
                options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
                options.AddAdditionalCapability("apppackage", "com.companyname.app1");
                options.AddAdditionalCapability("deviceOrientation", "portrait");


                //moje redmi
                //AppiumOptions options = new AppiumOptions();
                //options.AddAdditionalCapability(MobileCapabilityType.DeviceName, "ae2981b7");
                //options.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "12");
                //options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
                //options.AddAdditionalCapability(MobileCapabilityType.App, "https://applitools.jfrog.io/artifactory/Examples/eyes-hello-world.apk");
                //options.AddAdditionalCapability("deviceOrientation", "portrait");
                //options.AddAdditionalCapability("apppackage", "com.companyname.app1");


                driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), options);

                driver.ActivateApp("com.companyname.app1");

                Assert.IsNotNull(driver.Context);

                driver.TerminateApp("com.companyname.app1");
            }
        }

        [Test]
        public void ApplitoolsWithUnlockDeviceTest()
        {
            {
                eyes = new Eyes();
                //set apiKey from applitools account
                eyes.ApiKey = "9E6PX68jjA0VuolXnFVL8FLaeGf1110Tf2nm5tuGo6Eac110";

                // Set the desired capabilities.
                // moje poco
                //AppiumOptions options = new AppiumOptions();
                //options.AddAdditionalCapability(MobileCapabilityType.DeviceName, "ae2981b7");
                //options.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "11");
                //options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
                ////options.AddAdditionalCapability(MobileCapabilityType.App, "com.companyname.app2");
                //options.AddAdditionalCapability("apppackage", "com.companyname.app1");
                //options.AddAdditionalCapability("deviceOrientation", "portrait");

                //moje redmi
                AppiumOptions options = new AppiumOptions();
                options.AddAdditionalCapability(MobileCapabilityType.DeviceName, "101c43a8");
                options.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "10");
                options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
                options.AddAdditionalCapability("apppackage", "com.companyname.app1");
                options.AddAdditionalCapability("deviceOrientation", "portrait");

                //unlock device
                options.AddAdditionalCapability("unlockType", "pin");
                options.AddAdditionalCapability("unlockKey", "2611");


                driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), options);

                driver.ActivateApp("com.companyname.app1");
                eyes.Open(driver, "Example App", "App1 Intro View");
                eyes.Check("Intro", Target.Window());

                //AndroidElement button = driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.RelativeLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.widget.Button"));

                //Assert.AreEqual(button.Text, "CLICK ME");
                //eyes.Check("Click me", Target.Window());

                //button.Click();
                //button.Click();

                //Assert.AreEqual(button.Text, "YOU CLICKED 1 TIMES.");
                //eyes.Check("Click 1", Target.Window());


                driver.TerminateApp("com.companyname.app1");
                eyes.Close();
            }


        }
        [TearDown]
        public void AfterEach()
        {
            // Close the browser.
            driver.Quit();

            // If the test was aborted before eyes.close was called, ends the test as aborted.
            eyes.AbortIfNotClosed();
        }

    }
}