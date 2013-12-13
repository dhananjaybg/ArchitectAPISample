﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1008
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EdwardsApp1.User25ServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="InfoShareFault", Namespace="http://sdl.com/trisoft/2012/06/WebServices/Contracts/Faults/API25/")]
    [System.SerializableAttribute()]
    public partial class InfoShareFault : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long InfoShareErrorNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OriginField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string XMLDetailField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long InfoShareErrorNumber {
            get {
                return this.InfoShareErrorNumberField;
            }
            set {
                if ((this.InfoShareErrorNumberField.Equals(value) != true)) {
                    this.InfoShareErrorNumberField = value;
                    this.RaisePropertyChanged("InfoShareErrorNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Origin {
            get {
                return this.OriginField;
            }
            set {
                if ((object.ReferenceEquals(this.OriginField, value) != true)) {
                    this.OriginField = value;
                    this.RaisePropertyChanged("Origin");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string XMLDetail {
            get {
                return this.XMLDetailField;
            }
            set {
                if ((object.ReferenceEquals(this.XMLDetailField, value) != true)) {
                    this.XMLDetailField = value;
                    this.RaisePropertyChanged("XMLDetail");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ActivityFilter", Namespace="http://sdl.com/trisoft/2012/06/WebServices/Contracts/Enumerations/API25/")]
    public enum ActivityFilter : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        None = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Active = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Inactive = 2,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/", ConfigurationName="User25ServiceReference.User")]
    public interface User {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/GetMetadataByIshUs" +
            "erRef", ReplyAction="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/GetMetadataByIshUs" +
            "erRefResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EdwardsApp1.User25ServiceReference.InfoShareFault), Action="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/GetMetadataByIshUs" +
            "erRefInfoShareFault", Name="InfoShareFault", Namespace="http://sdl.com/trisoft/2012/06/WebServices/Contracts/Faults/API25/")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="xmlObjectList")]
        string GetMetadataByIshUserRef(long userRef, string xmlRequestedMetadata);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/GetMetadata", ReplyAction="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/GetMetadataRespons" +
            "e")]
        [System.ServiceModel.FaultContractAttribute(typeof(EdwardsApp1.User25ServiceReference.InfoShareFault), Action="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/GetMetadataInfoSha" +
            "reFault", Name="InfoShareFault", Namespace="http://sdl.com/trisoft/2012/06/WebServices/Contracts/Faults/API25/")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="xmlObjectList")]
        string GetMetadata(string userId, string xmlRequestedMetadata);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/GetMyMetadata", ReplyAction="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/GetMyMetadataRespo" +
            "nse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EdwardsApp1.User25ServiceReference.InfoShareFault), Action="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/GetMyMetadataInfoS" +
            "hareFault", Name="InfoShareFault", Namespace="http://sdl.com/trisoft/2012/06/WebServices/Contracts/Faults/API25/")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="xmlObjectList")]
        string GetMyMetadata(string xmlRequestedMetadata);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/RetrieveMetadata", ReplyAction="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/RetrieveMetadataRe" +
            "sponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EdwardsApp1.User25ServiceReference.InfoShareFault), Action="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/RetrieveMetadataIn" +
            "foShareFault", Name="InfoShareFault", Namespace="http://sdl.com/trisoft/2012/06/WebServices/Contracts/Faults/API25/")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="xmlObjectList")]
        string RetrieveMetadata(string[] userIds, EdwardsApp1.User25ServiceReference.ActivityFilter activityFilter, string xmlMetadataFilter, string xmlRequestedMetadata);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/RetrieveMetadataBy" +
            "IshUserRefs", ReplyAction="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/RetrieveMetadataBy" +
            "IshUserRefsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EdwardsApp1.User25ServiceReference.InfoShareFault), Action="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/RetrieveMetadataBy" +
            "IshUserRefsInfoShareFault", Name="InfoShareFault", Namespace="http://sdl.com/trisoft/2012/06/WebServices/Contracts/Faults/API25/")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="xmlObjectList")]
        string RetrieveMetadataByIshUserRefs(long[] userRefs, EdwardsApp1.User25ServiceReference.ActivityFilter activityFilter, string xmlMetadataFilter, string xmlRequestedMetadata);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/Find", ReplyAction="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/FindResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EdwardsApp1.User25ServiceReference.InfoShareFault), Action="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/FindInfoShareFault" +
            "", Name="InfoShareFault", Namespace="http://sdl.com/trisoft/2012/06/WebServices/Contracts/Faults/API25/")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="xmlObjectList")]
        string Find(EdwardsApp1.User25ServiceReference.ActivityFilter activityFilter, string xmlMetadataFilter, string xmlRequestedMetadata);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/Create", ReplyAction="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/CreateResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EdwardsApp1.User25ServiceReference.InfoShareFault), Action="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/CreateInfoShareFau" +
            "lt", Name="InfoShareFault", Namespace="http://sdl.com/trisoft/2012/06/WebServices/Contracts/Faults/API25/")]
        string Create(string userName, string xmlMetadata);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/Update", ReplyAction="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/UpdateResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EdwardsApp1.User25ServiceReference.InfoShareFault), Action="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/UpdateInfoShareFau" +
            "lt", Name="InfoShareFault", Namespace="http://sdl.com/trisoft/2012/06/WebServices/Contracts/Faults/API25/")]
        void Update(string userId, string xmlMetadata);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/Delete", ReplyAction="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/DeleteResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EdwardsApp1.User25ServiceReference.InfoShareFault), Action="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/DeleteInfoShareFau" +
            "lt", Name="InfoShareFault", Namespace="http://sdl.com/trisoft/2012/06/WebServices/Contracts/Faults/API25/")]
        void Delete(string userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/ChangePassword", ReplyAction="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/ChangePasswordResp" +
            "onse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EdwardsApp1.User25ServiceReference.InfoShareFault), Action="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/ChangePasswordInfo" +
            "ShareFault", Name="InfoShareFault", Namespace="http://sdl.com/trisoft/2012/06/WebServices/Contracts/Faults/API25/")]
        void ChangePassword(string oldPassword, string newPassword);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/IsInRole", ReplyAction="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/IsInRoleResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EdwardsApp1.User25ServiceReference.InfoShareFault), Action="http://sdl.com/trisoft/2012/06/WebServices/Services/API25/User/IsInRoleInfoShareF" +
            "ault", Name="InfoShareFault", Namespace="http://sdl.com/trisoft/2012/06/WebServices/Contracts/Faults/API25/")]
        bool IsInRole(string userRoleId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface UserChannel : EdwardsApp1.User25ServiceReference.User, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserClient : System.ServiceModel.ClientBase<EdwardsApp1.User25ServiceReference.User>, EdwardsApp1.User25ServiceReference.User {
        
        public UserClient() {
        }
        
        public UserClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetMetadataByIshUserRef(long userRef, string xmlRequestedMetadata) {
            return base.Channel.GetMetadataByIshUserRef(userRef, xmlRequestedMetadata);
        }
        
        public string GetMetadata(string userId, string xmlRequestedMetadata) {
            return base.Channel.GetMetadata(userId, xmlRequestedMetadata);
        }
        
        public string GetMyMetadata(string xmlRequestedMetadata) {
            return base.Channel.GetMyMetadata(xmlRequestedMetadata);
        }
        
        public string RetrieveMetadata(string[] userIds, EdwardsApp1.User25ServiceReference.ActivityFilter activityFilter, string xmlMetadataFilter, string xmlRequestedMetadata) {
            return base.Channel.RetrieveMetadata(userIds, activityFilter, xmlMetadataFilter, xmlRequestedMetadata);
        }
        
        public string RetrieveMetadataByIshUserRefs(long[] userRefs, EdwardsApp1.User25ServiceReference.ActivityFilter activityFilter, string xmlMetadataFilter, string xmlRequestedMetadata) {
            return base.Channel.RetrieveMetadataByIshUserRefs(userRefs, activityFilter, xmlMetadataFilter, xmlRequestedMetadata);
        }
        
        public string Find(EdwardsApp1.User25ServiceReference.ActivityFilter activityFilter, string xmlMetadataFilter, string xmlRequestedMetadata) {
            return base.Channel.Find(activityFilter, xmlMetadataFilter, xmlRequestedMetadata);
        }
        
        public string Create(string userName, string xmlMetadata) {
            return base.Channel.Create(userName, xmlMetadata);
        }
        
        public void Update(string userId, string xmlMetadata) {
            base.Channel.Update(userId, xmlMetadata);
        }
        
        public void Delete(string userId) {
            base.Channel.Delete(userId);
        }
        
        public void ChangePassword(string oldPassword, string newPassword) {
            base.Channel.ChangePassword(oldPassword, newPassword);
        }
        
        public bool IsInRole(string userRoleId) {
            return base.Channel.IsInRole(userRoleId);
        }
    }
}
