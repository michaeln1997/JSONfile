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
using System.Windows.Forms.Design;
using static System.Console;

namespace ReadJsonApp
{
    public partial class Form1 : Form
    {
        public Form1() // creating the form 1 - window
        {
            InitializeComponent();
            textBox.SelectionAlignment = HorizontalAlignment.Center;
        }

        OpenFileDialog uploadDialog = new OpenFileDialog(); // creating a variable to hold file dialog for file upload
        string fileContainer = string.Empty; // string that will containt the text from json files

        private void btnBrowse_Click(object sender, EventArgs e) // upload btn
        {
            uploadDialog.Filter = "json files (*.json)|*.json"; // only json files are uploadable
            fileContainer = string.Empty; // preparing the string for input
            int counter = 1;

            if (uploadDialog.ShowDialog() == DialogResult.OK) // if file dialog is successfully opened and a json file is selected
            {
                var path = uploadDialog.FileName; // location path of the selected file
                string fileName = Path.GetFileNameWithoutExtension(path); // storing the file name

                var fileStream = uploadDialog.OpenFile(); // creating a file stream with text from the selected json file
                using (StreamReader file = new StreamReader(fileStream)) // readaing the text from json file into the program
                {
                    string line = string.Empty; // preparing a string for line-by-line reading

                    /*
                     * the following set of code will do the folowing:
                     *      add the name of selected json file to fileContainer string;
                     *      compare the the name of the selected json file with known json files;
                     *      call the specific method for the selected json file based on its name;
                     *          or read the entire json file into the fileContainer string in case its name is unknown;
                     * */
                    if (fileName == "Library") { fileContainer = fileName + "\n"; readLibrary(line, file, counter); }
                    else if (fileName == "Devices") { fileContainer = fileName + "\n"; readDevices(line, file, counter); }
                    else if (fileName == "Purchase History") { fileContainer = fileName + "\n"; readPurchaseH(line, file, counter); }
                    else if (fileName == "Profile") { fileContainer = fileName + "\n"; readProfile(line, file, counter); }
                    else if (fileName == "search-history") { fileContainer = "YouTube History\n"; readYtHistory(line, file, counter); }
                    else if (fileName == "watch-history") { fileContainer = "YouTube History\n"; readYtHistory(line, file, counter); }
                    else if (fileName == "Autofill") { fileContainer = fileName + "\n"; readAutofill(line, file, counter); }
                    else if (fileName == "BrowserHistory") { fileContainer = fileName + "\n"; readBrowserHistory(line, file, counter); }
                    else if (fileName == "MyActivity") { fileContainer = fileName + "\n"; readMyActivity(line, file, counter); }
                    else { fileContainer = fileName + "\n"; fileContainer += file.ReadToEnd(); }
                }
                // the following set of code will make the form1 elements for the step 2 visible to the user when the step 1 is completed
                panel3.Visible = false;
                panel4.Visible = true;
                label4.ForeColor = SystemColors.GradientInactiveCaption;
                label2.Visible=true;
                btnPreview.Visible = true;
                btnSaveAs.Visible = true;
            }
        }


        ///////////////////////////////// Methods for Known Json Files /////////////////////////////////

        // method for reading Library.json
        public void readLibrary(string line1, StreamReader file1, int counter1)
        {
            line1 = file1.ReadLine().Trim(); // reading in the next line from the file without white spaces
            while (file1.Peek() >= 0) // will be executing until the end of the file is reached
            {
                if (line1.Contains("title")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace("title: ", "App name: ");
                    line1 = "\n" + "\n" + counter1 + ". " + line1 + "\n";
                    fileContainer += line1;
                    counter1++;
                }

                if (line1.Contains("acquisitionTime")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace("acquisitionTime: ", "    Date and time: ");
                    line1 = line1.Replace("T", " at ");
                    line1 = line1.Remove(line1.Length - 5);
                    fileContainer += line1;
                }

                line1 = file1.ReadLine().Trim(); // reading in the next line from the file without white spaces
            }
        }

        // method for reading Devices.json
        public void readDevices(string line1, StreamReader file1, int counter1)
        {
            line1 = file1.ReadLine().Trim(); // reading in the next line from the file without white spaces
            while (file1.Peek() >= 0) // will be executing until the end of the file is reached
            {
                if (line1.Contains("carrierName")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace("carrierName: ", "Carrier Name: ");
                    line1 = "\n" + "\n" + counter1 + ". " + line1 + "\n";
                    fileContainer += line1;
                    counter1++;
                }

                if (line1.Contains("manufacturer")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1 + "\n";
                    fileContainer += line1;
                }

                if (line1.Contains("deviceIpCountry")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace("deviceIpCountry: ", "Device is from: ");
                    line1 = line1 + "\n";
                    fileContainer += line1;
                }

                if (line1.Contains("userLocale")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace("userLocale: ", "Device most recently used in: ");
                    line1 = line1 + "\n";
                    fileContainer += line1;
                }

                if (line1.Contains("deviceRegistrationTime")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Remove(line1.Length - 6);
                    line1 = line1.Replace("deviceRegistrationTime: ", "Device registrated: ");
                    line1 = line1.Replace("T", " at ");
                    line1 = line1 + "\n";
                    fileContainer += line1;
                }

                if (line1.Contains("lastTimeDeviceActive")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Remove(line1.Length - 8);
                    line1 = line1.Replace("lastTimeDeviceActive: ", "Device last time active: ");
                    line1 = line1.Replace("T", " at ");
                    line1 = line1 + "\n";
                    fileContainer += line1;
                }
                line1 = file1.ReadLine().Trim(); // reading in the next line from the file without white spaces
            }
        }

        // method for reading PurchaseHistory.json
        public void readPurchaseH(string line1, StreamReader file1, int counter1)
        {
            line1 = file1.ReadLine().Trim(); // reading in the next line from the file without white spaces
            while (file1.Peek() >= 0) // will be executing until the end of the file is reached
            {
                if (line1.Contains("invoicePrice")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace("invoicePrice: ", "Price paid: ");
                    line1 = "\n" + "\n" + counter1 + ". " + line1 + "\n";
                    fileContainer += line1;
                    counter1++;
                }

                if (line1.Contains("paymentMethodTitle")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace("paymentMethodTitle: ", "Payment Method: ");
                    line1 = line1 + "\n";
                    fileContainer += line1;
                }

                if (line1.Contains("userCountry")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace("userCountry: ", "Country: ");
                    line1 = line1 + "\n";
                    fileContainer += line1;
                }

                if (line1.Contains("documentType")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace("documentType: ", "Type of item purchased: ");
                    line1 = line1 + "\n";
                    fileContainer += line1;
                }

                if (line1.Contains("title")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace("title: ", "Item name: ");
                    line1 = line1 + "\n";
                    fileContainer += line1;
                }

                if (line1.Contains("purchaseTime")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Remove(line1.Length - 5);
                    line1 = line1.Replace("purchaseTime: ", "Purchase time: ");
                    line1 = line1.Replace("T", " at ");
                    line1 = line1 + "\n";
                    fileContainer += line1;
                }
                line1 = file1.ReadLine().Trim(); // reading in the next line from the file without white spaces
            }
        }

        // method for reading json file containing YouTube history
        public void readYtHistory(string line1, StreamReader file1, int counter1)
        {
            line1 = file1.ReadLine().Trim(); // reading in the next line from the file without white spaces
            while (file1.Peek() >= 0) // will be executing until the end of the file is reached
            {
                if (line1.Contains("title: Searched")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace("title: Searched for", "Searched for: ");
                    line1 = "\n" + "\n" + counter1 + ". " + line1 + "\n";
                    fileContainer += line1;
                    counter1++;
                }

                if (line1.Contains("title: Watched")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace("title: Watched", "Watched: ");
                    line1 = "\n" + "\n" + counter1 + ". " + line1 + "\n";
                    fileContainer += line1;
                    counter1++;
                }

                if (line1.Contains("titleUrl")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace("titleUrl: ", "URL: ");
                    line1 = line1 + "\n";
                    fileContainer += line1;
                }

                if (line1.Contains("time")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Remove(line1.Length - 5);
                    line1 = line1.Replace("time: ", "Date and time: ");
                    line1 = line1.Replace("T", " at ");
                    line1 = line1 + "\n";
                    fileContainer += line1;
                }
                line1 = file1.ReadLine().Trim(); // reading in the next line from the file without white spaces
            }
        }

        // method for reading Profile.json
        public void readProfile(string line1, StreamReader file1, int counter1)
        {
            line1 = file1.ReadLine().Trim(); // reading in the next line from the file without white spaces
            while (file1.Peek() >= 0) // will be executing until the end of the file is reached
            {
                if (line1.Contains("givenName")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace("givenName: ", "First Name: ");
                    line1 = "\n" + "\n" + counter1 + ". " + line1 + "\n";
                    fileContainer += line1;
                    counter1++;
                }

                if (line1.Contains("familyName")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace("familyName: ", "Last Name: ");
                    line1 = line1 + "\n";
                    fileContainer += line1;
                }

                if (line1.Contains("emails")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace("[{", "");
                    line1 = line1.Replace("emails: ", "Emails: ");
                    line1 = line1 + "\n";
                    fileContainer += line1;
                    line1 = file1.ReadLine().Trim(); // reading in the next line from the file without white spaces

                    if (line1.Contains("value")) // checking if the line contains a specific label
                    {
                        // this set of code will remove unnecessary characters,
                        //  substitute original label with those simpler for the users,
                        //  and add the 'filtrated' text to fileContainer
                        line1 = line1.Replace("\"", "");
                        line1 = line1.Replace("value: ", "     ");
                        line1 = line1 + "\n";
                        fileContainer += line1;
                    }
                }

                if (line1.Contains("gender")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace("{", "");
                    line1 = line1.Replace("gender: ", "Gender: ");
                    line1 = line1 + "\n";
                    fileContainer += line1;
                    line1 = file1.ReadLine().Trim(); // reading in the next line from the file without white spaces

                    if (line1.Contains("type")) // checking if the line contains a specific label
                    {
                        // this set of code will remove unnecessary characters,
                        //  substitute original label with those simpler for the users,
                        //  and add the 'filtrated' text to fileContainer
                        line1 = line1.Replace("\"", "");
                        line1 = line1.Replace("type: ", "     ");
                        line1 = line1 + "\n";
                        fileContainer += line1;
                    }
                }
                line1 = file1.ReadLine().Trim(); // reading in the next line from the file without white spaces
            }
        }

        // method for reading Autofill.json
        public void readAutofill(string line1, StreamReader file1, int counter1)
        {
            line1 = file1.ReadLine().Trim(); // reading in the next line from the file without white spaces
            while (file1.Peek() >= 0) // will be executing until the end of the file is reached
            {
                if (line1.Contains("name_first")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace("[", "");
                    line1 = line1.Replace("]", "");
                    line1 = line1.Replace(",", "");
                    line1 = line1.Replace("name_first: ", "First name: ");
                    line1 = "\n" + "\n" + counter1 + ". " + line1 + "\n";
                    fileContainer += line1;
                    counter1++;
                }

                if (line1.Contains("name_last")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace("[", "");
                    line1 = line1.Replace("]", "");
                    line1 = line1.Replace(",", "");
                    line1 = line1.Replace("name_last: ", "Last name: ");
                    line1 = line1 + "\n";
                    fileContainer += line1;
                }

                if (line1.Contains("name_middle")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace("[", "");
                    line1 = line1.Replace("]", "");
                    line1 = line1.Replace(",", "");
                    line1 = line1.Replace("name_middle: ", "Middle name: ");
                    line1 = line1 + "\n";
                    fileContainer += line1;
                }

                if (line1.Contains("email_address")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace("[", "");
                    line1 = line1.Replace("]", "");
                    line1 = line1.Replace(",", "");
                    line1 = line1.Replace("email_address: ", "Email address: ");
                    line1 = line1 + "\n";
                    fileContainer += line1;
                }

                if (line1.Contains("phone_home_whole_number")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace("[", "");
                    line1 = line1.Replace("]", "");
                    line1 = line1.Replace(",", "");
                    line1 = line1.Replace("phone_home_whole_number: ", "Phone number: ");
                    line1 = line1 + "\n";
                    fileContainer += line1;
                }

                if (line1.Contains("address_home_line1")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace(",", "");
                    line1 = line1.Replace("address_home_line1: ", "Home Address 1: ");
                    line1 = line1 + "\n";
                    fileContainer += line1;
                }

                if (line1.Contains("address_home_line2")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace(",", "");
                    line1 = line1.Replace("address_home_line2: ", "Home Address 2: ");
                    line1 = line1 + "\n";
                    fileContainer += line1;
                }

                if (line1.Contains("address_home_country")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace(",", "");
                    line1 = line1.Replace("address_home_country: ", "Home country: ");
                    line1 = line1 + "\n";
                    fileContainer += line1;
                }

                if (line1.Contains("address_home_state")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace(",", "");
                    line1 = line1.Replace("address_home_state: ", "State: ");
                    line1 = line1 + "\n";
                    fileContainer += line1;
                }

                if (line1.Contains("address_home_city")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace(",", "");
                    line1 = line1.Replace("address_home_city: ", "City: ");
                    line1 = line1 + "\n";
                    fileContainer += line1;
                }

                if (line1.Contains("address_home_zip")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace(",", "");
                    line1 = line1.Replace("address_home_zip: ", "Zip code: ");
                    line1 = line1 + "\n";
                    fileContainer += line1;
                }

                line1 = file1.ReadLine().Trim(); // reading in the next line from the file without white spaces
            }
        }

        // method for reading BrowserHistory.json
        public void readBrowserHistory(string line1, StreamReader file1, int counter1)
        {
            line1 = file1.ReadLine().Trim(); // reading in the next line from the file without white spaces
            while (file1.Peek() >= 0) // will be executing until the end of the file is reached
            {
                if (line1.Contains("page_transition")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace("page_transition: ", "Transition type: ");
                    line1 = "\n" + "\n" + counter1 + ". " + line1 + "\n";
                    fileContainer += line1;
                    counter1++;
                }

                if (line1.Contains("title")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace("title: ", "Page title: ");
                    line1 = line1 + "\n";
                    fileContainer += line1;
                }

                if (line1.Contains("\"url\"")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace("url: ", "URL: ");
                    line1 = line1 + "\n";
                    fileContainer += line1;
                }

                line1 = file1.ReadLine().Trim(); // reading in the next line from the file without white spaces
            }
        }

        // method for reading MyActivity.json
        public void readMyActivity(string line1, StreamReader file1, int counter1)
        {
            line1 = file1.ReadLine().Trim(); // reading in the next line from the file without white spaces
            while (file1.Peek() >= 0) // will be executing until the end of the file is reached
            {
                if (line1.Contains("header")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace("header:", "Product: ");
                    line1 = "\n" + "\n" + counter1 + ". " + line1 + "\n";
                    fileContainer += line1;
                    counter1++;
                }

                if (line1.Contains("title\":")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace("title: ", "Action: ");
                    line1 = line1 + "\n";
                    fileContainer += line1;
                }

                if (line1.Contains("titleUrl")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Replace("titleUrl: ", "URL: ");
                    line1 = line1 + "\n";
                    fileContainer += line1;
                }

                if (line1.Contains("time")) // checking if the line contains a specific label
                {
                    // this set of code will remove unnecessary characters,
                    //  substitute original label with those simpler for the users,
                    //  and add the 'filtrated' text to fileContainer
                    line1 = line1.Replace("\"", "");
                    line1 = line1.Remove(line1.Length - 6);
                    line1 = line1.Replace("time: ", "Date and time: ");
                    line1 = line1.Replace("T", " at ");
                    line1 = line1 + "\n";
                    fileContainer += line1;
                }
                line1 = file1.ReadLine().Trim(); // reading in the next line from the file without white spaces
            }
        }

        /////////////////////////////////////////////////////////////
        
        // Creating Click Event for SaveAs Button 
        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            Stream myStream; // creating a stream for writing text
            SaveFileDialog saveDialog = new SaveFileDialog(); // creating file dialog for saving onto disc

            saveDialog.Filter = "txt files (*.txt)|*.txt"; // only file type available for save is .txt

            if (saveDialog.ShowDialog() == DialogResult.OK) // if the file dialog is oppened successfully
            {
                if ((myStream = saveDialog.OpenFile()) != null) // oppening a file to be written into
                {
                    byte[] byteArray = Encoding.ASCII.GetBytes(fileContainer); // transefing text form fileContainer into bytes
                    MemoryStream stream = new MemoryStream(byteArray); // creating memory stream and putting bytes into it

                    stream.CopyTo(myStream); // copying data from memory stream into the stream and to the file
                    myStream.Close(); // closing the stream
                }
            }
        }

        /////////////////////////////////////////////////////////////

        // Creating Click Event for Preview Button 
        private void btnPreview_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(); // clicking the button will create a new form (window)
            Form2.addText(fileContainer); // adding the text from fileContainer to the new form
            form2.Show(); // showing the new form to the user
        }
        /////////////////////////////////////////////////////////////
        
        
        
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
