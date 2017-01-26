﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ALPAIdentityServer.AIROCore
{
    [Table("vwPersons")]
    public class vwPersons
    {
        public int ID { get; set; }       
        public string NameWCompany { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string FirstLast { get; set; }
        public string CompanyID { get; set; }
        public string linkedRecordName { get; set; }
        public string CompanyName { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }
        public string Title { get; set; }
        public string PreferredAddress { get; set; }
        public string PreferredBillingAddress { get; set; }
        public string PreferredShippingAddress { get; set; }
        public Nullable<int> AddressID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string ZipCode5Numeric { get; set; }
        public string Country { get; set; }
        public string CountryCodeID { get; set; }
        public string PhoneID { get; set; }
        public string PhoneCountryCode { get; set; }
        public string PhoneAreaCode { get; set; }
        public string Phone { get; set; }
        public string PhoneExtension { get; set; }
        public string FaxID { get; set; }
        public string FaxCountryCode { get; set; }
        public string FaxAreaCode { get; set; }
        public string FaxPhone { get; set; }
        public string CellPhoneID { get; set; }
        public string CellCountryCode { get; set; }
        public string CellAreaCode { get; set; }
        public string CellPhone { get; set; }
        public string PagerPhoneID { get; set; }
        public string PagerCountryCode { get; set; }
        public string PagerAreaCode { get; set; }
        public string PagerPhone { get; set; }
        public string Email { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string BillingAddressID { get; set; }
        public string BillingAddressLine1 { get; set; }
        public string BillingAddressLine2 { get; set; }
        public string BillingAddressLine3 { get; set; }
        public string BillingAddressLine4 { get; set; }
        public string BillingCity { get; set; }
        public string BillingCounty { get; set; }
        public string BillingState { get; set; }
        public string BillingZipCode { get; set; }
        public string BillingCountryCodeID { get; set; }
        public string BillingCountry { get; set; }
        public string HomeAddressID { get; set; }
        public string HomeAddressLine1 { get; set; }
        public string HomeAddressLine2 { get; set; }
        public string HomeAddressLine3 { get; set; }
        public string HomeAddressLine4 { get; set; }
        public string HomeCity { get; set; }
        public string HomeCounty { get; set; }
        public string HomeState { get; set; }
        public string HomeZipCode { get; set; }
        public string HomeCountry { get; set; }
        public string HomePhoneID { get; set; }
        public string HomeCountryCodeID { get; set; }
        public string HomeCountryCode { get; set; }
        public string HomeAreaCode { get; set; }
        public string HomePhone { get; set; }
        public string POBoxAddressID { get; set; }
        public string POBox { get; set; }
        public string POBoxLine2 { get; set; }
        public string POBoxLine3 { get; set; }
        public string POBoxLine4 { get; set; }
        public string POBoxCity { get; set; }
        public string POBoxCounty { get; set; }
        public string POBoxState { get; set; }
        public string POBoxZipCode { get; set; }
        public string POBoxCountryCodeID { get; set; }
        public string POBoxCountry { get; set; }
        public string SocialSecurity { get; set; }
        public string OrganizationID { get; set; }
        public string MainAccountManager { get; set; }
        public string MainAccountManagerName { get; set; }
        public string Ranking { get; set; }
        public string ReferredBy { get; set; }
        public string ReferralType { get; set; }
        public string WebSite { get; set; }
        public DateTime Birthday { get; set; }
        public string Supervisor { get; set; }
        public string AssistantsName { get; set; }
        public string AssistantsPhoneID { get; set; }
        public string AssistantsCountryCode { get; set; }
        public string AssistantsAreaCode { get; set; }
        public string AssistantsPhone { get; set; }
        public string AssistantsExtension { get; set; }
        public string Nickname { get; set; }
        public int Gender { get; set; }
        public string SpouseName { get; set; }
        public string Kids { get; set; }
        public string ImportantDate1 { get; set; }
        public string ImportantDescription1 { get; set; }
        public string ImportantDate2 { get; set; }
        public string ImportantDescription2 { get; set; }
        public string ImportantDate3 { get; set; }
        public string ImportantDescription3 { get; set; }
        public string Atmosphere { get; set; }
        public string MailCode { get; set; }
        public string CRRT { get; set; }
        public string USCongress { get; set; }
        public string StateSenate { get; set; }
        public string StateHouse { get; set; }
        public string CountyDistrict { get; set; }
        public string NextContactDate { get; set; }
        public string MailExclude { get; set; }
        public string FaxExclude { get; set; }
        public string EmailExclude { get; set; }
        public string DirExclude { get; set; }
        public string PrefCommMethodID { get; set; }
        public string ContactManagerID { get; set; }
        public string VerifyStatus { get; set; }
        public string FunctionalTitle { get; set; }
        public string ContactRank { get; set; }
        public string DirRank { get; set; }
        public string PrimaryFunctionID { get; set; }
        public string PrimaryFunction { get; set; }
        public string MemberTypeID { get; set; }
        public string MemberType { get; set; }
        public string JoinDate { get; set; }
        public string DuesPaidThru { get; set; }
        public string LastDuesPaymentDate { get; set; }
        public string LastDuesAmount { get; set; }
        public string TerminationDate { get; set; }
        public string Status { get; set; }
        public string CompanyMemberTypeID { get; set; }
        public string CoMemberType { get; set; }
        public string CompanyMemberType { get; set; }
        public DateTime CompanyJoinDate { get; set; }
        public DateTime CompanyDuesPaidThru { get; set; }
        public string CompanyLastDuesPaymentDate { get; set; }
        public string CompanyLastDuesAmount { get; set; }
        public string CompanyTerminationDate { get; set; }
        public string OldID { get; set; }
        public string OldCompanyID { get; set; }
        public string GLOrderLevelID { get; set; }
        public string GLPaymentLevelID { get; set; }
        public string CreditStatusID { get; set; }
        public string CreditLimit { get; set; }
        public string BillingTerms { get; set; }
        public string APVendorID { get; set; }
        public string PreferredCurrencyTypeID { get; set; }
        public string Directions { get; set; }
        public string Comments { get; set; }
        public string WhoCreated { get; set; }
        public string WhoUpdated { get; set; }
        public string DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string LastDuesAmountCurrencyTypeID { get; set; }
        public string CreditLimitCurrencyTypeID { get; set; }
        public string CompanyLastDuesAmountCurrencyTypeID { get; set; }
        public string Photo { get; set; }
        public string ExternalAccountProfileURL { get; set; }
        public string IgnoreSocialNetworkCompanyDifferences { get; set; }
        public string IgnoreSocialNetworkTitleDifferences { get; set; }
        public string BillingBadAddress { get; set; }
        public string HomeBadAddress { get; set; }
        public string POBoxBadAddress { get; set; }
        public string BusinessBadAddress { get; set; }
        public string CESScore { get; set; }
        public string IsGroupAdmin { get; set; }
        public string SpaceLinkHandle { get; set; }
        public string StatusName { get; set; }
        public string FormattedAddress { get; set; }
        public string FormattedPhone { get; set; }
        public string IsSystem { get; set; }
        public string OrderTotal { get; set; }
        public string BalanceTotal { get; set; }
        public string PaymentTotal { get; set; }
        public string RootCompanyMemberType { get; set; }
        public string ALPAID__c { get; set; }
    }
}