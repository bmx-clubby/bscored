using bScoredDatabase.Models;
using System.Data.Common;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using System.Collections.Generic;
using System;

namespace bScoredDatabase
{
    public static class MemberQueries
    {

        public static List<Member> FindMemberByNumber(this DbConnection db, string membership_no, DbTransaction transaction = null)
        {
            var results = db.Query<Member>($"select * from OSM_Membership where Membership_No = @Num", new { Num = membership_no }, transaction: transaction);
            return results.ToList();
        }

        public static List<Member> FindMemberByFirstNameLastNameDob(this DbConnection db, string firstName, string lastName, DateTime dob, DbTransaction transaction = null)
        {
            var results = db.Query<Member>(@"
SELECT * 
FROM OSM_Membership 
WHERE 
        First_Name = @firstName
AND     Last_Name = @lastName
AND     BirthDate = @dob", new { firstName, lastName, dob }, transaction: transaction);
            return results.ToList();
        }

        public static int Insert(this DbConnection db, Member member, DbTransaction transaction = null)
        {
            return db.Execute(@"
    INSERT INTO OSM_Membership (Membership_No, First_Name, Last_Name, BirthDate, Gender, Emergency_Contact_Person, Emergency_Contact_Number, Financial_Date, Status, Member_Type, Club_Code, Club, Race_Status) 
    VALUES (@Membership_No, @First_Name, @Last_Name, @BirthDate, @Gender, @Emergency_Contact_Person, @Emergency_Contact_Number, @Financial_Date, @Status, @Member_Type, @Club_Code, @Club, @Race_Status)"
            , member, transaction: transaction);
        }

        public static int ChangeMembershipNumber(this DbConnection db, string currentMembershipNo, string newMembershipNo, DbTransaction transaction = null)
        {
            return db.Execute(@"       
            UPDATE OSM_Membership Set Membership_No = @newMembershipNo where Membership_No=@currentMembershipNo;
            UPDATE _tMembers Set Membership_No = @newMembershipNo where Membership_No=@currentMembershipNo;
            UPDATE Results Set Membership_No = @newMembershipNo where Membership_No=@currentMembershipNo;
            UPDATE Riders Set Membership_No = @newMembershipNo where Membership_No=@currentMembershipNo;
            UPDATE Series_Riders Set Membership_No = @newMembershipNo where Membership_No=@currentMembershipNo;
            UPDATE Mylaps_Pasing Set Membership_No = @newMembershipNo where Membership_No=@currentMembershipNo;
            UPDATE OSM_Transponders Set Membership_No = @newMembershipNo where Membership_No=@currentMembershipNo;"
            , new { currentMembershipNo, newMembershipNo }, transaction: transaction);

        }

        public static int UpdateMemberFromQRCode(this DbConnection db, Member member, string membershipNo, DbTransaction transaction = null)
        {
            var sql = @"
UPDATE OSM_Membership
        SET 
                    BirthDate  = @BirthDate,
                    First_Name = @First_Name,
                    Last_Name = @Last_Name,
                    Club = @Club,
                    Club_Code = @Club_Code,
                    Emergency_Contact_Person  = @Emergency_Contact_Person ,
                    Emergency_Contact_Number = @Emergency_Contact_Number,
                    Member_Type = @Member_Type,
                    Financial_date  = @Financial_date ,
                    Status = @Status ,
                    Race_Status = @Race_Status 
WHERE 
   Membership_No = @membershipNo";


            var p = new DynamicParameters(member);
            p.Add("membershipNo", membershipNo);

            return db.Execute(sql, p, transaction);
        }

        public static int InsertMemberFromQRCode(this DbConnection db, Member member, DbTransaction transaction = null)
        {
            var sql = @"
    INSERT INTO OSM_Membership (
                    Membership_No ,
                    BirthDate ,
                    Club ,
                    Club_Code ,
                    First_Name,
                    Last_Name,
                    Gender ,
                    Emergency_Contact_Person ,
                    Emergency_Contact_Number,
                    Member_Type,
                    Financial_date ,
                    Status,
                    Race_Status
) 
        VALUES (
                    @Membership_No ,
                    @BirthDate ,
                    @Club ,
                    @Club_Code ,
                    @First_Name,
                    @Last_Name,
                    @Gender ,
                    @Emergency_Contact_Person ,
                    @Emergency_Contact_Number,
                    @Member_Type,
                    @Financial_date ,
                    @Status,
                    @Race_Status
)
";

            return db.Execute(sql, member, transaction);
        }

        public static List<Member> FindMemberByBMXANo(this DbConnection db, string membership_no, DbTransaction transaction = null)
        {
            var results = db.Query<Member>($"select * from OSM_Membership where BMXA_No = @Num", new { Num = membership_no }, transaction: transaction);
            return results.ToList();
        }

        public static int UpdateMemberFromUserForm(this DbConnection db, Member member, string membershipNo, DbTransaction transaction = null)
        {
            var sql = @"
UPDATE OSM_Membership
        SET 
                    Club = @Club,
                    Club_Code = @Club_Code,
                    Emergency_Contact_Person  = @Emergency_Contact_Person ,
                    Emergency_Contact_Number = @Emergency_Contact_Number,
                    Gender = @Gender,
                    Member_Type = @Member_Type,
                    Financial_date  = @Financial_date ,
                    Status = @Status ,
                    Race_Status = @Race_Status 
WHERE 
   Membership_No = @membershipNo";


            var p = new DynamicParameters(member);
            p.Add("membershipNo", membershipNo);

            return db.Execute(sql, p, transaction);
        }

    }
}