using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Author:Nansy Salem
//Date: 30/4/2021
//NOTE: ****Validations for character lengths as per database specifications has been specified
//in the field properties of the form***
namespace TravelExperts
{
    /// <summary>
    /// a repository of validation methods
    /// </summary>
    public static class Validator
    {

        private static string title = "Entry Error";

        /// <summary>
        /// The title that will appear in dialog boxes.
        /// </summary>
        public static string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        /// <summary>
        /// validates if textbox has something in it
        /// </summary>
        /// <param name="tb">text box to validate</param>
        /// <param name="name">name for error message</param>
        /// <returns>true if valid, and false if not</returns>
        public static bool IsPresent(TextBox tb, string name)
        {
            bool isValid = true; // "innocent until proven guilty"
            if (tb.Text == "") // bad
            {
                isValid = false;
                MessageBox.Show(name + " is required", "Input error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                tb.Focus();
            }        
            return isValid;
        }

        public static bool IsPresent(RichTextBox tb, string name)
        {
            bool isValid = true; // "innocent until proven guilty"
            if (tb.Text == "") // bad
            {
                isValid = false;
                MessageBox.Show(name + " is required", "Input error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                tb.Focus();
            }
            return isValid;
        }

        /// <summary>
        /// Checks whether the user entered data into a text box.
        /// </summary>
        /// <param name="textBox">The text box control to be validated.</param>
        /// <returns>True if the user has entered data.</returns>
        public static bool IsPresentCBO(Control control)
        {
            if (control.GetType().ToString() == "System.Windows.Forms.TextBox")
            {
                TextBox textBox = (TextBox)control;
                if (textBox.Text == "")
                {
                    MessageBox.Show(textBox.Tag + " is a required field.", Title);
                    textBox.Focus();
                    return false;
                }
            }
            else if (control.GetType().ToString() == "System.Windows.Forms.ComboBox")
            {
                ComboBox comboBox = (ComboBox)control;
                if (comboBox.SelectedIndex == -1)
                {
                    MessageBox.Show(comboBox.Tag + " is a required field.", "Entry Error");
                    comboBox.Focus();
                    return false;
                }
            }
            return true;
        }


            /// <summary>
            /// validates if textbox contains non-negative decimal
            /// </summary>
            /// <param name="tb">text box to validate</param>
            /// <param name="name">name for error message</param>
            /// <returns>true if valid, and false if not</returns>
            public static bool IsNonNegativeDecimal(TextBox tb, string name)
        {
            bool isValid = true; // "innocent until proven guilty"
            decimal value;
            if (!Decimal.TryParse(tb.Text, out value)) //not an int
            {
                isValid = false;
                MessageBox.Show(name + " has to be a number", "Input error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                tb.SelectAll();
                tb.Focus();
            }
            else if (value < 0)// cannot be negative
            {
                isValid = false;
                MessageBox.Show(name + " has to positive or zero", "Input error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                tb.SelectAll();
                tb.Focus();
            }
            return isValid;
        }

        /// <summary>
        /// Checks if a chosen date is in the past. Packages should only be added if their date 
        /// is to occur in the future
        /// </summary>
        /// <param name="dtp"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        internal static bool IsValidDate(DateTimePicker dtp, string name)
        {
            bool isValid = true; // "innocent until proven guilty"
            if (dtp.Value <= DateTime.Today) //not a valid date
            {
                isValid = false;
                MessageBox.Show(name + " must be a future date", "Input error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                dtp.Focus();
            }
            return isValid;
        }

        /// <summary>
        /// Checks if a package duration is correct. End date should be after start date 
        /// </summary>
        /// <param name="dtp1"> Package start date</param>
        ///  <param name="dtp2"> Package End date</param>
        /// <returns></returns>
        internal static bool IsValidDuration(DateTimePicker dtp1, DateTimePicker dtp2)
        {
            bool isValid = true; // "innocent until proven guilty"
            if (dtp2.Value <= dtp1.Value) //not a valid duration
            {
                isValid = false;
                MessageBox.Show(" End date must be after Start date", "Input error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                dtp2.Focus();
            }
            return isValid;
        }
        internal static bool IsValidPricing(TextBox Base, TextBox Comm)
        {
            bool isValid = true; // "innocent until proven guilty"
            decimal base_Price;
            Decimal.TryParse(Base.Text, out base_Price);
            decimal comm_Price;
            Decimal.TryParse(Comm.Text, out comm_Price);
            if (base_Price <= comm_Price) //invalid pricing as it violates business rules
            {
                isValid = false;
                MessageBox.Show(" Commission must be less than base price", "Input error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                Comm.Focus();
            }
            return isValid;
        }



    } // class
}// namespace
