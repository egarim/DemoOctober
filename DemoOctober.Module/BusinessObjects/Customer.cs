using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DemoOctober.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Customer : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Customer(Session session)
            : base(session)
        {

        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

            

            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        //

        double categoryDiscount;
        string categoryName;
        string categoryCode;
        CustomerCategory category;
        bool active;
        string code;
        string name;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Code
        {
            get => code;
            set => SetPropertyValue(nameof(Code), ref code, value);
        }

        public bool Active
        {
            get => active;
            set
            {
                //bla bla bla bla 
                SetPropertyValue(nameof(Active), ref active, value);
            }
        }

        public CustomerCategory Category
        {
            get => category;
            set => SetPropertyValue(nameof(Category), ref category, value);
        }

        #region CategoryData

        [Browsable(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string CategoryCode
        {
            get => categoryCode;
            set => SetPropertyValue(nameof(CategoryCode), ref categoryCode, value);
        }
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string CategoryName
        {
            get => categoryName;
            set => SetPropertyValue(nameof(CategoryName), ref categoryName, value);
        }
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        public double CategoryDiscount
        {
            get => categoryDiscount;
            set => SetPropertyValue(nameof(CategoryDiscount), ref categoryDiscount, value);
        }
        #endregion


        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {

            base.OnChanged(propertyName, oldValue, newValue);

            if (this.IsLoading)
                return;

            if (this.Category != null) 
            {
                this.categoryCode = this.Category.Code;
                //so on...
            }
            else
            {
                this.categoryCode = "";
            }

        }

        //private string _PersistentProperty;
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
        //[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
        //public string PersistentProperty {
        //    get { return _PersistentProperty; }
        //    set { SetPropertyValue(nameof(PersistentProperty), ref _PersistentProperty, value); }
        //}

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}
    }
}