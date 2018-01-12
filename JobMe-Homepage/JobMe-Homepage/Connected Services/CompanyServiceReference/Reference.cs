﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JobMe_Homepage.CompanyServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Company", Namespace="http://schemas.datacontract.org/2004/07/ModelLayer")]
    [System.SerializableAttribute()]
    public partial class Company : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BannerURLField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CVRField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CompanyNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CountryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string HomepageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ImageURLField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MaxRadiusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PhoneField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private JobMe_Homepage.CompanyServiceReference.BusinessType businessTypeField;
        
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
        public string Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BannerURL {
            get {
                return this.BannerURLField;
            }
            set {
                if ((object.ReferenceEquals(this.BannerURLField, value) != true)) {
                    this.BannerURLField = value;
                    this.RaisePropertyChanged("BannerURL");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CVR {
            get {
                return this.CVRField;
            }
            set {
                if ((this.CVRField.Equals(value) != true)) {
                    this.CVRField = value;
                    this.RaisePropertyChanged("CVR");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CompanyName {
            get {
                return this.CompanyNameField;
            }
            set {
                if ((object.ReferenceEquals(this.CompanyNameField, value) != true)) {
                    this.CompanyNameField = value;
                    this.RaisePropertyChanged("CompanyName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Country {
            get {
                return this.CountryField;
            }
            set {
                if ((object.ReferenceEquals(this.CountryField, value) != true)) {
                    this.CountryField = value;
                    this.RaisePropertyChanged("Country");
                }
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
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Homepage {
            get {
                return this.HomepageField;
            }
            set {
                if ((object.ReferenceEquals(this.HomepageField, value) != true)) {
                    this.HomepageField = value;
                    this.RaisePropertyChanged("Homepage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ImageURL {
            get {
                return this.ImageURLField;
            }
            set {
                if ((object.ReferenceEquals(this.ImageURLField, value) != true)) {
                    this.ImageURLField = value;
                    this.RaisePropertyChanged("ImageURL");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MaxRadius {
            get {
                return this.MaxRadiusField;
            }
            set {
                if ((this.MaxRadiusField.Equals(value) != true)) {
                    this.MaxRadiusField = value;
                    this.RaisePropertyChanged("MaxRadius");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Phone {
            get {
                return this.PhoneField;
            }
            set {
                if ((this.PhoneField.Equals(value) != true)) {
                    this.PhoneField = value;
                    this.RaisePropertyChanged("Phone");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public JobMe_Homepage.CompanyServiceReference.BusinessType businessType {
            get {
                return this.businessTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.businessTypeField, value) != true)) {
                    this.businessTypeField = value;
                    this.RaisePropertyChanged("businessType");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BusinessType", Namespace="http://schemas.datacontract.org/2004/07/ModelLayer")]
    [System.SerializableAttribute()]
    public partial class BusinessType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TypeField;
        
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
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Type {
            get {
                return this.TypeField;
            }
            set {
                if ((object.ReferenceEquals(this.TypeField, value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CompanyServiceReference.ICompanyService")]
    public interface ICompanyService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICompanyService/CreateCompany", ReplyAction="http://tempuri.org/ICompanyService/CreateCompanyResponse")]
        void CreateCompany(JobMe_Homepage.CompanyServiceReference.Company company);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICompanyService/CreateCompany", ReplyAction="http://tempuri.org/ICompanyService/CreateCompanyResponse")]
        System.Threading.Tasks.Task CreateCompanyAsync(JobMe_Homepage.CompanyServiceReference.Company company);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICompanyService/DeleteCompany", ReplyAction="http://tempuri.org/ICompanyService/DeleteCompanyResponse")]
        void DeleteCompany(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICompanyService/DeleteCompany", ReplyAction="http://tempuri.org/ICompanyService/DeleteCompanyResponse")]
        System.Threading.Tasks.Task DeleteCompanyAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICompanyService/GetCompany", ReplyAction="http://tempuri.org/ICompanyService/GetCompanyResponse")]
        JobMe_Homepage.CompanyServiceReference.Company GetCompany(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICompanyService/GetCompany", ReplyAction="http://tempuri.org/ICompanyService/GetCompanyResponse")]
        System.Threading.Tasks.Task<JobMe_Homepage.CompanyServiceReference.Company> GetCompanyAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICompanyService/GetAllCompany", ReplyAction="http://tempuri.org/ICompanyService/GetAllCompanyResponse")]
        JobMe_Homepage.CompanyServiceReference.Company[] GetAllCompany();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICompanyService/GetAllCompany", ReplyAction="http://tempuri.org/ICompanyService/GetAllCompanyResponse")]
        System.Threading.Tasks.Task<JobMe_Homepage.CompanyServiceReference.Company[]> GetAllCompanyAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICompanyService/UpdateCompany", ReplyAction="http://tempuri.org/ICompanyService/UpdateCompanyResponse")]
        void UpdateCompany(JobMe_Homepage.CompanyServiceReference.Company obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICompanyService/UpdateCompany", ReplyAction="http://tempuri.org/ICompanyService/UpdateCompanyResponse")]
        System.Threading.Tasks.Task UpdateCompanyAsync(JobMe_Homepage.CompanyServiceReference.Company obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICompanyService/Login", ReplyAction="http://tempuri.org/ICompanyService/LoginResponse")]
        JobMe_Homepage.CompanyServiceReference.Company Login(string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICompanyService/Login", ReplyAction="http://tempuri.org/ICompanyService/LoginResponse")]
        System.Threading.Tasks.Task<JobMe_Homepage.CompanyServiceReference.Company> LoginAsync(string email, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICompanyServiceChannel : JobMe_Homepage.CompanyServiceReference.ICompanyService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CompanyServiceClient : System.ServiceModel.ClientBase<JobMe_Homepage.CompanyServiceReference.ICompanyService>, JobMe_Homepage.CompanyServiceReference.ICompanyService {
        
        public CompanyServiceClient() {
        }
        
        public CompanyServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CompanyServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CompanyServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CompanyServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void CreateCompany(JobMe_Homepage.CompanyServiceReference.Company company) {
            base.Channel.CreateCompany(company);
        }
        
        public System.Threading.Tasks.Task CreateCompanyAsync(JobMe_Homepage.CompanyServiceReference.Company company) {
            return base.Channel.CreateCompanyAsync(company);
        }
        
        public void DeleteCompany(int id) {
            base.Channel.DeleteCompany(id);
        }
        
        public System.Threading.Tasks.Task DeleteCompanyAsync(int id) {
            return base.Channel.DeleteCompanyAsync(id);
        }
        
        public JobMe_Homepage.CompanyServiceReference.Company GetCompany(int id) {
            return base.Channel.GetCompany(id);
        }
        
        public System.Threading.Tasks.Task<JobMe_Homepage.CompanyServiceReference.Company> GetCompanyAsync(int id) {
            return base.Channel.GetCompanyAsync(id);
        }
        
        public JobMe_Homepage.CompanyServiceReference.Company[] GetAllCompany() {
            return base.Channel.GetAllCompany();
        }
        
        public System.Threading.Tasks.Task<JobMe_Homepage.CompanyServiceReference.Company[]> GetAllCompanyAsync() {
            return base.Channel.GetAllCompanyAsync();
        }
        
        public void UpdateCompany(JobMe_Homepage.CompanyServiceReference.Company obj) {
            base.Channel.UpdateCompany(obj);
        }
        
        public System.Threading.Tasks.Task UpdateCompanyAsync(JobMe_Homepage.CompanyServiceReference.Company obj) {
            return base.Channel.UpdateCompanyAsync(obj);
        }
        
        public JobMe_Homepage.CompanyServiceReference.Company Login(string email, string password) {
            return base.Channel.Login(email, password);
        }
        
        public System.Threading.Tasks.Task<JobMe_Homepage.CompanyServiceReference.Company> LoginAsync(string email, string password) {
            return base.Channel.LoginAsync(email, password);
        }
    }
}
