﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GSIWebsiteCore.MobileSystemWorkOrderServices {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MobileSystemWorkOrderServices.IWorkOrder")]
    public interface IWorkOrder {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWorkOrder/Create", ReplyAction="http://tempuri.org/IWorkOrder/CreateResponse")]
        void Create(GSI.BusinessRuleCore.MobileSystemWorkOrderServices.WorkOrderData _data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWorkOrder/CancelOrder", ReplyAction="http://tempuri.org/IWorkOrder/CancelOrderResponse")]
        string CancelOrder(string WorkOrderCode, long WorkOrderID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWorkOrderChannel : GSIWebsiteCore.MobileSystemWorkOrderServices.IWorkOrder, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WorkOrderClient : System.ServiceModel.ClientBase<GSIWebsiteCore.MobileSystemWorkOrderServices.IWorkOrder>, GSIWebsiteCore.MobileSystemWorkOrderServices.IWorkOrder {
        
        public WorkOrderClient() {
        }
        
        public WorkOrderClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WorkOrderClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WorkOrderClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WorkOrderClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void Create(GSI.BusinessRuleCore.MobileSystemWorkOrderServices.WorkOrderData _data) {
            base.Channel.Create(_data);
        }
        
        public string CancelOrder(string WorkOrderCode, long WorkOrderID) {
            return base.Channel.CancelOrder(WorkOrderCode, WorkOrderID);
        }
    }
}
