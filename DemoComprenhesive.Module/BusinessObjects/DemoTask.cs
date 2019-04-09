using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace DemoComprenhesive.Module.BusinessObjects
{
    [DefaultClassOptions, ImageName("BO_Task")]
    [ModelDefault("Caption", "Task")]
    public class DemoTask : Task
    {
        public DemoTask(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Priority = Priority.Normal;
        }
        private Priority priority;

        [Association("Contact-DemoTask")]
        public XPCollection<Contact> Contacts
        {
            get
            {
                return GetCollection<Contact>("Contacts");
            }
        }
    

    public Priority Priority
        {
            get
            {
                return priority;
            }
            set
            {
                SetPropertyValue("Priority", ref priority, value);
            }
        }

        [Action(ToolTip = "Postpone the task to the next day")]
        public void Postpone()
        {
            if (DueDate == DateTime.MinValue)
            {
                DueDate = DateTime.Now;
            }
            DueDate = DueDate + TimeSpan.FromDays(1);
        }
    }
}


public enum Priority
    {
    [ImageName("State_Priority_Low")]
    Low = 0,
    [ImageName("State_Priority_Normal")]
    Normal = 1,
    [ImageName("State_Priority_High")]
    High = 2
}