// using NUnit.Framework;
// using OpenQA.Selenium;
// using SeleniumTests.Pages;
// using SeleniumTests.Utilities;

// namespace SeleniumTests.Tests
// {
//     [TestFixture]
//     public class DragAndDropTest : BaseTest
//     {
//         private DragAndDropPage _dragAndDropPage;

//         [SetUp]
//         public void TestSetup()
//         {
//             _dragAndDropPage = new DragAndDropPage(Driver);
//         }

//         [Test]
//         public void DragImages_ShouldMoveToTrash()
//         {
//             _dragAndDropPage
//                 .SwitchToPhotoManagerFrame()
//                 .DragImageToTrash(0)         // Drag first image
//                 .DragImageToTrash(0)         // Drag second image (now at index 0)
//                 .VerifyImagesInTrash();      // Verify images are in trash
//         }
//     }
// }
