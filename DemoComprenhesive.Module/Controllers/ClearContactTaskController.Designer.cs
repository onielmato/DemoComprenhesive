namespace DemoComprenhesive.Module.Controllers
{
    partial class ClearContactTaskController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ClearTasksAction = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // ClearTasksAction
            // 
            this.ClearTasksAction.Caption = "Set Task";
            this.ClearTasksAction.Category = "Edit";
            this.ClearTasksAction.ConfirmationMessage = null;
            this.ClearTasksAction.Id = "ClearTasksAction";
            this.ClearTasksAction.ImageName = "BO_Task";
            this.ClearTasksAction.TargetObjectType = typeof(Contact);
            this.ClearTasksAction.ToolTip = null;
            this.ClearTasksAction.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.ClearTasksAction_Execute);
            // 
            // ClearContactTaskController
            // 
            this.Actions.Add(this.ClearTasksAction);
            this.TargetObjectType = typeof(Contact);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction ClearTasksAction;
    }
}
