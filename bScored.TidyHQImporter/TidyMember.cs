
using CsvHelper.Configuration.Attributes;
using System;

namespace TidyHQMemberImporter
{
    public class TidyMember
    {
       // [Name("Contact")]
       // public string Contact { get; set; } //Not relavent just first name and last name joined together

        [Name("ID Number")]
        public string IDNumber { get; set; } //Insert or Update.. Unique for contact , but same contact can have multiple memberships (so multiple lines in CSV)

        //[Name("Email")]
        //public string Email { get; set; } // Not in bscored

        //[Name("Phone")]
        //public string Phone { get; set; } //Not in bscored

        //[Name("Mobile phone")]
        //public string MobilePhone { get; set; } //Not in bscored

        //[Name("Shared")]
        //public string Shared { get; set; } // indicates this is a shared contact in tidy HQ

        [Name("Groups")]
        public string Groups { get; set; } //Contains the club name, not sure if this will contain multiples club?

        //[Name("Company")]
        //public string Company { get; set; }  //Not in bscored

        [Name("First Name")]
        public string FirstName { get; set; } //Insert or Update

        [Name("Last Name")]
        public string LastName { get; set; } //Insert or Update

        //[Name("Nickname")]
        //public string Nickname { get; set; } //Not in bscored

        [Name("Gender")]
        public string Gender { get; set; } //Insert or Update

        [Name("Date of Birth")]
        public string DateOfBirth { get; set; }  //Insert or Update

        //[Name("Address (Street)")]
        //public string AddressStreet { get; set; }   //Not in bscored

        //[Name("Address (City)")]
        //public string AddressCity { get; set; }  //Not in bscored

        //[Name("Address (State)")]
        //public string AddressState { get; set; }  //Not in bscored

        //[Name("Address (Postcode)")]
        //public string AddressPostcode { get; set; }  //Not in bscored

        //[Name("Address (Country)")]
        //public string AddressCountry { get; set; }  //Not in bscored

        //[Name("Occupation")]
        //public string Occupation { get; set; }  //Not in bscored

        [Name("Emergency Contact")]
        public string EmergencyContact { get; set; }   //Insert or Update Emergency contact name

        [Name("Emergency Contact Number")]
        public string EmergencyContactNumber { get; set; }  //Insert or Update 

        //[Name("Member Since")]
        //public string MemberSince { get; set; }  //Not in bscored

        [Name("BMXA Member Number")]
        public string BMXAMemberNumber { get; set; } // In bscored, will ignore for now and just use AusCycling Number

        //[Name("MTBA Member Number")]
        //public string MTBAMemberNumber { get; set; }  //Not in bscored

        //[Name("Medical Conditions")]
        //public string MedicalConditions { get; set; }  //Not in bscored

        [Name("Transponder ID #1")]
        public string TransponderID1 { get; set; }  //Assume 20inch

        [Name("Transponder ID #2")]
        public string TransponderID2 { get; set; }

        [Name("Transponder ID #3")]
        public string TransponderID3 { get; set; }

        [Name("Membership Level")]
        public string MembershipLevel { get; set; }

        [Name("Membership Status")]
        public string MembershipStatus { get; set; }

        //[Name("Membership ID Reference")]
        //public string MembershipIDReference { get; set; }

        [Name("Membership Start Date")]
        public string MembershipStartDate { get; set; }

        [Name("Membership End Date")]
        public string MembershipEndDate { get; set; }

        //[Name("Membership Auto-renew Status")]
        //public string MembershipAutoRenewStatus { get; set; }

        //[Name("Subscription ID")]
        //public string SubscriptionID { get; set; }

        //[Name("Subscription Status")]
        //public string SubscriptionStatus { get; set; }

        //[Name("Subscription Start Date")]
        //public string SubscriptionStartDate { get; set; }

        //[Name("Subscription End Date")]
        //public string SubscriptionEndDate { get; set; }

        //[Name("Subscription Variations")]
        //public string SubscriptionVariations { get; set; }

        /* Proof of Age Suspension */

        [Name("Suspension Start Date")]
        public string SuspensionStartDate { get; set; }

        [Name("Suspension End Date")]
        public string SuspensionEndDate { get; set; }
    }

}
