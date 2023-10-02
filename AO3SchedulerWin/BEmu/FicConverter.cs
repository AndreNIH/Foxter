using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AO3SchedulerWin.BEmu
{
    internal class FicConverter
    {

        private static ILog _logger = LogManager.GetLogger(typeof(FicConverter));
        //From https://stackoverflow.com/questions/38829153/selenium-drag-and-drop-from-file-system-to-webdriver
        private const string JS_DROP_FILE = "for(var b=arguments[0],k=arguments[1],l=arguments[2],c=b.ownerDocument,m=0;;){var e=b.getBoundingClientRect(),g=e.left+(k||e.width/2),h=e.top+(l||e.height/2),f=c.elementFromPoint(g,h);if(f&&b.contains(f))break;if(1<++m)throw b=Error('Element not interractable'),b.code=15,b;b.scrollIntoView({behavior:'instant',block:'center',inline:'center'})}var a=c.createElement('INPUT');a.setAttribute('type','file');a.setAttribute('style','position:fixed;z-index:2147483647;left:0;top:0;');a.onchange=function(){var b={effectAllowed:'all',dropEffect:'none',types:['Files'],files:this.files,setData:function(){},getData:function(){},clearData:function(){},setDragImage:function(){}};window.DataTransferItemList&&(b.items=Object.setPrototypeOf([Object.setPrototypeOf({kind:'file',type:this.files[0].type,file:this.files[0],getAsFile:function(){return this.file},getAsString:function(b){var a=new FileReader;a.onload=function(a){b(a.target.result)};a.readAsText(this.file)}},DataTransferItem.prototype)],DataTransferItemList.prototype));Object.setPrototypeOf(b,DataTransfer.prototype);['dragenter','dragover','drop'].forEach(function(a){var d=c.createEvent('DragEvent');d.initMouseEvent(a,!0,!0,c.defaultView,0,0,0,g,h,!1,!1,!1,!1,0,null);Object.setPrototypeOf(d,null);d.dataTransfer=b;Object.setPrototypeOf(d,DragEvent.prototype);f.dispatchEvent(d)});a.parentElement.removeChild(a)};c.documentElement.appendChild(a);a.getBoundingClientRect();return a;";

        static void DropFile(IWebElement target, string filePath, double offsetX = 0, double offsetY = 0)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException(filePath);

            IWebDriver driver = ((WebElement)target).WrappedDriver;
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;

            IWebElement input = (IWebElement)jse.ExecuteScript(JS_DROP_FILE, target, offsetX, offsetY);
            input.SendKeys(filePath);
        }


        private static string GetDownloadPath()
        {
            string localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string path = Path.Combine(localAppDataPath, "AO3S", "downloads/");
            return path;
        }

        private static bool PurgedFolderContents(string path)
        {
            try
            {
                string[] files = Directory.GetFiles(path);
                foreach (var file in files) File.Delete(file);
                return true;
            }catch(Exception ex)
            {
                _logger.Error("Could not purge folder contents: " + ex.Message);
            }
            return false;
        }


        private static ChromeOptions GetOptions()
        {
            var options = new ChromeOptions();
            options.AddUserProfilePreference("download.default_directory", GetDownloadPath());
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("disable-popup-blocking", true);
            options.AddArgument("headless");
            options.AddArgument("--window-size=1920,1080");
            return options;
        }

        public static string? ConvertStory(string filename)
        {
            //Create the download directory if it doesn't exist
            var downloadPath = GetDownloadPath();
            if (!Path.Exists(downloadPath))
            {
                _logger.Info("Downlod directory doesn't exist. Creating " + downloadPath);
                Directory.CreateDirectory(downloadPath);
            }
            else
            {
                if (!PurgedFolderContents(downloadPath)) return null;
            }


            var options = GetOptions();
            var driver = new ChromeDriver(options);
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                driver.Url = "https://aoyeet.space/";
                
                //Drag and drop the file
                var dropArea = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("input")));
                DropFile(dropArea, filename);
                
                //Skip attribution
                var targetButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//section[@class='svelte-w825hs'][4]/button[1]")));
                targetButton.Click();
                
                //Download
                var downloadButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[2]")));
                downloadButton.Click();

                //Wait for download to complete

                _logger.Info("Downloading the converted document...");
                string? convertedFile = null;
                var dlWait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                dlWait.Until(d =>
                {
                    string[] files = Directory.GetFiles(downloadPath);
                    foreach (var file in files) 
                    {
                        _logger.Debug($"{file} in download directory");
                        if (Path.GetExtension(file).Contains("htm"))
                        {
                            convertedFile = file;
                            return true;
                        }
                    }
                    return false;
                    /*d.Navigate().GoToUrl("chrome://downloads/");
                    return driver.ExecuteScript(@"
                    var items = document.querySelector('downloads-manager')
                    .shadowRoot.getElementById('downloadsList').items;
                    if (items.every(e => e.state === ""COMPLETE""))
                    return items.map(e => e.fileUrl || e.file_url)");*/
                });
                return convertedFile;

            }catch(FileNotFoundException ex)
            {
                _logger.Warn(ex.Message);
            }catch(NoSuchElementException ex)
            {
                _logger.Error("NoSuchElementException: " + ex.Message);
            }catch(WebDriverException ex)
            {
                _logger.Error("WebDriverException: " + ex.Message);
            }
            finally
            {
                driver.Quit();
            }
            
            return null;
        }
    }
}
