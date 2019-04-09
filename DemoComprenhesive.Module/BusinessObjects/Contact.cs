﻿using DemoComprenhesive.Module.BusinessObjects;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using System;

[DefaultClassOptions]
public class Contact : Person
{
    public Contact(Session session) : base(session) { }
    private string webPageAddress;
    public string WebPageAddress
    {
        get { return webPageAddress; }
        set { SetPropertyValue("WebPageAddress", ref webPageAddress, value); }
    }
    private string nickName;
    public string NickName
    {
        get { return nickName; }
        set { SetPropertyValue("NickName", ref nickName, value); }
    }
    private string spouseName;
    public string SpouseName
    {
        get { return spouseName; }
        set { SetPropertyValue("SpouseName", ref spouseName, value); }
    }
    private TitleOfCourtesy titleOfCourtesy;
    public TitleOfCourtesy TitleOfCourtesy
    {
        get { return titleOfCourtesy; }
        set { SetPropertyValue("TitleOfCourtesy", ref titleOfCourtesy, value); }
    }
    private DateTime anniversary;
    public DateTime Anniversary
    {
        get { return anniversary; }
        set { SetPropertyValue("Anniversary", ref anniversary, value); }
    }
    private string notes;
    [Size(4096)]
    public string Notes
    {
        get { return notes; }
        set { SetPropertyValue("Notes", ref notes, value); }
    }
   
    private Position position;
    public Position Position
    {
        get { return position; }
        set { SetPropertyValue("Position", ref position, value); }
    }

    [Association("Contact-DemoTask")]
    public XPCollection<DemoTask> Tasks
    {
        get
        {
            return GetCollection<DemoTask>("Tasks");
        }
    }

    private Department department;
    [Association("Department-Contacts")]
    public Department Department
    {
        get { return department; }
        set { SetPropertyValue("Department", ref department, value); }
    }

    private Contact manager;
    [DataSourceProperty("Department.Contacts", DataSourcePropertyIsNullMode.SelectAll)]
    [DataSourceCriteria("Position.Title = 'Manager' AND Oid != '@This.Oid'")]
    public Contact Manager
    {
        get { return manager; }
        set { SetPropertyValue("Manager", ref manager, value); }
    }
}
public enum TitleOfCourtesy { Dr, Miss, Mr, Mrs, Ms };