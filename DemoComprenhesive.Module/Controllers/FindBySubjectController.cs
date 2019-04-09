using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DemoComprenhesive.Module.BusinessObjects;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;

namespace DemoComprenhesive.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class FindBySubjectController : ViewController
    {
        public FindBySubjectController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void FindBySubjectAction_Execute(object sender, ParametrizedActionExecuteEventArgs e)
        {
            IObjectSpace objectSpace = Application.CreateObjectSpace(((ListView)View).ObjectTypeInfo.Type);

            string parametro = e.ParameterCurrentValue.ToString();

            object task = objectSpace.FindObject(((ListView)View).ObjectTypeInfo.Type, CriteriaOperator.Parse(string.Format("Contains([Subject], '{0}')", parametro)));
            if (task != null)
            {
                DetailView detailView = Application.CreateDetailView(objectSpace, task);
                detailView.ViewEditMode = ViewEditMode.Edit;
                e.ShowViewParameters.CreatedView = detailView;
            }
        }
    }
}
