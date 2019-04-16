using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace emailBook {
    public partial class Form2 : Form {
        static private string personName {
            get; set;
        } 

        static private string persoEmail {
            get; set;
        } 

        static private string personTele {
            get; set;
        }

        public Form2() {
            InitializeComponent();
        }

        private void HideButton_Click(object sender, EventArgs e) {
            this.Close(); //close this form
        }

        public static void getInfo(string inName, string inEmail, string inTele) { //cant grab infro from other form without some type of bypass
           personName = inName;
           persoEmail = inEmail;
           personTele = inTele;
        }

        private void Form2_Load(object sender, EventArgs e) { //when form loads - change textboxes
            nameLabel.Text = personName;
            emailLabel.Text = persoEmail;
            phoneLabel.Text = personTele;
        }
    }
}
