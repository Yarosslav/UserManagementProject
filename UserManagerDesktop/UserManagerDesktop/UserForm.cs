using System;
using System.Windows.Forms;
using UserManagerDesktop.UserServiceReference;
using System.Text.RegularExpressions;

namespace UserManagerDesktop
{
    public partial class UserForm : Form
    {
        public UserDTO User { get; private set; }

        public UserForm()
        {
            InitializeComponent();
            User = new UserDTO();
        }

        public UserForm(UserDTO user) : this()
        {
            User = user;
            txtFullName.Text = user.FullName;
            txtDRFO.Text = user.DRFO;
            txtEmail.Text = user.Email;
            txtPhone.Text = user.Phone;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
          
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Неправильний формат електронної пошти!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Номер телефону не може бути порожнім!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            User.FullName = txtFullName.Text;
            User.DRFO = txtDRFO.Text;
            User.Email = txtEmail.Text;
            User.Phone = txtPhone.Text;
            User.DateModified = DateTime.Now;

            if (User.Id == 0) 
            {
                User.DateCreated = DateTime.Now;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private void txtDRFO_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }
    }
}
