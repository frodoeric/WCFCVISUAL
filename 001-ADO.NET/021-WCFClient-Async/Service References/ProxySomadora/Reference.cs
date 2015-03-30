﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _021_WCFClient_Async.ProxySomadora {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProxySomadora.IISomadora")]
    public interface IISomadora {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IISomadora/Somar", ReplyAction="http://tempuri.org/IISomadora/SomarResponse")]
        double Somar(double x, double y);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IISomadora/Somar", ReplyAction="http://tempuri.org/IISomadora/SomarResponse")]
        System.IAsyncResult BeginSomar(double x, double y, System.AsyncCallback callback, object asyncState);
        
        double EndSomar(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IISomadoraChannel : _021_WCFClient_Async.ProxySomadora.IISomadora, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SomarCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public SomarCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public double Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((double)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ISomadoraClient : System.ServiceModel.ClientBase<_021_WCFClient_Async.ProxySomadora.IISomadora>, _021_WCFClient_Async.ProxySomadora.IISomadora {
        
        private BeginOperationDelegate onBeginSomarDelegate;
        
        private EndOperationDelegate onEndSomarDelegate;
        
        private System.Threading.SendOrPostCallback onSomarCompletedDelegate;
        
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
        
        public event System.EventHandler<SomarCompletedEventArgs> SomarCompleted;
        
        public double Somar(double x, double y) {
            return base.Channel.Somar(x, y);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginSomar(double x, double y, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginSomar(x, y, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public double EndSomar(System.IAsyncResult result) {
            return base.Channel.EndSomar(result);
        }
        
        private System.IAsyncResult OnBeginSomar(object[] inValues, System.AsyncCallback callback, object asyncState) {
            double x = ((double)(inValues[0]));
            double y = ((double)(inValues[1]));
            return this.BeginSomar(x, y, callback, asyncState);
        }
        
        private object[] OnEndSomar(System.IAsyncResult result) {
            double retVal = this.EndSomar(result);
            return new object[] {
                    retVal};
        }
        
        private void OnSomarCompleted(object state) {
            if ((this.SomarCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.SomarCompleted(this, new SomarCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void SomarAsync(double x, double y) {
            this.SomarAsync(x, y, null);
        }
        
        public void SomarAsync(double x, double y, object userState) {
            if ((this.onBeginSomarDelegate == null)) {
                this.onBeginSomarDelegate = new BeginOperationDelegate(this.OnBeginSomar);
            }
            if ((this.onEndSomarDelegate == null)) {
                this.onEndSomarDelegate = new EndOperationDelegate(this.OnEndSomar);
            }
            if ((this.onSomarCompletedDelegate == null)) {
                this.onSomarCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSomarCompleted);
            }
            base.InvokeAsync(this.onBeginSomarDelegate, new object[] {
                        x,
                        y}, this.onEndSomarDelegate, this.onSomarCompletedDelegate, userState);
        }
    }
}
