namespace BIMplugin
{
    using System;
    using System.Reflection;
    using System.Windows.Media.Imaging;
    using Autodesk.Revit.UI;
    

    /// <summary>
    /// Plugin's main entry point.
    /// </summary>
    /// <seealso cref="Autodesk.Revit.UI.IExternalApplication"/>
    public class Main : IExternalApplication
    {
        #region external application public methods
        
        /// <summary>
        /// Called when [startup].
        /// </summary>
        /// <param name="application">The application.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Result OnStartup(UIControlledApplication application)
        {

            // Plugins main tab name.
            string tabName = "Bim4Tips";

            // Plugins name hoted on ribbon tab.
            string panelAnnotationName = "Bim4Tips Programs Version 1.0.0.1";

            // Create tab on Revit UI.
            application.CreateRibbonTab(tabName);

            // Create first panel on Revit ribbon tab.
            var panelAnnotation = application.CreateRibbonPanel(tabName, panelAnnotationName);

            // Create push button#1 data and populate it with information.
            var BtnData1 = new PushButtonData("BtnData1", "Space \n Naming", Assembly.GetExecutingAssembly().Location, "BIMplugin.BIMpluginCommand")
            {
                ///ToolTipImage = new BitmapImage(new Uri(@"image location on disk..."));
                ///ToolTip = "This is some sample tooltip text, replace it later...";
            };
            var Btn1 = panelAnnotation.AddItem(BtnData1) as PushButton;
            Btn1.LargeImage = new BitmapImage(new Uri(@"C:\BIMplugin\res\LOGO_Temp_Image_32x32.png"));

            // Create push button#2 data and populate it with information.
            var BtnData2 = new PushButtonData("BtnData2", "B4T_Interface", Assembly.GetExecutingAssembly().Location, "BIMplugin.BIMpluginCommand1")
            {
                ///ToolTipImage = new BitmapImage(new Uri(@"image location on disk..."));
                ///ToolTip = "This is some sample tooltip text, replace it later...";
            };
            var Btn2 = panelAnnotation.AddItem(BtnData2) as PushButton;
            Btn2.LargeImage = new BitmapImage(new Uri(@"C:\BIMplugin\res\LOGO_Image_32x32.png"));

            return Result.Succeeded;
        }

        /// <summary>
        /// Called when [shutdown].
        /// </summary>
        /// <param name="application">The application.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        #endregion
    }
}
