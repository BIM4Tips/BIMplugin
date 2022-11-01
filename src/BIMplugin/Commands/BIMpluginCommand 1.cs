namespace BIMplugin
{
    using Autodesk.Revit.UI;
    using Autodesk.Revit.DB;
    using Dynamo.Applications;
    using System.Collections.Generic;

    /// <summary>
    /// Command code to be executed when button is clicked.
    /// </summary>
    /// <seealso cref="Autodesk.Revit.UI.IExternalApplication"/>

    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]

    public class BIMpluginCommand1 : IExternalCommand
    {
        #region public methods

        /// <summary>
        /// Executes the specified command data.
        /// </summary>
        /// <param name="commandData">The command data.</param>
        /// <param name="message">The message.</param>
        /// <param name="elements">The elements.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Get application and documnet objects and start transaction
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;

            string Journal_Dynamo_Path = @"C:\BIMplugin\[ATU]SystemV4.dyn";
            DynamoRevit dynamoRevit = new DynamoRevit();

            DynamoRevitCommandData dynamoRevitCommandData = new DynamoRevitCommandData();
            dynamoRevitCommandData.Application = commandData.Application;
            IDictionary<string, string> journalData = new Dictionary<string, string>
            {
                { Dynamo.Applications.JournalKeys.ShowUiKey, false.ToString() }, // don't show DynamoUI at runtime
                { Dynamo.Applications.JournalKeys.AutomationModeKey, true.ToString() }, //run journal automatically
                { Dynamo.Applications.JournalKeys.DynPathKey, Journal_Dynamo_Path }, //run node at this file path
                { Dynamo.Applications.JournalKeys.DynPathExecuteKey, true.ToString() }, // The journal file can specify if the Dynamo workspace opened from DynPathKey will be executed or not. If we are in automation mode the workspace will be executed regardless of this key.
                { Dynamo.Applications.JournalKeys.ForceManualRunKey, false.ToString() }, // don't run in manual mode
                { Dynamo.Applications.JournalKeys.ModelShutDownKey, true.ToString() },
                { Dynamo.Applications.JournalKeys.ModelNodesInfo, false.ToString() }

            };

            dynamoRevitCommandData.JournalData = journalData;
            Result externalCommandResult = dynamoRevit.ExecuteCommand(dynamoRevitCommandData);
            return externalCommandResult;
        }


        #endregion

    }
}
