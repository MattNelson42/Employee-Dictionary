using System;
using System.Collections.Generic;
using System.IO;
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
    [Activity(Label = "HomeActivity")]
    public class AddEmployeeActivity : Activity
    {
        EditText txtFirstName;
        EditText txtLastName;
        EditText txtJobTitle;
        EditText txtOfficeNum;
        EditText txtMobileNum;
        EditText txtEmail;
        EditText txtManagerName;
        EditText txtManagerPhone;
        ListView tblEmployee;
        Button btnAdd;

        public string filePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "EmployeeList.db3");
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            txtFirstName = FindViewById<EditText>(Resource.Id.txtmnFirstName);
            txtLastName = FindViewById<EditText>(Resource.Id.txtmnLastName);
            txtJobTitle = FindViewById<EditText>(Resource.Id.txtmnJobTitle);
            txtOfficeNum = FindViewById<EditText>(Resource.Id.txtmnOfficeNum);
            txtMobileNum = FindViewById<EditText>(Resource.Id.txtmnMobileNum);
            txtEmail = FindViewById<EditText>(Resource.Id.txtmnEmail);
            txtManagerName = FindViewById<EditText>(Resource.Id.txtmnManagerName);
            txtManagerPhone = FindViewById<EditText>(Resource.Id.txtmnManagerPhone);
            tblEmployee = FindViewById<ListView>(Resource.Id.tblmnEmployee);
            btnAdd = FindViewById<Button>(Resource.Id.btnmnAdd);

            btnAdd.Click += BtnAdd_Click;

            //string filePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "EmployeeList.db3");

            try
            {
                var db = new SQLiteConnection(filePath);
                db.CreateTable<Employee>();
            }
            catch (IOException ex)
            {
                var reason = string.Format("Failed to create table - reason {0}", ex.Message);
                Toast.MakeText(this, reason, ToastLength.Long).Show();
            }

            PopulateListView();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string alertTitle, alertMessage;
            if (!string.IsNullOrEmpty(txtFirstName.Text))
            {
                var newBook = new Employee { FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text, JobTitle = txtJobTitle.Text, OfficeNum = txtOfficeNum.Text,
                    MobileNum = txtMobileNum.Text, Email = txtEmail.Text, ManagerName = txtManagerName.Text, 
                    ManagerPhone = txtManagerPhone.Text
                };

                var db = new SQLiteConnection(filePath);
                db.Insert(newBook);

                alertTitle = "Success";
                alertMessage = string.Format("Employee added succesfully!");

            }
            else
            {
                alertTitle = "Failed";
                alertMessage = "Enter a valid Employee";
            }

            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle(alertTitle);
            alert.SetMessage(alertMessage);
            alert.SetPositiveButton("OK", (senderAlert, args) =>
            {
                Toast.MakeText(this, "Continue!", ToastLength.Short).Show();
            });
            alert.SetNegativeButton("Cancel", (senderAlert, args) =>
            {
                Toast.MakeText(this, "Cancelled!", ToastLength.Short).Show();
            });
            Dialog dialog = alert.Create();
            dialog.Show();

            PopulateListView();
        }
        private void PopulateListView()
        {
            var db = new SQLiteConnection(filePath);
            var employeeList = db.Table<Employee>();

            List<string> employeeInfo = new List<string>();

            foreach (var employee in employeeList)
            {
                employeeInfo.Add(employee.FirstName);
            }

            tblEmployee.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, employeeInfo.ToArray());
        }
    }
}