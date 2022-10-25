using DemoOctober.Module.BusinessObjects;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoOctober.Module.Controllers
{
    public class DemoController : ViewController
    {
        PopupWindowShowAction action;
        SingleChoiceAction ChoiceAction;
        ParametrizedAction ParametrizedActionDemo;
        SimpleAction ClickMe;
        public DemoController()
        {
            //xas
            ClickMe = new SimpleAction(this, "Post", "View");
            ClickMe.Execute += ClickMe_Execute;

            //xap
            ParametrizedActionDemo = new ParametrizedAction(this, "MyAction", "View", typeof(string));
            ParametrizedActionDemo.Execute += ParametrizedActionDemo_Execute;


            //xac
            ChoiceAction = new SingleChoiceAction(this, "DemoChoiceAction", "View");
            ChoiceAction.ItemType = SingleChoiceActionItemType.ItemIsOperation;
            ChoiceAction.Execute += ChoiceAction_Execute;
            // Create some items
            //ChoiceAction.Items.Add(new ChoiceActionItem("MyItem1", "My Item 1", 1));

            //xapw
            action = new PopupWindowShowAction(this, "MyAction2", "View");
            action.Execute += action_Execute;
            action.CustomizePopupWindowParams += action_CustomizePopupWindowParams;


            this.TargetObjectType = typeof(IPost);
            //this.TargetViewType = ViewType.DetailView;
            //this.TargetViewId = "Customer_DetailView1";
              



        }
        private void action_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            var selectedPopupWindowObjects = e.PopupWindowViewSelectedObjects;
            var selectedSourceViewObjects = e.SelectedObjects;
            // Execute your business logic (https://docs.devexpress.com/eXpressAppFramework/112723/).
        }
        private void action_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            var Os=  this.Application.CreateObjectSpace(typeof(Customer));
            var Customer = Os.CreateObject<Customer>();
            var CustomerDetailView = this.Application.CreateDetailView(Os, Customer);
            e.View = CustomerDetailView;
            // Set the e.View parameter to a newly created view (https://docs.devexpress.com/eXpressAppFramework/112723/).
        }
        private void ChoiceAction_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            var itemData = e.SelectedChoiceActionItem.Data;
            // Execute your business logic (https://docs.devexpress.com/eXpressAppFramework/112738/).
        }
        private void ParametrizedActionDemo_Execute(object sender, ParametrizedActionExecuteEventArgs e)
        {
            var parameterValue = (string)e.ParameterCurrentValue;
            // Execute your business logic (https://docs.devexpress.com/eXpressAppFramework/112724/).
        }
        private void ClickMe_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var CurrentObject1 = this.View.CurrentObject as IPost;
            //var CurrentObject2 = e.CurrentObject as IPost;

            CurrentObject1.Post();
            this.ObjectSpace.CommitChanges();
            // Execute your business logic (https://docs.devexpress.com/eXpressAppFramework/112737/).
        }
        protected override void OnDeactivated()
        {
            base.OnDeactivated();
        }

        protected override void OnViewChanged()
        {
            base.OnViewChanged();
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
        }
    }
}
