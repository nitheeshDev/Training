﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Calculator1.ServiceReference2 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.CalculationSoap")]
    public interface CalculationSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Addition", ReplyAction="*")]
        int Addition(int x, int y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Addition", ReplyAction="*")]
        System.Threading.Tasks.Task<int> AdditionAsync(int x, int y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Subtraction", ReplyAction="*")]
        int Subtraction(int x, int y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Subtraction", ReplyAction="*")]
        System.Threading.Tasks.Task<int> SubtractionAsync(int x, int y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Muliplication", ReplyAction="*")]
        int Muliplication(int x, int y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Muliplication", ReplyAction="*")]
        System.Threading.Tasks.Task<int> MuliplicationAsync(int x, int y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Division", ReplyAction="*")]
        int Division(int x, int y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Division", ReplyAction="*")]
        System.Threading.Tasks.Task<int> DivisionAsync(int x, int y);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CalculationSoapChannel : Calculator1.ServiceReference2.CalculationSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CalculationSoapClient : System.ServiceModel.ClientBase<Calculator1.ServiceReference2.CalculationSoap>, Calculator1.ServiceReference2.CalculationSoap {
        
        public CalculationSoapClient() {
        }
        
        public CalculationSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CalculationSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CalculationSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CalculationSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Addition(int x, int y) {
            return base.Channel.Addition(x, y);
        }
        
        public System.Threading.Tasks.Task<int> AdditionAsync(int x, int y) {
            return base.Channel.AdditionAsync(x, y);
        }
        
        public int Subtraction(int x, int y) {
            return base.Channel.Subtraction(x, y);
        }
        
        public System.Threading.Tasks.Task<int> SubtractionAsync(int x, int y) {
            return base.Channel.SubtractionAsync(x, y);
        }
        
        public int Muliplication(int x, int y) {
            return base.Channel.Muliplication(x, y);
        }
        
        public System.Threading.Tasks.Task<int> MuliplicationAsync(int x, int y) {
            return base.Channel.MuliplicationAsync(x, y);
        }
        
        public int Division(int x, int y) {
            return base.Channel.Division(x, y);
        }
        
        public System.Threading.Tasks.Task<int> DivisionAsync(int x, int y) {
            return base.Channel.DivisionAsync(x, y);
        }
    }
}
