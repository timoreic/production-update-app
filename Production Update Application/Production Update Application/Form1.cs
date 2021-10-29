using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // Required for File I/O

namespace Production_Update_Application
{
    public partial class productionUpdateApplication : Form
    {
        bool masterFileOpen = false; // Stores bool if master file is open or not
        List<string> idList; // Stores a list of ids
        List<string> qtyList; // Stores a list of product quantities
        string transferReport = ""; // Stores the transfer report
        string masterFileName = ""; // Stores the fileName for the new master file
        string errorFileName = ""; // Stores the filename for the error file
        string transferID; // Stores the ID of the current transfer
        string masterID; // Stores the ID of the current master
        int errorCounter; // Stores the number of errors



        // productUpdateApplication constructor
        public productionUpdateApplication()
        {
            InitializeComponent();
        }



        // Event handler if exitButton is clicked
        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the application
            this.Close();
        }



        // Event handler if openButton is clicked
        private void openButton_Click(object sender, EventArgs e)
        {
            // try to do..
            try
            {
                // Change openFileDialog filename to an empty string
                openFileDialog.FileName = "";

                // Open File Dialog and check if user clicked OK button
                if (openFileDialog.ShowDialog() == DialogResult.OK) 
                {
                    // Open the file
                    StreamReader inputFile = File.OpenText(openFileDialog.FileName);

                    // Make Instructions invisible and master file visible
                    instructionsLabel.Visible = false;
                    instructionsTextBox.Visible = false;
                    masterFileLabel.Visible = true;
                    masterListBox.Visible = true;

                    // Clear idListBox 
                    masterListBox.Items.Clear();

                    // Add Heading and empty column to idListBox
                    masterListBox.Items.Add("Product ID \t Quantity in Stock");
                    masterListBox.Items.Add("");

                    // Create a new idList and qtyList
                    idList = new List<string>();
                    qtyList = new List<string>();
                    
                    bool isErrorFree = false; // Stores if masterFile is error free or not

                    // Set masterID to an empty string
                    masterID = "";

                    bool hasEntries = false; // Stores if the master file has error free entries

                    // While inputfile (master file) has lines do..
                    while (!inputFile.EndOfStream)
                    {
                        // Read one line and store it in line
                        string line = inputFile.ReadLine();

                        // Split the line and store each item in lineItems
                        string[] lineItems = line.Split(' ');

                        // Call checkMasterForErrors and store boolean outcome in isErrorFree
                        isErrorFree = checkMasterForErrors(lineItems);

                        if (isErrorFree)
                        {
                            // Update hasEntries to true
                            hasEntries = true;
                            // Add ID + QTY to masterListBox
                            masterListBox.Items.Add(lineItems[0] + "\t\t" + lineItems[1]);
                            // Add ID + QTY to lists
                            idList.Add(lineItems[0]);
                            qtyList.Add(lineItems[1]);
                        }
                    }

                    if (hasEntries)
                    {
                        // Change masterFileOpen bool to true
                        masterFileOpen = true;
                    }

                    // Close the file
                    inputFile.Close();
                }
            }
            // catch any exception withing try block and do..
            catch(Exception ex)
            {
                // Show a message box with the error message
                MessageBox.Show(ex.Message);
            }
        }



        // Method to check master file for errors
        private bool checkMasterForErrors(string[] lineItems)
        {
            // CHECK IF MASTER ID IS AN INTEGER
            // If master ID can be converted to int do..
            if (Int32.TryParse(lineItems[0], out int idInteger))
            {


                // CHECK IF AN ENTRY IS EMPTY:
                // for each item in lineItems do..
                foreach (string item in lineItems)
                {
                    // if item is an empty string
                    if (item == "")
                    {
                        // Display a message with the error
                        MessageBox.Show("An error occured in the master file:" +
                            "\n\n\nLine:\t" + string.Join(" ", lineItems) +
                            "\n\nReason:\t Line contains an empty entry." +
                            "\n\n\nPlease note that this line will be ignored.");

                        // Stop error checking and return false
                        return false;
                    }
                }


                // CHECK ENTRY FORMAT:
                // If master entry has not two entries,
                // or Qty value is not an integer do...
                if (lineItems.Length != 2 || !Int32.TryParse(lineItems[1], out int soldInt))
                {
                    // Display a message with the error
                    MessageBox.Show("An error occured in the master file:" +
                        "\n\n\nLine:\t" + string.Join(" ", lineItems) +
                        "\n\nReason:\t Line has less or more than 2 entries, or the qty value is not an integer." +
                        "\n\n\nPlease note that this line will be ignored.");

                    // Stop error checking and return false
                    return false;
                }


                // CHECK IF CURRENT MASTER ID IS BIGGER THAN PREVIOUS
                // If masterID is empty do..
                if (masterID == "")
                {
                    // Store current master ID in masterID
                    masterID = lineItems[0];
                }
                // If current master ID is bigger than the previous master ID do..
                else if (Int32.Parse(lineItems[0]) > Int32.Parse(masterID))
                {
                    // Update current master ID
                    masterID = lineItems[0];
                }
                // Else if the current master ID is not bigger than the previous master ID do..
                else
                {
                    // Display a message with the error
                    MessageBox.Show("An error occured in the master file:" +
                        "\n\n\nLine:\t" + string.Join(" ", lineItems) +
                        "\n\nReason:\t Entry is out of order. ID is smaller or equal to previous entry." +
                        "\n\n\nPlease note that this line will be ignored.");

                    // Stop error checking and return false
                    return false;
                }


            }
            // If the master ID cannot be converted to integer do.. 
            else
            {
                // Display a message with the error
                MessageBox.Show("An error occured in the master file:" +
                    "\n\n\nLine:\t" + string.Join(" ", lineItems) +
                    "\n\nReason:\t Product ID is not an integer." +
                    "\n\n\nPlease note that this line will be ignored.");

                // Stop error checking and return false
                return false;
            }


            // Return true if no errors are found
            return true;
        }



        // Event handler if clearButton is clicked
        private void clearButton_Click(object sender, EventArgs e)
        {
            // Clear masterListBox
            masterListBox.Items.Clear();

            // Make Instructions invisible and master file visible
            masterFileLabel.Visible = false;
            masterListBox.Visible = false;
            instructionsLabel.Visible = true;
            instructionsTextBox.Visible = true;

            // Change boolean variable masterFileOpen to false 
            masterFileOpen = false;
        }



        // Event handler if updateButton is clicked
        private void updateButton_Click(object sender, EventArgs e)
        {
            // If master file is not open do.. 
            if (!masterFileOpen)
            {
                // Display error message
                MessageBox.Show("Error: No master file open. Follow instructions to open up the master file first.");
            }

            // If master file is open do..
            else
            {
                // Create new transfer report
                transferReport = "Transfer Report:\n\n";

                // Try to do
                try
                {
                    // Show message box to inform user what file to open
                    MessageBox.Show("Open the transaction file..");

                    // Change openFileDialog filename and transferID to an empty string
                    openFileDialog.FileName = "";
                    transferID = "";

                    // Set error counter to 0
                    errorCounter = 0;

                    // Open File Dialog and check if user clicked OK button
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Open the file (transfer file)
                        StreamReader inputFile = File.OpenText(openFileDialog.FileName);

                        int transferCounter = 0; // Stores the number of completed transfers
                        int masterCounter = 0; // Stores the number of master records processed
                        int recordCounter = 0; // Stores the number of records updated
                        string recordID = ""; // Stores the ID of the current record
                        string totalSold = "0"; // Stores the total number of items sold
                        string minSold = ""; // Stores the min number of items sold per transaction
                        string minSoldIdDate = ""; // Stores the ID and Date of the transaction with min items sold
                        string maxSold = "0"; // Stores the max number of items sold per transaction
                        string maxSoldIdDate = ""; // Stores the ID and Date of the transaction with the max items sold
                        bool isErrorFree = false; // Stores boolean if file is error free or not

                        // While input file (transfer file) has lines do..
                        while (!inputFile.EndOfStream)
                        {
                            // Read one line and store it in line
                            string line = inputFile.ReadLine();

                            // Split line and store each item in lineItems
                            string[] lineItems = line.Split(' ');

                            // Check transfer line for errors and store boolean outcome in isErrorFree
                            isErrorFree = checkTransactionForErrors(lineItems);

                            // If transfer line is error free do..
                            if (isErrorFree)
                            {
                                // Add current sold to totalSold
                                totalSold = (Int32.Parse(lineItems[2]) + Int32.Parse(totalSold)).ToString(); 

                                // Check if minSold is empty
                                if (minSold == "")
                                {
                                    // Store current sold in minSold, and Date + ID in minSoldIdDate
                                    minSold = lineItems[2];
                                    minSoldIdDate = lineItems[1] + " - ID " + lineItems[0];
                                }
                                // Else check if current sold is smaller than minSold
                                else if (Int32.Parse(lineItems[2]) < Int32.Parse(minSold))
                                {
                                    // Store current sold in minSold, and ID + Date in minSoldIdDate
                                    minSold = lineItems[2];
                                    minSoldIdDate = lineItems[1] + " - ID " + lineItems[0];
                                }

                                // Check if current sold is bigger than maxSold
                                if (Int32.Parse(lineItems[2]) > Int32.Parse(maxSold))
                                {
                                    // Store current sold in maxSold
                                    maxSold = lineItems[2];
                                    maxSoldIdDate = lineItems[1] + " - ID " + lineItems[0];
                                }

                                // If not the same record is processed do..
                                if (recordID != lineItems[0])
                                {
                                    // Increase record counter by one
                                    recordCounter++;

                                    // Store product ID in recordID
                                    recordID = lineItems[0];
                                }


                                // While transfer ID and master ID are not the same do.. 
                                while (lineItems[0] != idList[masterCounter])
                                {
                                    // Call write newMasterFile
                                    writeNewMasterFile(masterCounter);

                                    // Increase masterCounter by one
                                    masterCounter++;
                                }


                                // If transfer ID and master ID are the same do..
                                if (lineItems[0] == idList[masterCounter])
                                {
                                    // Call processUpdate and store return value (updated product quantity) in newBalance
                                    string newBalance = processUpdate(lineItems, masterCounter, transferCounter);

                                    // Update balance in qtylist and masterListBox
                                    qtyList[masterCounter] = newBalance;
                                    masterListBox.Items[masterCounter+2] = idList[masterCounter] + "\t\t" + newBalance;
                                }
                            }

                            // Increase transferCounter by one
                            transferCounter++;
                        }

                        // For index from masterCounter to idListBox count do..
                        for (int i = masterCounter; i < idList.Count; i++)
                        {
                            // Call writeNewMasterFile
                            writeNewMasterFile(masterCounter);

                            // Increase masterCounter by one
                            masterCounter++;
                        }

                        // Close the file
                        inputFile.Close();

                        string averageSold = "0"; // Stores the average of sold items
                        // If transferCounter is not 0 do..
                        if ((transferCounter-errorCounter) != 0)
                        {
                            // Calculate average items sold and store in averageSold
                            averageSold = (Int32.Parse(totalSold) / (transferCounter - errorCounter)).ToString();
                        }

                        // Add transfer counter and record count to transfer report
                        transferReport = transferReport +
                            "\n\n\nTotal sold:\t\t" + totalSold + " items" +
                            "\n\nAverage sold:\t\t" + averageSold + " items per transaction" +
                            "\n\nMinimum sold:\t\t" + minSold + " items (" + minSoldIdDate + ")" +
                            "\n\nMaximum sold:\t\t" + maxSold + " items (" + maxSoldIdDate + ")" +
                            "\n\nTotal transfers:\t\t" + (transferCounter - errorCounter).ToString() +
                            "\n\nTotal records updated:\t" + (recordCounter).ToString() + "\n\nTotal errors:\t\t" +
                            errorCounter.ToString();

                        // Show transfer report
                        MessageBox.Show(transferReport);
                    }
                }

                // catch any exception withing try block and do..
                catch (Exception ex)
                {
                    // Show a message box with the error message
                    MessageBox.Show("Update Button Event Handler Error: " + ex.Message);
                }
            }
        }



        // Method to check transaction file for errors
        private bool checkTransactionForErrors(string[] lineItems)
        {

            // CHECK IF TRANSFER ID IS AN INTEGER
            // If transfer ID can be converted to int do..
            if (Int32.TryParse(lineItems[0], out int idInteger))
            {


                // CHECK IF TRANSFER ID EXISTS IN MASTER FILE
                bool isMissing = true; // Stores if transfer ID exists in the master file

                // For each item in idListBox do..
                for (int i = 0; i < idList.Count; i++)
                {
                    // If transfer ID is the same as master ID do..
                    if (lineItems[0] == idList[i])
                    {
                        // Store false in isMissing
                        isMissing = false;
                    }
                }
                // If ID is not in master file do..
                if (isMissing)
                {
                    // Call writeErrorFile with type isMissing
                    writeErrorFile("isMissing", lineItems, errorCounter);

                    // Increase errorCounter by one
                    errorCounter++;

                    // Stop error checking and return false
                    return false;
                }


                // CHECK IF CURRENT TRANSFER ID IS BIGGER THAN PREVIOUS
                // If transferID is empty do..
                if (transferID == "")
                {
                    // Store current transfer ID in transferID
                    transferID = lineItems[0];
                }
                // If current transfer ID is bigger or the equal to the previous transfer ID do..
                if (Int32.Parse(lineItems[0]) >= Int32.Parse(transferID))
                {
                    // Update current transfer ID
                    transferID = lineItems[0];
                }
                // Else if the current transfer ID is not bigger than the previous transfer ID do..
                else
                {
                    // Call writeErrorFile with type currentIsBigger
                    writeErrorFile("currentIsBigger", lineItems, errorCounter);

                    // Increase errorCounter by one
                    errorCounter++;

                    // Stop error checking and return false
                    return false;
                }


                // CHECK IF AN ENTRY IS EMPTY:
                // for each item in lineItems do..
                foreach (string item in lineItems)
                {
                    // if item is an empty string
                    if (item == "")
                    {
                        // Call writeErrorFile with type entryMissing
                        writeErrorFile("entryMissing", lineItems, errorCounter);

                        // Increase errorCounter by one
                        errorCounter++;

                        // Stop error checking and return false
                        return false;
                    }
                }


                // CHECK ENTRY FORMAT:
                // If transfer entry has not five entries,
                // or Sold value is not an integer,
                // or Returned value is not an integer,
                // or Bought value is not an integer do..
                if (lineItems.Length != 5 ||
                    !Int32.TryParse(lineItems[2], out int soldInt) ||
                    !Int32.TryParse(lineItems[3], out int returnedInt) ||
                    !Int32.TryParse(lineItems[4], out int boughtInt))
                {
                    // Call writeErrorFile with type wrongFormat
                    writeErrorFile("wrongFormat", lineItems, errorCounter);

                    // Increase errorCounter by one
                    errorCounter++;

                    // Stop error checking and return false
                    return false;
                }

            }
            // If the transfer ID cannot be converted to integer do.. 
            else
            {
                // Call writeErrorFile with type idDescending
                writeErrorFile("wrongIdFormat", lineItems, errorCounter);

                // Increase errorCounter by one
                errorCounter++;

                // Stop error checking and return false
                return false;
            }


                //  Return true
                return true;
            }


        // Method to write or append to error file
        private void writeErrorFile(string type, string[] errorLine, int errorCounter)
        {
            // Try to do..
            try
            {
                // Create StreamWriter object 
                StreamWriter outputFile;

                // If masterCounter is 0 do..
                if (errorCounter == 0)
                {
                    // Show message box to inform user what file to save
                    MessageBox.Show("An error occured.\nChoose a name and location for the error file..");

                    // Change saveFileDialog filename to errorFile
                    saveFileDialog.FileName = "errorFile";

                    // Open file dialog and if user clicked OK do..
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Store filename from save file dialog in errorFileName
                        errorFileName = saveFileDialog.FileName;
                    }
                    // If user did not click OK do..
                    else
                    {
                        // Store default filename "errorFile.txt" in errorFileName
                        errorFileName = "errorFile.txt";
                    }

                    // Open the file and create a new text
                    outputFile = File.CreateText(errorFileName);
                }

                // If errorCounter is not 0 do..
                else
                {
                    // Open the file and append to the text
                    outputFile = File.AppendText(errorFileName);
                }


                // If type is isMissing do..
                if (type == "isMissing")
                {
                    // Write error to the error file
                    outputFile.WriteLine("Entry: " + string.Join(" ", errorLine) + "\nError: ID does not exist in master file." + "\n\n");
                }

                // Else if type is entryMissing do..
                else if (type == "entryMissing")
                {
                    // Write error to the error file
                    outputFile.WriteLine("Entry: " + string.Join(" ", errorLine) + "\nError: Field/s or content missing." + "\n\n");
                }

                // Else if type is wrongFormat do..
                else if (type == "wrongFormat")
                {
                    // Write error to the error file
                    outputFile.WriteLine("Entry: " + string.Join(" ", errorLine) + "\nError: Transaction record is invalid (Incorrect number of fields," +
                        " or field/s with wrong format" + "\n\n");
                }

                // Else if type is currentIsBigger do..
                else if (type == "currentIsBigger")
                {
                    // Write error to the error file
                    outputFile.WriteLine("Entry: " + string.Join(" ", errorLine) + "\nError: Transaction ID is smaller than previous transaction ID." + "\n\n");
                }

                // Else if type is wrongIdFormat
                else if (type == "wrongIdFormat")
                {
                    // Write error to the error file
                    outputFile.WriteLine("Entry: " + string.Join(" ", errorLine) + "\nError: Transaction ID is not an Integer." + "\n\n");
                }

                // Else if type is unknown
                else
                {
                    // Write error to the error file
                    outputFile.WriteLine("Entry: " + string.Join(" ", errorLine) + "\nError: Unknown - Contact developer." + "\n\n");
                }


                // Close the file
                outputFile.Close();
            }

            // catch any exception withing try block and do..
            catch (Exception ex)
            {
                // Show a message box with the error message
                MessageBox.Show(ex.Message);
            }
        }



        // Method to write a new master file
        private void writeNewMasterFile(int masterCounter)
        {
            // Try to do..
            try
            {
                // Create StreamWriter object 
                StreamWriter outputFile;

                // If masterCounter is 0 do..
                if (masterCounter == 0)
                {
                    // Show message box to inform user what file to save
                    MessageBox.Show("Choose a name and location for the new master file..");

                    // Change saveFileDialog filename to newMasterFile
                    saveFileDialog.FileName = "newMasterFile";

                    // Open file dialog and if user clicked OK do..
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Store filename from save file dialog in fileName
                        masterFileName = saveFileDialog.FileName;

                    }
                    // If user did not click OK do..
                    else
                    {
                        // Store default filename "newMasterFile.txt" in fileName
                        masterFileName = "newMasterFile.txt";
                    }

                    // Open the file and create a new text
                    outputFile = File.CreateText(masterFileName);

                    // Write a line (ID Qty) to the open file
                    outputFile.WriteLine(idList[masterCounter] + " " + qtyList[masterCounter]);
                }

                // If masterCounter is not 0 do..
                else
                {
                    // Open the file and append to the text
                    outputFile = File.AppendText(masterFileName);

                    // Write a line (ID Qty) to the open file
                    outputFile.WriteLine(idList[masterCounter] + " " + qtyList[masterCounter]);
                }


                // Close the file
                outputFile.Close();
            }

            // catch any exception withing try block and do..
            catch (Exception ex)
            {
                // Show a message box with the error message
                MessageBox.Show(ex.Message);
            }
        }



        // Method to process the transfer and add information to the transfer report
        private string processUpdate(string[] lineItems, int masterCounter, int transferCounter)
        {
            // Store initial quantity and convert to int
            int quantityBefore = Int32.Parse(qtyList[masterCounter]);

            int quantityAfter = quantityBefore - Int32.Parse(lineItems[2]) + Int32.Parse(lineItems[3]) + Int32.Parse(lineItems[4]);

            // Add information to the transfer report
            transferReport = transferReport + lineItems[1] + " - ID " + lineItems[0] + ":\tQuantity in Stock: " + 
                quantityBefore.ToString() + " -> " + quantityAfter.ToString() + "\n\t\tSold: " + lineItems[2].ToString() +
                "; Returned: " + lineItems[3].ToString() + "; Bought: " + lineItems[4].ToString() + "\n\n";

            // Return string with the new balance
            return quantityAfter.ToString();
        }



        // Event handler if reportButton was clicked
        private void reportButton_Click(object sender, EventArgs e)
        {
            // If transferReport is an empty string do..
            if (transferReport == "")
            {
                // Show a message box with information
                MessageBox.Show("No transfer report available. Update master file first.");
            }

            // If the transferReport is not an empty string do..
            else
            {
                // Show a message box with the transfer report
                MessageBox.Show(transferReport);
            }
        }
    }
}

