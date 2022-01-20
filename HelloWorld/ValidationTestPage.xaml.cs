using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

namespace HelloWorld
{
    public partial class ValidationTestPage : Page
    {
        public ValidationTestPage()
        {
            this.InitializeComponent();
            this.DataContext = new Customer("J", "Smith", 12345);
        }
    }

    public class Customer
    {
        // Private data members.
        private int m_IdNumber;
        private string m_FirstName;
        private string m_LastName;

        public Customer(string firstName, string lastName, int id)
        {
            this.IdNumber = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        // Public properties.
        [Display(Name = "ID Number", Description = "Enter an integer between 0 and 99999.")]
        [Range(0, 99999)]
        public int IdNumber
        {
            get { return m_IdNumber; }
            set
            {
                Validator.ValidateProperty(value,
                    new ValidationContext(this, null, null) { MemberName = "IdNumber" });
                m_IdNumber = value;
            }
        }

        [Display(Name = "Name", Description = "First Name + Last Name.")]
        [Required(ErrorMessage = "First Name is required.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Numbers and special characters are not allowed in the name.")]
        public string FirstName
        {
            get { return m_FirstName; }

            set
            {
                Validator.ValidateProperty(value,
                    new ValidationContext(this, null, null) { MemberName = "FirstName" });
                m_FirstName = value;
            }
        }

        [Required(ErrorMessage = "Last Name is required.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Numbers and special characters are not allowed in the name.")]
        [StringLength(8, MinimumLength = 3, ErrorMessage =
            "Last name must be between 3 and 8 characters long.")]
        public string LastName
        {
            get { return m_LastName; }
            set
            {
                Validator.ValidateProperty(value,
                    new ValidationContext(this, null, null) { MemberName = "LastName" });
                m_LastName = value;
            }
        }
    }
}
