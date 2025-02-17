using System;
using System.Windows.Forms;
using UserManagerDesktop.UserServiceReference; 

namespace UserManagerDesktop
{
    public partial class Form1 : Form
    {
        private UserServiceClient _client; 

        public Form1()
        {
            InitializeComponent();
            _client = new UserServiceClient(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                var users = _client.GetUsers(); 
                dataGridViewUsers.DataSource = users; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження користувачів: " + ex.Message);
            }
        }

     
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try 
            {
                using (var userForm = new UserForm()) 
                {
                    if (userForm.ShowDialog() == DialogResult.OK) 
                    {
                        _client.AddUser(userForm.User); 
                        LoadUsers(); 
                    }
                }
            }
            catch (Exception ex)
            {
                ;
            }
     
        }

        
        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.CurrentRow != null) 
            {
                var user = (UserDTO)dataGridViewUsers.CurrentRow.DataBoundItem;
                using (var userForm = new UserForm(user))
                {
                    if (userForm.ShowDialog() == DialogResult.OK) 
                    {
                        _client.UpdateUser(userForm.User); 
                        LoadUsers(); 
                    }
                }
            }
            else
            {
                MessageBox.Show("Виберіть користувача для редагування.");
            }
        }

    
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.CurrentRow != null)
            {
                var user = (UserDTO)dataGridViewUsers.CurrentRow.DataBoundItem;
                var confirm = MessageBox.Show("Видалити користувача?", "Підтвердження", MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    _client.DeleteUser(user.Id); 
                    LoadUsers(); 
                }
            }
            else
            {
                MessageBox.Show("Виберіть користувача для видалення.");
            }
        }
    }
}
