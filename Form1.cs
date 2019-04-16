using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace emailBook {
    public partial class Form1 : Form {

        public static List<PersonEntry> personList = new List<PersonEntry>();   //Create list of PersonEntry object

        public class PersonEntry {
            public PersonEntry(string inName, string inEmail, string inTele) {
                personName = inName;
                personEmail = inEmail;
                personTeleNum = inTele;
            }


            private String personName;           //private data member to hold name as string
            public String PersonName {           //public properties Get and Set
                get {
                    return personName;
                }
                set {
                    personName = value;
                }
            }

            private String personEmail;     //private data member to hold persons email as a string
            public String PersonEmail {     //public properties Get and Set
                get {
                    return personEmail;
                }
                set {
                    personEmail = value;
                }
            }

            private String personTeleNum;       //private data member to hold persons office number as a string
            public String PersonTeleNum {       //public properties Get and Set
                get {
                    return personTeleNum;
                }
                set {
                    personTeleNum = value;
                }
            }
        } // end of PersonEntry class

        /**********************************************************
         * ********************************************************
         * ********************************************************/

        public Form1() {
            InitializeComponent();
        }

        //loads txt file into the list
        private void loadList() {
            try {
                StreamReader inFile = new StreamReader("names.txt"); //open file

                String personName, //vars to hold txt file info
                    personEmail,
                    personPhone,
                    currentLine;

                currentLine = inFile.ReadLine(); //grab line
                while(currentLine != null) { //continue as long as file has stuff
                    personName = currentLine;

                    currentLine = inFile.ReadLine(); //grab line
                    personEmail = currentLine;

                    currentLine = inFile.ReadLine(); //grab line
                    personPhone = currentLine;

                    personList.Add(new PersonEntry(personName, personEmail, personPhone)); //put a new person entry into the back of the list

                    currentLine = inFile.ReadLine(); //grab line
                }

                inFile.Close();

                for(int i = 0; i < personList.Count; i++) { //cycle throught list
                    mainBox.Items.Add(personList[i].PersonName); //add list X to list box in form
                }

            } catch (Exception ) {
                MessageBox.Show("can't find txt file"); //couldnt open file
            }
        }

        private void ExitButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e) {
            loadList(); //when form loads, call load function
        }

        //when an item is picked in list box
        private void MainBox_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                for(int i = 0; i < personList.Count; i++) { //cycle through list - to find all the info for the name the user selected
                    if(mainBox.SelectedItem.ToString() == personList[i].PersonName) { //check if the user choice matches a name in the list
                        Form newForm = new Form2(); //make new form

                        Form2.getInfo(personList[i].PersonName, personList[i].PersonEmail, personList[i].PersonTeleNum); //send data to other form

                        newForm.Show(); //show new form
                    }
                }
            } catch (Exception ex) { //something went wrong - dont crash
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
