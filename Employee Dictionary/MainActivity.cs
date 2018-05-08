using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;

namespace Employee_Dictionary
{
    [Activity(Label = "Employee_Dictionary", MainLauncher = true)]
    public class MainActivity : Activity
    {
        EditText txtUsername;
        EditText txtPassword;
        Button btnLogin;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            txtUsername = FindViewById<EditText>(Resource.Id.txtmnUsername);
            txtPassword = FindViewById<EditText>(Resource.Id.txtmnPassword);
            btnLogin = FindViewById<Button>(Resource.Id.btnmnLogin);

            btnLogin.Click += BtnLogin_Click;

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "employeeAdmin" && txtPassword.Text == "318@ppUser")
            {
                Intent nextIntent = new Intent(this, typeof(AddEmployeeActivity));
                StartActivity(nextIntent);
            }
        }
    }
}

