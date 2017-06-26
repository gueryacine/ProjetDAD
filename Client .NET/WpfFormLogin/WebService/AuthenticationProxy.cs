﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientWPF
{
    using System.Runtime.Serialization;

    //------------------------------------------------------------------------------
    // <auto-generated>
    //     Ce code a été généré par un outil.
    //     Version du runtime :4.0.30319.42000
    //
    //     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
    //     le code est régénéré.
    // </auto-generated>
    //------------------------------------------------------------------------------

    namespace Server_WCF_IIS
    {
        using System.Runtime.Serialization;


        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.Runtime.Serialization.DataContractAttribute(Name = "MSG", Namespace = "http://schemas.datacontract.org/2004/07/Server_WCF_IIS")]
        [System.Runtime.Serialization.KnownTypeAttribute(typeof(object[]))]
        [System.Runtime.Serialization.KnownTypeAttribute(typeof(string[]))]
        public partial struct MSG : System.Runtime.Serialization.IExtensibleDataObject
        {

            private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

            private string EmailField;

            private string Op_infosField;

            private string Op_nameField;

            private bool Op_statutField;

            private string PasswordField;

            private string TokenAppField;

            private string TokenUserField;

            private object[] dataField;

            public System.Runtime.Serialization.ExtensionDataObject ExtensionData
            {
                get
                {
                    return this.extensionDataField;
                }
                set
                {
                    this.extensionDataField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string Email
            {
                get
                {
                    return this.EmailField;
                }
                set
                {
                    this.EmailField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string Op_infos
            {
                get
                {
                    return this.Op_infosField;
                }
                set
                {
                    this.Op_infosField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string Op_name
            {
                get
                {
                    return this.Op_nameField;
                }
                set
                {
                    this.Op_nameField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public bool Op_statut
            {
                get
                {
                    return this.Op_statutField;
                }
                set
                {
                    this.Op_statutField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string Password
            {
                get
                {
                    return this.PasswordField;
                }
                set
                {
                    this.PasswordField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string TokenApp
            {
                get
                {
                    return this.TokenAppField;
                }
                set
                {
                    this.TokenAppField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string TokenUser
            {
                get
                {
                    return this.TokenUserField;
                }
                set
                {
                    this.TokenUserField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public object[] data
            {
                get
                {
                    return this.dataField;
                }
                set
                {
                    this.dataField = value;
                }
            }
        }
    }


    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "IAuthenticationService")]
    public interface IAuthenticationService
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IAuthenticationService/LoginByPassword", ReplyAction = "http://tempuri.org/IAuthenticationService/LoginByPasswordResponse")]
        string LoginByPassword(string username, string password);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IAuthenticationService/LoginByPassword", ReplyAction = "http://tempuri.org/IAuthenticationService/LoginByPasswordResponse")]
        System.Threading.Tasks.Task<string> LoginByPasswordAsync(string username, string password);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IAuthenticationService/LoginByToken", ReplyAction = "http://tempuri.org/IAuthenticationService/LoginByTokenResponse")]
        string LoginByToken(string tokenApp);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IAuthenticationService/LoginByToken", ReplyAction = "http://tempuri.org/IAuthenticationService/LoginByTokenResponse")]
        System.Threading.Tasks.Task<string> LoginByTokenAsync(string tokenApp);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IAuthenticationService/Dispatching", ReplyAction = "http://tempuri.org/IAuthenticationService/DispatchingResponse")]
        Server_WCF_IIS.MSG Dispatching(Server_WCF_IIS.MSG msg);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IAuthenticationService/Dispatching", ReplyAction = "http://tempuri.org/IAuthenticationService/DispatchingResponse")]
        System.Threading.Tasks.Task<Server_WCF_IIS.MSG> DispatchingAsync(Server_WCF_IIS.MSG msg);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IAuthenticationService/LoadFiles", ReplyAction = "http://tempuri.org/IAuthenticationService/LoadFilesResponse")]
        string LoadFiles(string[] files);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IAuthenticationService/LoadFiles", ReplyAction = "http://tempuri.org/IAuthenticationService/LoadFilesResponse")]
        System.Threading.Tasks.Task<string> LoadFilesAsync(string[] files);
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAuthenticationServiceChannel : IAuthenticationService, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AuthenticationProxy : System.ServiceModel.ClientBase<IAuthenticationService>, IAuthenticationService
    {

        public AuthenticationProxy()
        {
        }

        public AuthenticationProxy(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public AuthenticationProxy(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public AuthenticationProxy(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public AuthenticationProxy(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        public string LoginByPassword(string username, string password)
        {
            return base.Channel.LoginByPassword(username, password);
        }

        public System.Threading.Tasks.Task<string> LoginByPasswordAsync(string username, string password)
        {
            return base.Channel.LoginByPasswordAsync(username, password);
        }

        public string LoginByToken(string tokenApp)
        {
            return base.Channel.LoginByToken(tokenApp);
        }

        public System.Threading.Tasks.Task<string> LoginByTokenAsync(string tokenApp)
        {
            return base.Channel.LoginByTokenAsync(tokenApp);
        }

        public Server_WCF_IIS.MSG Dispatching(Server_WCF_IIS.MSG msg)
        {
            return base.Channel.Dispatching(msg);
        }

        public System.Threading.Tasks.Task<Server_WCF_IIS.MSG> DispatchingAsync(Server_WCF_IIS.MSG msg)
        {
            return base.Channel.DispatchingAsync(msg);
        }

        public string LoadFiles(string[] files)
        {
            return base.Channel.LoadFiles(files);
        }

        public System.Threading.Tasks.Task<string> LoadFilesAsync(string[] files)
        {
            return base.Channel.LoadFilesAsync(files);
        }
    }
}

