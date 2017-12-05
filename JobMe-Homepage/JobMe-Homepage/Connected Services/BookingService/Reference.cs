﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JobMe_Homepage.BookingService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Booking", Namespace="http://schemas.datacontract.org/2004/07/ModelLayer")]
    [System.SerializableAttribute()]
    public partial class Booking : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime EndDateAndTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int InterviewAmountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MeetingIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime StartDateAndTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<JobMe_Homepage.BookingService.Session> sessionListField;
        
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
        public System.DateTime EndDateAndTime {
            get {
                return this.EndDateAndTimeField;
            }
            set {
                if ((this.EndDateAndTimeField.Equals(value) != true)) {
                    this.EndDateAndTimeField = value;
                    this.RaisePropertyChanged("EndDateAndTime");
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
        public int InterviewAmount {
            get {
                return this.InterviewAmountField;
            }
            set {
                if ((this.InterviewAmountField.Equals(value) != true)) {
                    this.InterviewAmountField = value;
                    this.RaisePropertyChanged("InterviewAmount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MeetingId {
            get {
                return this.MeetingIdField;
            }
            set {
                if ((this.MeetingIdField.Equals(value) != true)) {
                    this.MeetingIdField = value;
                    this.RaisePropertyChanged("MeetingId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime StartDateAndTime {
            get {
                return this.StartDateAndTimeField;
            }
            set {
                if ((this.StartDateAndTimeField.Equals(value) != true)) {
                    this.StartDateAndTimeField = value;
                    this.RaisePropertyChanged("StartDateAndTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<JobMe_Homepage.BookingService.Session> sessionList {
            get {
                return this.sessionListField;
            }
            set {
                if ((object.ReferenceEquals(this.sessionListField, value) != true)) {
                    this.sessionListField = value;
                    this.RaisePropertyChanged("sessionList");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Session", Namespace="http://schemas.datacontract.org/2004/07/ModelLayer")]
    [System.SerializableAttribute()]
    public partial class Session : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ApplierIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int BookingIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime EndTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime StartTimeField;
        
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
        public int ApplierId {
            get {
                return this.ApplierIdField;
            }
            set {
                if ((this.ApplierIdField.Equals(value) != true)) {
                    this.ApplierIdField = value;
                    this.RaisePropertyChanged("ApplierId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int BookingId {
            get {
                return this.BookingIdField;
            }
            set {
                if ((this.BookingIdField.Equals(value) != true)) {
                    this.BookingIdField = value;
                    this.RaisePropertyChanged("BookingId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime EndTime {
            get {
                return this.EndTimeField;
            }
            set {
                if ((this.EndTimeField.Equals(value) != true)) {
                    this.EndTimeField = value;
                    this.RaisePropertyChanged("EndTime");
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
        public System.DateTime StartTime {
            get {
                return this.StartTimeField;
            }
            set {
                if ((this.StartTimeField.Equals(value) != true)) {
                    this.StartTimeField = value;
                    this.RaisePropertyChanged("StartTime");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Meeting", Namespace="http://schemas.datacontract.org/2004/07/ModelLayer")]
    [System.SerializableAttribute()]
    public partial class Meeting : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CompanyIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<JobMe_Homepage.BookingService.Booking> bookingField;
        
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
        public int CompanyId {
            get {
                return this.CompanyIdField;
            }
            set {
                if ((this.CompanyIdField.Equals(value) != true)) {
                    this.CompanyIdField = value;
                    this.RaisePropertyChanged("CompanyId");
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
        public System.Collections.Generic.List<JobMe_Homepage.BookingService.Booking> booking {
            get {
                return this.bookingField;
            }
            set {
                if ((object.ReferenceEquals(this.bookingField, value) != true)) {
                    this.bookingField = value;
                    this.RaisePropertyChanged("booking");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BookingService.IBookingService")]
    public interface IBookingService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookingService/CreateBooking", ReplyAction="http://tempuri.org/IBookingService/CreateBookingResponse")]
        bool CreateBooking(JobMe_Homepage.BookingService.Booking booking);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookingService/CreateBooking", ReplyAction="http://tempuri.org/IBookingService/CreateBookingResponse")]
        System.Threading.Tasks.Task<bool> CreateBookingAsync(JobMe_Homepage.BookingService.Booking booking);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookingService/GetBooking", ReplyAction="http://tempuri.org/IBookingService/GetBookingResponse")]
        JobMe_Homepage.BookingService.Booking GetBooking(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookingService/GetBooking", ReplyAction="http://tempuri.org/IBookingService/GetBookingResponse")]
        System.Threading.Tasks.Task<JobMe_Homepage.BookingService.Booking> GetBookingAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookingService/GetAllBooking", ReplyAction="http://tempuri.org/IBookingService/GetAllBookingResponse")]
        System.Collections.Generic.List<JobMe_Homepage.BookingService.Booking> GetAllBooking(int meetingId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookingService/GetAllBooking", ReplyAction="http://tempuri.org/IBookingService/GetAllBookingResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<JobMe_Homepage.BookingService.Booking>> GetAllBookingAsync(int meetingId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookingService/UpdateBooking", ReplyAction="http://tempuri.org/IBookingService/UpdateBookingResponse")]
        bool UpdateBooking(JobMe_Homepage.BookingService.Booking booking);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookingService/UpdateBooking", ReplyAction="http://tempuri.org/IBookingService/UpdateBookingResponse")]
        System.Threading.Tasks.Task<bool> UpdateBookingAsync(JobMe_Homepage.BookingService.Booking booking);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookingService/CreateMeeting", ReplyAction="http://tempuri.org/IBookingService/CreateMeetingResponse")]
        JobMe_Homepage.BookingService.Meeting CreateMeeting(JobMe_Homepage.BookingService.Meeting meeting);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookingService/CreateMeeting", ReplyAction="http://tempuri.org/IBookingService/CreateMeetingResponse")]
        System.Threading.Tasks.Task<JobMe_Homepage.BookingService.Meeting> CreateMeetingAsync(JobMe_Homepage.BookingService.Meeting meeting);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookingService/GetMeeting", ReplyAction="http://tempuri.org/IBookingService/GetMeetingResponse")]
        JobMe_Homepage.BookingService.Meeting GetMeeting(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookingService/GetMeeting", ReplyAction="http://tempuri.org/IBookingService/GetMeetingResponse")]
        System.Threading.Tasks.Task<JobMe_Homepage.BookingService.Meeting> GetMeetingAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookingService/DeleteMeeting", ReplyAction="http://tempuri.org/IBookingService/DeleteMeetingResponse")]
        bool DeleteMeeting(JobMe_Homepage.BookingService.Meeting meeting);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookingService/DeleteMeeting", ReplyAction="http://tempuri.org/IBookingService/DeleteMeetingResponse")]
        System.Threading.Tasks.Task<bool> DeleteMeetingAsync(JobMe_Homepage.BookingService.Meeting meeting);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookingService/UpdateMeeting", ReplyAction="http://tempuri.org/IBookingService/UpdateMeetingResponse")]
        bool UpdateMeeting(JobMe_Homepage.BookingService.Meeting meeting);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookingService/UpdateMeeting", ReplyAction="http://tempuri.org/IBookingService/UpdateMeetingResponse")]
        System.Threading.Tasks.Task<bool> UpdateMeetingAsync(JobMe_Homepage.BookingService.Meeting meeting);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookingService/CreateSession", ReplyAction="http://tempuri.org/IBookingService/CreateSessionResponse")]
        bool CreateSession(JobMe_Homepage.BookingService.Session session, JobMe_Homepage.BookingService.Booking booking);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookingService/CreateSession", ReplyAction="http://tempuri.org/IBookingService/CreateSessionResponse")]
        System.Threading.Tasks.Task<bool> CreateSessionAsync(JobMe_Homepage.BookingService.Session session, JobMe_Homepage.BookingService.Booking booking);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookingService/GetSession", ReplyAction="http://tempuri.org/IBookingService/GetSessionResponse")]
        JobMe_Homepage.BookingService.Session GetSession(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookingService/GetSession", ReplyAction="http://tempuri.org/IBookingService/GetSessionResponse")]
        System.Threading.Tasks.Task<JobMe_Homepage.BookingService.Session> GetSessionAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookingService/GetAllSession", ReplyAction="http://tempuri.org/IBookingService/GetAllSessionResponse")]
        System.Collections.Generic.List<JobMe_Homepage.BookingService.Session> GetAllSession(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookingService/GetAllSession", ReplyAction="http://tempuri.org/IBookingService/GetAllSessionResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<JobMe_Homepage.BookingService.Session>> GetAllSessionAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookingService/DeleteSession", ReplyAction="http://tempuri.org/IBookingService/DeleteSessionResponse")]
        bool DeleteSession(JobMe_Homepage.BookingService.Session session);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookingService/DeleteSession", ReplyAction="http://tempuri.org/IBookingService/DeleteSessionResponse")]
        System.Threading.Tasks.Task<bool> DeleteSessionAsync(JobMe_Homepage.BookingService.Session session);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBookingServiceChannel : JobMe_Homepage.BookingService.IBookingService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BookingServiceClient : System.ServiceModel.ClientBase<JobMe_Homepage.BookingService.IBookingService>, JobMe_Homepage.BookingService.IBookingService {
        
        public BookingServiceClient() {
        }
        
        public BookingServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BookingServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BookingServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BookingServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool CreateBooking(JobMe_Homepage.BookingService.Booking booking) {
            return base.Channel.CreateBooking(booking);
        }
        
        public System.Threading.Tasks.Task<bool> CreateBookingAsync(JobMe_Homepage.BookingService.Booking booking) {
            return base.Channel.CreateBookingAsync(booking);
        }
        
        public JobMe_Homepage.BookingService.Booking GetBooking(int id) {
            return base.Channel.GetBooking(id);
        }
        
        public System.Threading.Tasks.Task<JobMe_Homepage.BookingService.Booking> GetBookingAsync(int id) {
            return base.Channel.GetBookingAsync(id);
        }
        
        public System.Collections.Generic.List<JobMe_Homepage.BookingService.Booking> GetAllBooking(int meetingId) {
            return base.Channel.GetAllBooking(meetingId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<JobMe_Homepage.BookingService.Booking>> GetAllBookingAsync(int meetingId) {
            return base.Channel.GetAllBookingAsync(meetingId);
        }
        
        public bool UpdateBooking(JobMe_Homepage.BookingService.Booking booking) {
            return base.Channel.UpdateBooking(booking);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateBookingAsync(JobMe_Homepage.BookingService.Booking booking) {
            return base.Channel.UpdateBookingAsync(booking);
        }
        
        public JobMe_Homepage.BookingService.Meeting CreateMeeting(JobMe_Homepage.BookingService.Meeting meeting) {
            return base.Channel.CreateMeeting(meeting);
        }
        
        public System.Threading.Tasks.Task<JobMe_Homepage.BookingService.Meeting> CreateMeetingAsync(JobMe_Homepage.BookingService.Meeting meeting) {
            return base.Channel.CreateMeetingAsync(meeting);
        }
        
        public JobMe_Homepage.BookingService.Meeting GetMeeting(int id) {
            return base.Channel.GetMeeting(id);
        }
        
        public System.Threading.Tasks.Task<JobMe_Homepage.BookingService.Meeting> GetMeetingAsync(int id) {
            return base.Channel.GetMeetingAsync(id);
        }
        
        public bool DeleteMeeting(JobMe_Homepage.BookingService.Meeting meeting) {
            return base.Channel.DeleteMeeting(meeting);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteMeetingAsync(JobMe_Homepage.BookingService.Meeting meeting) {
            return base.Channel.DeleteMeetingAsync(meeting);
        }
        
        public bool UpdateMeeting(JobMe_Homepage.BookingService.Meeting meeting) {
            return base.Channel.UpdateMeeting(meeting);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateMeetingAsync(JobMe_Homepage.BookingService.Meeting meeting) {
            return base.Channel.UpdateMeetingAsync(meeting);
        }
        
        public bool CreateSession(JobMe_Homepage.BookingService.Session session, JobMe_Homepage.BookingService.Booking booking) {
            return base.Channel.CreateSession(session, booking);
        }
        
        public System.Threading.Tasks.Task<bool> CreateSessionAsync(JobMe_Homepage.BookingService.Session session, JobMe_Homepage.BookingService.Booking booking) {
            return base.Channel.CreateSessionAsync(session, booking);
        }
        
        public JobMe_Homepage.BookingService.Session GetSession(int id) {
            return base.Channel.GetSession(id);
        }
        
        public System.Threading.Tasks.Task<JobMe_Homepage.BookingService.Session> GetSessionAsync(int id) {
            return base.Channel.GetSessionAsync(id);
        }
        
        public System.Collections.Generic.List<JobMe_Homepage.BookingService.Session> GetAllSession(int id) {
            return base.Channel.GetAllSession(id);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<JobMe_Homepage.BookingService.Session>> GetAllSessionAsync(int id) {
            return base.Channel.GetAllSessionAsync(id);
        }
        
        public bool DeleteSession(JobMe_Homepage.BookingService.Session session) {
            return base.Channel.DeleteSession(session);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteSessionAsync(JobMe_Homepage.BookingService.Session session) {
            return base.Channel.DeleteSessionAsync(session);
        }
    }
}
