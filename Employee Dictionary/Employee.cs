using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace Employee_Dictionary
{
    class Employee
    {
        [PrimaryKey, AutoIncrement]
        public int EmpID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string OfficeNum { get; set; }
        public string MobileNum { get; set; }
        public string Email { get; set; }
        public string ManagerName { get; set; }
        public string ManagerPhone { get; set; }
    }
}