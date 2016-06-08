using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;
using RelaxList;

namespace Hobbies.Interface {
    public partial class MainForm : Form {
        public AddHobbyForm MainAddHobbyForm { get; set; }
        public NewListForm MainNewListForm { get; set; }

        public MainForm() {
            InitializeComponent();
        }

        public void HobbiesRefresh() {
            checkedListBoxHobbies.Items.Clear();
            checkedListBoxHobbies.Items.AddRange(Session.Hobbies.ToArray());
        }

        private void menuItemNew_Click(object sender, EventArgs e) {
            if (MainNewListForm == null || !MainNewListForm.Visible) {
                MainNewListForm = new NewListForm(this) { Visible = true };
            }
        }

        private void menuItemOpen_Click(object sender, EventArgs e) {
            mainOpenFileDialog.ShowDialog();

            byte[] bytes;
            using (Stream currentStream = mainOpenFileDialog.OpenFile()) {
                bytes = new byte[currentStream.Length];
                currentStream.Read(bytes, 0, (int)currentStream.Length);
            }
            var str = new string((from b in bytes select Convert.ToChar(b)).ToArray());

            Session.Hobbies = new List<Hobby>(FileHelper.FromStr(str));
            HobbiesRefresh();
        }

        private void menuItemSave_Click(object sender, EventArgs e) {
            mainSaveFileDialog.ShowDialog();
            using (Stream currentStream = mainSaveFileDialog.OpenFile()) {
                var bytes = 
                    from symb 
                    in FileHelper.ToStr(Session.Hobbies).ToCharArray()
                    select Convert.ToByte(symb);

                var byteArray = bytes as byte[] ?? bytes.ToArray();
                currentStream.Write(byteArray, 0, byteArray.Length);
            }
        }

        private void menuItemClose_Click(object sender, EventArgs e) {
            Session.Hobbies.Clear();
            checkedListBoxHobbies.Items.Clear();
        }
    }
}
