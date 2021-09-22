using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressBookTests
{
    [Table( Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private IList<IWebElement> cellSurename;
        private IList<IWebElement> cellName;
        private string allPhones;
        private string allEmails;

        public ContactData()
        {
        }
        public ContactData(string firstname)
        {
            this.Firstname = firstname;
        }

        public ContactData(string firstname, string lastname)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;                   
        }

        public ContactData(IList<IWebElement> cellSurename, IList<IWebElement> cellName)
        {
            this.cellSurename = cellSurename;
            this.cellName = cellName;
        }

        public bool Equals(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname &&
                    Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public override string ToString()
        {
            return Firstname + Lastname;
        }

        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            
            if (Lastname.Equals(other.Firstname))
            {
                return Firstname.CompareTo(other.Firstname);
            }
            else
            {
                return Lastname.CompareTo(other.Lastname);
            }
        }

        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }

        [Column(Name = "firstname")]
        public string Firstname { get; set; }

        [Column(Name = "lastname")]
        public string Lastname { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Email1 { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return (string)allEmails;
                }
                else
                {
                    return (CleanUp(Email1) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string AllPhones { 
            get 
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }

            set 
            {
                allPhones = value;
            }
        }

        public string AllContactData
        {
            get
            {
                string address = String.IsNullOrEmpty(Address) ? "" : "\r\n" + Address;
                string homePhone = String.IsNullOrEmpty(HomePhone) ? "" : "\r\nH: " + HomePhone;
                string mobilePhone = String.IsNullOrEmpty(MobilePhone) ? "" : "\r\nM: " + MobilePhone;
                string workPhone = String.IsNullOrEmpty(WorkPhone) ? "" : "\r\nW: " + WorkPhone;
                string email = String.IsNullOrEmpty(Email1) ? "" : "\r\n" + Email1;
                string email2 = String.IsNullOrEmpty(Email2) ? "" : "\r\n" + Email2;
                string email3 = String.IsNullOrEmpty(Email3) ? "" : "\r\n" + Email3;

                string allPhones = !String.IsNullOrEmpty(workPhone) || !String.IsNullOrEmpty(homePhone) || !String.IsNullOrEmpty(mobilePhone) ? "\r\n" : "";
                string allEmails = !String.IsNullOrEmpty(email) || !String.IsNullOrEmpty(email2) || !String.IsNullOrEmpty(email3) ? "\r\n" : "";

                return $"{Firstname} {Lastname}{address}{allPhones}{homePhone}{mobilePhone}{workPhone}{allEmails}{email}{email2}{email3}";
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ )(-]", "") + "\r\n";
        }
    }
}
