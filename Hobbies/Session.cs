using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hobbies;
using Hobbies.Interface;

namespace RelaxList {
    static class Session {
        public static MainForm MMainForm { get; set; }
        public static List<Hobby> Hobbies { get; set; }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main() {
            Hobbies = new List<Hobby>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MMainForm = new MainForm();
            Application.Run(MMainForm);
        }
    }
}
