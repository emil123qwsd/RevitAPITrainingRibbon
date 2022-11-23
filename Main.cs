using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITrainingRibbon
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            string tabName = "Revit API training";
            application.CreateRibbonTab(tabName);
            string utilsFolderPath = @"C:\Program Files\RevitAPITraining\";

            var panel = application.CreateRibbonPanel(tabName, "Задача 5.1");

            var button = new PushButtonData("Система", "Объем стен", 
                Path.Combine(utilsFolderPath, "RevitAPITrainingSelection2.dll"),
                "RevitAPITrainingSelection2.Main");
            var button2 = new PushButtonData("Система", "Количество дверей",
                Path.Combine(utilsFolderPath, "RevitAPITrainingSelectionDoor.dll"),
                "RevitAPITrainingSelectionDoor.Main");
            var button3 = new PushButtonData("Система", "Количество труб",
                Path.Combine(utilsFolderPath, "RevitAPITrainingSelectionPipe.dll"),
                "RevitAPITrainingSelectionPipe.Main");
            panel.AddItem(button);
            panel.AddItem(button2);
            panel.AddItem(button3);

            return Result.Succeeded;
        }
    }
}
