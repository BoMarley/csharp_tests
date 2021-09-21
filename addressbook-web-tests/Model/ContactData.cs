using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressBookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private IList<IWebElement> cellSurename;
        private IList<IWebElement> cellName;
        private string allPhones;
        private string allEmails;
        private string allDataFromEditForm;

        public ContactData()
        {
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

        public ContactData(string allContactData)
        {
            AllContactData = allContactData;
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

        public string Firstname { get; set; }
        
        public string Lastname { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Email1 { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string AllEmailsFromTable { get; set; }

        public string AllPhonesFromTable { get; set; }

        public string AllContactData { get; set; }

        public string AllDataFromEditForm
        {
            get
            {
                if (Firstname != "")
                {
                    Firstname = Firstname;
                }
                else
                {
                    Firstname = "";
                }

                if (Lastname != "")
                {
                    Lastname = " " + Lastname;
                }
                else
                {
                    Lastname = "";
                }

                if (Address != "")
                {
                    Address = "\r\n" + Address;
                }
                else
                {
                    Address = "";
                }

                if (HomePhone != "")
                {
                    HomePhone = "\r\nH: " + HomePhone;
                }
                else
                {
                    HomePhone = "";
                }

                if (MobilePhone != "")
                {
                    MobilePhone = "\r\nM: " + MobilePhone;
                }
                else
                {
                    MobilePhone = "";
                }

                if (WorkPhone != "")
                {
                    WorkPhone = "\r\nW: " + WorkPhone;
                }
                else
                {
                    WorkPhone = "";
                }

                AllPhonesFromTable = HomePhone + MobilePhone + WorkPhone;

                if (AllPhonesFromTable != "")
                {
                    AllPhonesFromTable = "\r\n" + AllPhonesFromTable;
                }
                else
                {
                    AllPhonesFromTable = "";
                }

                if (Email1 != "")
                {
                    Email1 = "\r\n" + Email1;
                }
                else
                {
                    Email1 = "";
                }

                if (Email2 != "")
                {
                    Email2 = "\r\n" + Email2;
                }
                else
                {
                    Email2 = "";
                }

                if (Email3 != "")
                {
                    Email3 = "\r\n" + Email3;
                }
                else
                {
                    Email3 = "";
                }

                AllEmailsFromTable = Email1 + Email2 + Email3;

                if (AllEmailsFromTable != "")
                {
                    AllEmailsFromTable = "\r\n" + AllEmailsFromTable;
                }
                else
                {
                    AllEmailsFromTable = "";
                }

                if (allDataFromEditForm != null)
                {
                    return allDataFromEditForm;
                }
                else
                {
                    return allDataFromEditForm = Firstname + Lastname + Address + AllPhonesFromTable + AllEmailsFromTable;
                }                          
            }

            set
            {
                allDataFromEditForm = value;
            }
        }

        public string AllEmails
        {
            get {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return "";
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
