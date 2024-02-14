﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace Web_Services.WS_Programs_And_Degrees {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ProgramsAndDegreesSoap", Namespace="http://np-wsw.temple.edu/")]
    public partial class ProgramsAndDegrees : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetExactOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetStartsWithOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetFirstLettersMajorOperationCompleted;
        
        private System.Threading.SendOrPostCallback SearchOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetDegreesOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetAllProgramsOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetTagsOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetAllCollegesOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ProgramsAndDegrees() {
            this.Url = global::Web_Services.Properties.Settings.Default.Web_Services_WS_Programs_And_Degrees_ProgramsAndDegrees;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetExactCompletedEventHandler GetExactCompleted;
        
        /// <remarks/>
        public event GetStartsWithCompletedEventHandler GetStartsWithCompleted;
        
        /// <remarks/>
        public event GetFirstLettersMajorCompletedEventHandler GetFirstLettersMajorCompleted;
        
        /// <remarks/>
        public event SearchCompletedEventHandler SearchCompleted;
        
        /// <remarks/>
        public event GetDegreesCompletedEventHandler GetDegreesCompleted;
        
        /// <remarks/>
        public event GetAllProgramsCompletedEventHandler GetAllProgramsCompleted;
        
        /// <remarks/>
        public event GetTagsCompletedEventHandler GetTagsCompleted;
        
        /// <remarks/>
        public event GetAllCollegesCompletedEventHandler GetAllCollegesCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://np-wsw.temple.edu/GetExact", RequestNamespace="http://np-wsw.temple.edu/", ResponseNamespace="http://np-wsw.temple.edu/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ProgramsAndDegreesEntry[] GetExact(string username, string password, string searchString, string dataField) {
            object[] results = this.Invoke("GetExact", new object[] {
                        username,
                        password,
                        searchString,
                        dataField});
            return ((ProgramsAndDegreesEntry[])(results[0]));
        }
        
        /// <remarks/>
        public void GetExactAsync(string username, string password, string searchString, string dataField) {
            this.GetExactAsync(username, password, searchString, dataField, null);
        }
        
        /// <remarks/>
        public void GetExactAsync(string username, string password, string searchString, string dataField, object userState) {
            if ((this.GetExactOperationCompleted == null)) {
                this.GetExactOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetExactOperationCompleted);
            }
            this.InvokeAsync("GetExact", new object[] {
                        username,
                        password,
                        searchString,
                        dataField}, this.GetExactOperationCompleted, userState);
        }
        
        private void OnGetExactOperationCompleted(object arg) {
            if ((this.GetExactCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetExactCompleted(this, new GetExactCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://np-wsw.temple.edu/GetStartsWith", RequestNamespace="http://np-wsw.temple.edu/", ResponseNamespace="http://np-wsw.temple.edu/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ProgramsAndDegreesEntry[] GetStartsWith(string username, string password, string searchString, string dataField) {
            object[] results = this.Invoke("GetStartsWith", new object[] {
                        username,
                        password,
                        searchString,
                        dataField});
            return ((ProgramsAndDegreesEntry[])(results[0]));
        }
        
        /// <remarks/>
        public void GetStartsWithAsync(string username, string password, string searchString, string dataField) {
            this.GetStartsWithAsync(username, password, searchString, dataField, null);
        }
        
        /// <remarks/>
        public void GetStartsWithAsync(string username, string password, string searchString, string dataField, object userState) {
            if ((this.GetStartsWithOperationCompleted == null)) {
                this.GetStartsWithOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetStartsWithOperationCompleted);
            }
            this.InvokeAsync("GetStartsWith", new object[] {
                        username,
                        password,
                        searchString,
                        dataField}, this.GetStartsWithOperationCompleted, userState);
        }
        
        private void OnGetStartsWithOperationCompleted(object arg) {
            if ((this.GetStartsWithCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetStartsWithCompleted(this, new GetStartsWithCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://np-wsw.temple.edu/GetFirstLettersMajor", RequestNamespace="http://np-wsw.temple.edu/", ResponseNamespace="http://np-wsw.temple.edu/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ProgramsAndDegreesEntry[] GetFirstLettersMajor(string username, string password) {
            object[] results = this.Invoke("GetFirstLettersMajor", new object[] {
                        username,
                        password});
            return ((ProgramsAndDegreesEntry[])(results[0]));
        }
        
        /// <remarks/>
        public void GetFirstLettersMajorAsync(string username, string password) {
            this.GetFirstLettersMajorAsync(username, password, null);
        }
        
        /// <remarks/>
        public void GetFirstLettersMajorAsync(string username, string password, object userState) {
            if ((this.GetFirstLettersMajorOperationCompleted == null)) {
                this.GetFirstLettersMajorOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetFirstLettersMajorOperationCompleted);
            }
            this.InvokeAsync("GetFirstLettersMajor", new object[] {
                        username,
                        password}, this.GetFirstLettersMajorOperationCompleted, userState);
        }
        
        private void OnGetFirstLettersMajorOperationCompleted(object arg) {
            if ((this.GetFirstLettersMajorCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetFirstLettersMajorCompleted(this, new GetFirstLettersMajorCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://np-wsw.temple.edu/Search", RequestNamespace="http://np-wsw.temple.edu/", ResponseNamespace="http://np-wsw.temple.edu/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ProgramsAndDegreesEntry[] Search(string username, string password, string searchString) {
            object[] results = this.Invoke("Search", new object[] {
                        username,
                        password,
                        searchString});
            return ((ProgramsAndDegreesEntry[])(results[0]));
        }
        
        /// <remarks/>
        public void SearchAsync(string username, string password, string searchString) {
            this.SearchAsync(username, password, searchString, null);
        }
        
        /// <remarks/>
        public void SearchAsync(string username, string password, string searchString, object userState) {
            if ((this.SearchOperationCompleted == null)) {
                this.SearchOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSearchOperationCompleted);
            }
            this.InvokeAsync("Search", new object[] {
                        username,
                        password,
                        searchString}, this.SearchOperationCompleted, userState);
        }
        
        private void OnSearchOperationCompleted(object arg) {
            if ((this.SearchCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SearchCompleted(this, new SearchCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://np-wsw.temple.edu/GetDegrees", RequestNamespace="http://np-wsw.temple.edu/", ResponseNamespace="http://np-wsw.temple.edu/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ProgramsAndDegreesEntry[] GetDegrees(string username, string password) {
            object[] results = this.Invoke("GetDegrees", new object[] {
                        username,
                        password});
            return ((ProgramsAndDegreesEntry[])(results[0]));
        }
        
        /// <remarks/>
        public void GetDegreesAsync(string username, string password) {
            this.GetDegreesAsync(username, password, null);
        }
        
        /// <remarks/>
        public void GetDegreesAsync(string username, string password, object userState) {
            if ((this.GetDegreesOperationCompleted == null)) {
                this.GetDegreesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetDegreesOperationCompleted);
            }
            this.InvokeAsync("GetDegrees", new object[] {
                        username,
                        password}, this.GetDegreesOperationCompleted, userState);
        }
        
        private void OnGetDegreesOperationCompleted(object arg) {
            if ((this.GetDegreesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetDegreesCompleted(this, new GetDegreesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://np-wsw.temple.edu/GetAllPrograms", RequestNamespace="http://np-wsw.temple.edu/", ResponseNamespace="http://np-wsw.temple.edu/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ProgramsAndDegreesEntry[] GetAllPrograms(string username, string password) {
            object[] results = this.Invoke("GetAllPrograms", new object[] {
                        username,
                        password});
            return ((ProgramsAndDegreesEntry[])(results[0]));
        }
        
        /// <remarks/>
        public void GetAllProgramsAsync(string username, string password) {
            this.GetAllProgramsAsync(username, password, null);
        }
        
        /// <remarks/>
        public void GetAllProgramsAsync(string username, string password, object userState) {
            if ((this.GetAllProgramsOperationCompleted == null)) {
                this.GetAllProgramsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetAllProgramsOperationCompleted);
            }
            this.InvokeAsync("GetAllPrograms", new object[] {
                        username,
                        password}, this.GetAllProgramsOperationCompleted, userState);
        }
        
        private void OnGetAllProgramsOperationCompleted(object arg) {
            if ((this.GetAllProgramsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetAllProgramsCompleted(this, new GetAllProgramsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://np-wsw.temple.edu/GetTags", RequestNamespace="http://np-wsw.temple.edu/", ResponseNamespace="http://np-wsw.temple.edu/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ProgramsAndDegreesEntry[] GetTags(string username, string password) {
            object[] results = this.Invoke("GetTags", new object[] {
                        username,
                        password});
            return ((ProgramsAndDegreesEntry[])(results[0]));
        }
        
        /// <remarks/>
        public void GetTagsAsync(string username, string password) {
            this.GetTagsAsync(username, password, null);
        }
        
        /// <remarks/>
        public void GetTagsAsync(string username, string password, object userState) {
            if ((this.GetTagsOperationCompleted == null)) {
                this.GetTagsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetTagsOperationCompleted);
            }
            this.InvokeAsync("GetTags", new object[] {
                        username,
                        password}, this.GetTagsOperationCompleted, userState);
        }
        
        private void OnGetTagsOperationCompleted(object arg) {
            if ((this.GetTagsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetTagsCompleted(this, new GetTagsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://np-wsw.temple.edu/GetAllColleges", RequestNamespace="http://np-wsw.temple.edu/", ResponseNamespace="http://np-wsw.temple.edu/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ProgramsAndDegreesEntry[] GetAllColleges(string username, string password) {
            object[] results = this.Invoke("GetAllColleges", new object[] {
                        username,
                        password});
            return ((ProgramsAndDegreesEntry[])(results[0]));
        }
        
        /// <remarks/>
        public void GetAllCollegesAsync(string username, string password) {
            this.GetAllCollegesAsync(username, password, null);
        }
        
        /// <remarks/>
        public void GetAllCollegesAsync(string username, string password, object userState) {
            if ((this.GetAllCollegesOperationCompleted == null)) {
                this.GetAllCollegesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetAllCollegesOperationCompleted);
            }
            this.InvokeAsync("GetAllColleges", new object[] {
                        username,
                        password}, this.GetAllCollegesOperationCompleted, userState);
        }
        
        private void OnGetAllCollegesOperationCompleted(object arg) {
            if ((this.GetAllCollegesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetAllCollegesCompleted(this, new GetAllCollegesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://np-wsw.temple.edu/")]
    public partial class ProgramsAndDegreesEntry {
        
        private string majorField;
        
        private string majorCodeField;
        
        private string levelField;
        
        private string levelCodeField;
        
        private string degreeField;
        
        private string degreeCodeField;
        
        private string sobcurrProgramField;
        
        private string collegeField;
        
        private string collegeCodeField;
        
        private string aboutField;
        
        private string academicPlanField;
        
        private string totalCreditHoursField;
        
        private string tagsField;
        
        private string tagField;
        
        private string tagInstancesField;
        
        private string urlField;
        
        private string bulletinUrlField;
        
        private string calculatorUrlField;
        
        private string careersField;
        
        private string applyUrlField;
        
        private string requestInfoUrlField;
        
        private string visitUrlField;
        
        private string relatedProgramsField;
        
        private string onlineIndField;
        
        private string firstLetterOfMajorField;
        
        private string resultField;
        
        /// <remarks/>
        public string major {
            get {
                return this.majorField;
            }
            set {
                this.majorField = value;
            }
        }
        
        /// <remarks/>
        public string majorCode {
            get {
                return this.majorCodeField;
            }
            set {
                this.majorCodeField = value;
            }
        }
        
        /// <remarks/>
        public string level {
            get {
                return this.levelField;
            }
            set {
                this.levelField = value;
            }
        }
        
        /// <remarks/>
        public string levelCode {
            get {
                return this.levelCodeField;
            }
            set {
                this.levelCodeField = value;
            }
        }
        
        /// <remarks/>
        public string degree {
            get {
                return this.degreeField;
            }
            set {
                this.degreeField = value;
            }
        }
        
        /// <remarks/>
        public string degreeCode {
            get {
                return this.degreeCodeField;
            }
            set {
                this.degreeCodeField = value;
            }
        }
        
        /// <remarks/>
        public string sobcurrProgram {
            get {
                return this.sobcurrProgramField;
            }
            set {
                this.sobcurrProgramField = value;
            }
        }
        
        /// <remarks/>
        public string college {
            get {
                return this.collegeField;
            }
            set {
                this.collegeField = value;
            }
        }
        
        /// <remarks/>
        public string collegeCode {
            get {
                return this.collegeCodeField;
            }
            set {
                this.collegeCodeField = value;
            }
        }
        
        /// <remarks/>
        public string about {
            get {
                return this.aboutField;
            }
            set {
                this.aboutField = value;
            }
        }
        
        /// <remarks/>
        public string academicPlan {
            get {
                return this.academicPlanField;
            }
            set {
                this.academicPlanField = value;
            }
        }
        
        /// <remarks/>
        public string totalCreditHours {
            get {
                return this.totalCreditHoursField;
            }
            set {
                this.totalCreditHoursField = value;
            }
        }
        
        /// <remarks/>
        public string tags {
            get {
                return this.tagsField;
            }
            set {
                this.tagsField = value;
            }
        }
        
        /// <remarks/>
        public string tag {
            get {
                return this.tagField;
            }
            set {
                this.tagField = value;
            }
        }
        
        /// <remarks/>
        public string tagInstances {
            get {
                return this.tagInstancesField;
            }
            set {
                this.tagInstancesField = value;
            }
        }
        
        /// <remarks/>
        public string url {
            get {
                return this.urlField;
            }
            set {
                this.urlField = value;
            }
        }
        
        /// <remarks/>
        public string bulletinUrl {
            get {
                return this.bulletinUrlField;
            }
            set {
                this.bulletinUrlField = value;
            }
        }
        
        /// <remarks/>
        public string calculatorUrl {
            get {
                return this.calculatorUrlField;
            }
            set {
                this.calculatorUrlField = value;
            }
        }
        
        /// <remarks/>
        public string careers {
            get {
                return this.careersField;
            }
            set {
                this.careersField = value;
            }
        }
        
        /// <remarks/>
        public string applyUrl {
            get {
                return this.applyUrlField;
            }
            set {
                this.applyUrlField = value;
            }
        }
        
        /// <remarks/>
        public string requestInfoUrl {
            get {
                return this.requestInfoUrlField;
            }
            set {
                this.requestInfoUrlField = value;
            }
        }
        
        /// <remarks/>
        public string visitUrl {
            get {
                return this.visitUrlField;
            }
            set {
                this.visitUrlField = value;
            }
        }
        
        /// <remarks/>
        public string relatedPrograms {
            get {
                return this.relatedProgramsField;
            }
            set {
                this.relatedProgramsField = value;
            }
        }
        
        /// <remarks/>
        public string onlineInd {
            get {
                return this.onlineIndField;
            }
            set {
                this.onlineIndField = value;
            }
        }
        
        /// <remarks/>
        public string firstLetterOfMajor {
            get {
                return this.firstLetterOfMajorField;
            }
            set {
                this.firstLetterOfMajorField = value;
            }
        }
        
        /// <remarks/>
        public string result {
            get {
                return this.resultField;
            }
            set {
                this.resultField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void GetExactCompletedEventHandler(object sender, GetExactCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetExactCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetExactCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ProgramsAndDegreesEntry[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ProgramsAndDegreesEntry[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void GetStartsWithCompletedEventHandler(object sender, GetStartsWithCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetStartsWithCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetStartsWithCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ProgramsAndDegreesEntry[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ProgramsAndDegreesEntry[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void GetFirstLettersMajorCompletedEventHandler(object sender, GetFirstLettersMajorCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetFirstLettersMajorCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetFirstLettersMajorCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ProgramsAndDegreesEntry[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ProgramsAndDegreesEntry[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void SearchCompletedEventHandler(object sender, SearchCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SearchCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SearchCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ProgramsAndDegreesEntry[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ProgramsAndDegreesEntry[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void GetDegreesCompletedEventHandler(object sender, GetDegreesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetDegreesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetDegreesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ProgramsAndDegreesEntry[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ProgramsAndDegreesEntry[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void GetAllProgramsCompletedEventHandler(object sender, GetAllProgramsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetAllProgramsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetAllProgramsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ProgramsAndDegreesEntry[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ProgramsAndDegreesEntry[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void GetTagsCompletedEventHandler(object sender, GetTagsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetTagsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetTagsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ProgramsAndDegreesEntry[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ProgramsAndDegreesEntry[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void GetAllCollegesCompletedEventHandler(object sender, GetAllCollegesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetAllCollegesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetAllCollegesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ProgramsAndDegreesEntry[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ProgramsAndDegreesEntry[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591