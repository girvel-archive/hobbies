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
            checkedListBoxHobbies.Items.AddRange(Session.Hobbies.ToArray());
        }

        private void menuItemNew_Click(object sender, System.EventArgs e) {
            if (MainNewListForm == null || !MainNewListForm.Visible) {
                MainNewListForm = new NewListForm(this) { Visible = true };
            }
        }

        private void menuItemOpen_Click(object sender, EventArgs e) {
            var currentOpenFileDialog = new OpenFileDialog() {};

            currentOpenFileDialog.ShowDialog();
            using (Stream currentStream = currentOpenFileDialog.OpenFile()) {
                var bytes = new byte[currentStream.Length];
                currentStream.Read(bytes, 0, (int)currentStream.Length);
                var str = new string((from b in bytes select Convert.ToChar(b)).ToArray());

                Session.Hobbies = new List<Hobby>(FileHelper.FromStr(str));
            }
        }
    }
}
