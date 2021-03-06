﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.AuthenticationReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MSG", Namespace="http://schemas.datacontract.org/2004/07/Server_WCF_IIS")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(string[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(object[]))]
    public partial struct MSG : System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Op_infosField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Op_nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool Op_statutField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TokenAppField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TokenUserField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object[] dataField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Op_infos {
            get {
                return this.Op_infosField;
            }
            set {
                if ((object.ReferenceEquals(this.Op_infosField, value) != true)) {
                    this.Op_infosField = value;
                    this.RaisePropertyChanged("Op_infos");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Op_name {
            get {
                return this.Op_nameField;
            }
            set {
                if ((object.ReferenceEquals(this.Op_nameField, value) != true)) {
                    this.Op_nameField = value;
                    this.RaisePropertyChanged("Op_name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Op_statut {
            get {
                return this.Op_statutField;
            }
            set {
                if ((this.Op_statutField.Equals(value) != true)) {
                    this.Op_statutField = value;
                    this.RaisePropertyChanged("Op_statut");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TokenApp {
            get {
                return this.TokenAppField;
            }
            set {
                if ((object.ReferenceEquals(this.TokenAppField, value) != true)) {
                    this.TokenAppField = value;
                    this.RaisePropertyChanged("TokenApp");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TokenUser {
            get {
                return this.TokenUserField;
            }
            set {
                if ((object.ReferenceEquals(this.TokenUserField, value) != true)) {
                    this.TokenUserField = value;
                    this.RaisePropertyChanged("TokenUser");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object[] data {
            get {
                return this.dataField;
            }
            set {
                if ((object.ReferenceEquals(this.dataField, value) != true)) {
                    this.dataField = value;
                    this.RaisePropertyChanged("data");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AuthenticationReference.IAuthenticationService")]
    public interface IAuthenticationService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/LoginByPassword", ReplyAction="http://tempuri.org/IAuthenticationService/LoginByPasswordResponse")]
        string LoginByPassword(string username, string password, string tokenApp);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/LoginByPassword", ReplyAction="http://tempuri.org/IAuthenticationService/LoginByPasswordResponse")]
        System.Threading.Tasks.Task<string> LoginByPasswordAsync(string username, string password, string tokenApp);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/LoginByToken", ReplyAction="http://tempuri.org/IAuthenticationService/LoginByTokenResponse")]
        string LoginByToken(string tokenApp, string tokenUser, string[] files);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/LoginByToken", ReplyAction="http://tempuri.org/IAuthenticationService/LoginByTokenResponse")]
        System.Threading.Tasks.Task<string> LoginByTokenAsync(string tokenApp, string tokenUser, string[] files);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/Dispatching", ReplyAction="http://tempuri.org/IAuthenticationService/DispatchingResponse")]
        Client.AuthenticationReference.MSG Dispatching(Client.AuthenticationReference.MSG msg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/Dispatching", ReplyAction="http://tempuri.org/IAuthenticationService/DispatchingResponse")]
        System.Threading.Tasks.Task<Client.AuthenticationReference.MSG> DispatchingAsync(Client.AuthenticationReference.MSG msg);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAuthenticationServiceChannel : Client.AuthenticationReference.IAuthenticationService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AuthenticationServiceClient : System.ServiceModel.ClientBase<Client.AuthenticationReference.IAuthenticationService>, Client.AuthenticationReference.IAuthenticationService {
        
        public AuthenticationServiceClient() {
        }
        
        public AuthenticationServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AuthenticationServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthenticationServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthenticationServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string LoginByPassword(string username, string password, string tokenApp) {
            return base.Channel.LoginByPassword(username, password, tokenApp);
        }
        
        public System.Threading.Tasks.Task<string> LoginByPasswordAsync(string username, string password, string tokenApp) {
            return base.Channel.LoginByPasswordAsync(username, password, tokenApp);
        }
        
        public string LoginByToken(string tokenApp, string tokenUser, string[] files) {
            return base.Channel.LoginByToken(tokenApp, tokenUser, files);
        }
        
        public System.Threading.Tasks.Task<string> LoginByTokenAsync(string tokenApp, string tokenUser, string[] files) {
            return base.Channel.LoginByTokenAsync(tokenApp, tokenUser, files);
        }
        
        public Client.AuthenticationReference.MSG Dispatching(Client.AuthenticationReference.MSG msg) {
            return base.Channel.Dispatching(msg);
        }
        
        public System.Threading.Tasks.Task<Client.AuthenticationReference.MSG> DispatchingAsync(Client.AuthenticationReference.MSG msg) {
            return base.Channel.DispatchingAsync(msg);
        }
    }
}
