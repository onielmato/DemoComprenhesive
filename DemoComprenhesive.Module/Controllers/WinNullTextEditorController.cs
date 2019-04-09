using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using DevExpress.XtraEditors;

namespace DemoComprenhesive.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class WinNullTextEditorController : ViewController
    {
        public WinNullTextEditorController()
        {
            InitializeComponent();
            RegisterActions(components);
        }
        private void InitNullText(PropertyEditor propertyEditor)
        {
            ((BaseEdit)propertyEditor.Control).Properties.NullText = CaptionHelper.NullValueText;
        }
        private void WinNullTextEditorController_ItemsChanged(Object sender, ViewItemsChangedEventArgs e)
        {
            if (e.ChangedType == ViewItemsChangedType.Added && (e.Item.Id == "SpouseName" || e.Item.Id == "Anniversary"))
            {
                TryInitializeAnniversaryItem();
            }
        }
        private void propertyEditor_ControlCreated(Object sender, EventArgs e)
        {
            InitNullText((PropertyEditor)sender);
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            ((CompositeView)View).ItemsChanged += WinNullTextEditorController_ItemsChanged;
            TryInitializeAnniversaryItem();
        }
        protected override void OnDeactivated()
        {
            base.OnDeactivated();
            ((CompositeView)View).ItemsChanged -= WinNullTextEditorController_ItemsChanged;
        }
        public void TryInitializeAnniversaryItem()
        {
            PropertyEditor propertyEditor = ((DetailView)View).FindItem("Anniversary") as PropertyEditor;
            PropertyEditor propertyEditorSpouse = ((DetailView)View).FindItem("SpouseName") as PropertyEditor;
            if (propertyEditor != null)
            {
                if (propertyEditor.Control != null)
                {
                    InitNullText(propertyEditor);
                }
                else
                {
                    propertyEditor.ControlCreated += new EventHandler<EventArgs>(propertyEditor_ControlCreated);
                }
            }
            if (propertyEditorSpouse != null)
            {
                if (propertyEditorSpouse.Control != null)
                {
                    InitNullText(propertyEditorSpouse);
                }
                else
                {
                    propertyEditorSpouse.ControlCreated += new EventHandler<EventArgs>(propertyEditor_ControlCreated);
                }
            }
        }
    }
}
