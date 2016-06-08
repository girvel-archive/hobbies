using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RelaxList;

namespace Hobbies.Interface {
    public partial class NewListForm : Form {
        MainForm ParentMainForm;
        List<Hobby> CurrentHobbies;

        public NewListForm(MainForm parentMainForm) {
            InitializeComponent();
            ParentMainForm = parentMainForm;
            CurrentHobbies = new List<Hobby>();
        }

        private void textBoxHobbyName_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                buttonAdd_Click(sender, e);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e) {
            if (textBoxHobbyName.Text != string.Empty) {
                var newHobby = new Hobby(textBoxHobbyName.Text);
                textBoxHobbyName.Text = string.Empty;

                listBoxHobbies.Items.Add(newHobby);
                CurrentHobbies.Add(newHobby);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e) {
            var remObject = listBoxHobbies.Items[listBoxHobbies.SelectedIndex];

            CurrentHobbies.Remove((Hobby)remObject);
            listBoxHobbies.Items.Remove(remObject);
        }

        private void buttonOk_Click(object sender, EventArgs e) {
            Session.Hobbies = CurrentHobbies;
            ParentMainForm.MainAddHobbyForm = null;
            ParentMainForm.HobbiesRefresh();
            Close();
        }
    }
}
