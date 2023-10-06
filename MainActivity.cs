using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Xml;
using static Android.Resource;

namespace Calculator
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        // הגדרת כפתורים ומשתנים
        TextView txt1;
        Button btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btnac, btnmulti, btnplus, btndiv, btnminus, btndot, btnequal, btntan, btncos, btnsin;
        string current_num = "", op = "";
        double num1 = 0, num2 = 0, radians = 0, degrees = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // יוצרים את כל הכפתורים
            txt1 = FindViewById<TextView>(Resource.Id.txt1);
            btn0 = FindViewById<Button>(Resource.Id.btn0);
            btn1 = FindViewById<Button>(Resource.Id.btn1);
            btn2 = FindViewById<Button>(Resource.Id.btn2);
            btn3 = FindViewById<Button>(Resource.Id.btn3);
            btn4 = FindViewById<Button>(Resource.Id.btn4);
            btn5 = FindViewById<Button>(Resource.Id.btn5);
            btn6 = FindViewById<Button>(Resource.Id.btn6);
            btn7 = FindViewById<Button>(Resource.Id.btn7);
            btn8 = FindViewById<Button>(Resource.Id.btn8);
            btn9 = FindViewById<Button>(Resource.Id.btn9);
            btnac = FindViewById<Button>(Resource.Id.btnac);
            btnmulti = FindViewById<Button>(Resource.Id.btnmulti);
            btnplus = FindViewById<Button>(Resource.Id.btnplus);
            btnminus = FindViewById<Button>(Resource.Id.btnminus);
            btndiv = FindViewById<Button>(Resource.Id.btndiv);
            btndot = FindViewById<Button>(Resource.Id.btndot);
            btnequal = FindViewById<Button>(Resource.Id.btnequal);
            btntan = FindViewById<Button>(Resource.Id.btntan);
            btnsin = FindViewById<Button>(Resource.Id.btnsin);
            btncos = FindViewById<Button>(Resource.Id.btncos);

            // קריאה לכל הכפתורים כאשר הם נלחצים
            btn0.Click += OnbuttonClicked;
            btn1.Click += OnbuttonClicked;
            btn2.Click += OnbuttonClicked;
            btn3.Click += OnbuttonClicked;
            btn4.Click += OnbuttonClicked;
            btn5.Click += OnbuttonClicked;
            btn6.Click += OnbuttonClicked;
            btn7.Click += OnbuttonClicked;
            btn8.Click += OnbuttonClicked;
            btn9.Click += OnbuttonClicked;
            btnac.Click += OnbuttonClicked;
            btnplus.Click += OnplusClicked;
            btnminus.Click += OnminusClicked;
            btnmulti.Click += OnmultiplicationClicked;
            btndiv.Click += OndivisonClicked;
            btndot.Click += OndotClicked;
            btnsin.Click += OnsintClicked;
            btncos.Click += OncostClicked;
            btntan.Click += OntantClicked;
            btnequal.Click += OnequalClicked;

        }

        // פונקציה לחיצה על הכפתורים 0-9 ומחיקה
        public void OnbuttonClicked(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;

            if (btnac == btn)
            {
                txt1.Text = "0";
                current_num = "";
            }

            if (btn0 == btn) current_num += 0;
            if (btn1 == btn) current_num += 1;
            if (btn2 == btn) current_num += 2;
            if (btn3 == btn) current_num += 3;
            if (btn4 == btn) current_num += 4;
            if (btn5 == btn) current_num += 5;
            if (btn6 == btn) current_num += 6;
            if (btn7 == btn) current_num += 7;
            if (btn8 == btn) current_num += 8;
            if (btn9 == btn) current_num += 9;
            if (btnac != btn) txt1.Text = current_num;

        }

        // פונקציה לחיצה על כפתור שווה
        public void OnequalClicked(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            if (op == "+" || op == "-" || op == "÷" || op == "*")
            {
                num2 = Convert.ToDouble(current_num);
                if (op == "+") txt1.Text = Convert.ToString(num1 + num2);
                if (op == "-") txt1.Text = Convert.ToString(num1 - num2);
                if (op == "÷") txt1.Text = Convert.ToString(num1 / num2);
                if (op == "*") txt1.Text = Convert.ToString(num1 * num2);
                current_num = txt1.Text;
            }

            if (op == "sin" || op == "cos" || op == "tan")
            {
                current_num = "";
                current_num = txt1.Text.Remove(0, 3);
                num1 = Convert.ToDouble(current_num);
                if (op == "sin") radians = Math.Sin(num1);
                if (op == "cos") radians = Math.Cos(num1);
                if (op == "tan") radians = Math.Tan(num1);
                degrees = radians * 180 / Math.PI;
                degrees = Math.Round(degrees, 2);
                current_num = Convert.ToString(degrees);
                txt1.Text = current_num;
            }
        }

        // פונקציה לחיצה על כפתור פלוס
        public void OnplusClicked(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            num1 = Convert.ToDouble(current_num);
            current_num = "";
            op = "+";
            txt1.Text = "+";
        }

        // פונקציה לחיצה על כפתור מינוס
        public void OnminusClicked(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            num1 = Convert.ToDouble(current_num);
            current_num = "";
            op = "-";
            txt1.Text = "-";
        }

        // פונקציה לחיצה על כפתור חלוקה
        public void OndivisonClicked(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            num1 = Convert.ToDouble(current_num);
            current_num = "";
            op = "÷";
            txt1.Text = "÷";
        }

        // פונקציה לחיצה על כפתור כפל
        public void OnmultiplicationClicked(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            num1 = Convert.ToDouble(current_num);
            current_num = "";
            op = "*";
            txt1.Text = "x";
        }

        // פונקציה לחיצה על כפתור נקודה
        public void OndotClicked(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            current_num = txt1.Text + ".";
            txt1.Text = current_num;
        }
        // פונקציה לחיצה על כפתור סינוס
        public void OnsintClicked(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            txt1.Text = "sin";
            current_num = "sin";
            op = "sin";
        }

        // פונקציה לחיצה על כפתור קוסינוס
        public void OncostClicked(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            txt1.Text = "cos";
            current_num = "cos";
            op = "cos";
        }

        // פונקציה לחיצה על כפתור טאנגס
        public void OntantClicked(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            txt1.Text = "tan";
            current_num = "tan";
            op = "tan";
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


    }
}