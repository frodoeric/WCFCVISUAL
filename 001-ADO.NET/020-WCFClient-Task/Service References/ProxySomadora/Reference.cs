﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _020_WCFClient_Task.ProxySomadora {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProxySomadora.IISomadora")]
    public interface IISomadora {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IISomadora/Somar", ReplyAction="http://tempuri.org/IISomadora/SomarResponse")]
        double Somar(double x, double y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IISomadora/Somar", ReplyAction="http://tempuri.org/IISomadora/SomarResponse")]
        System.Threading.Tasks.Task<double> SomarAsync(double x, double y);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IISomadoraChannel : _020_WCFClient_Task.ProxySomadora.IISomadora, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ISomadoraClient : System.ServiceModel.ClientBase<_020_WCFClient_Task.ProxySomadora.IISomadora>, _020_WCFClient_Task.ProxySomadora.IISomadora {
        
        public ISomadoraClient() {
        }
        
        public ISomadoraClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ISomadoraClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ISomadoraClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ISomadoraClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public double Somar(double x, double y) {
            return base.Channel.Somar(x, y);
        }
        
        public System.Threading.Tasks.Task<double> SomarAsync(double x, double y) {
            return base.Channel.SomarAsync(x, y);
        }
    }
}
