using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests.Pages
{
    public class DragAndDropPage : BasePage
{
    protected readonly By _photoManagerFrame = By.CssSelector("iframe.demo-frame");
    protected readonly By _galleryImages = By.CssSelector("ul#gallery > li");
    protected readonly By _trash = By.CssSelector("div#trash");
    protected readonly string _pageUrl = "https://www.globalsqa.com/demo-site/draganddrop/";

    public DragAndDropPage(IWebDriver driver) : base(driver)
    {
        NavigateToUrl(_pageUrl);
    }

    public DragAndDropPage SwitchToPhotoManagerFrame()
    {
        SwitchToFrame(_photoManagerFrame);
        return this;
    }

    public DragAndDropPage DragImageToTrash(int imageIndex)
    {
        var gallery = FindElements(_galleryImages);
        
        if (imageIndex >= gallery.Count)
            throw new ArgumentException($"Image index {imageIndex} is invalid. Available images: {gallery.Count}");

        var source = gallery.ElementAt(imageIndex);
        var target = FindElement(_trash);
        
        Actions.DragAndDrop(source, target).Perform();
        WaitForAnimation();
        
        return this;
    }

    public DragAndDropPage VerifyImagesInTrash()
    {
        var trashImages = FindElements(By.CssSelector("div#trash li"));
        Assert.That(trashImages.Count, Is.GreaterThan(0), "No images found in trash");
        return this;
    }
}
}