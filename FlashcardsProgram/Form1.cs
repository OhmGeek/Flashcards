using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpeechLib;
using Microsoft.VisualBasic;
namespace FlashcardsProgram
{
    public partial class Form1 : Form
    {
        private List<Card> currentStack = new List<Card>(); //List <type> nameOfList - this holds all the cards.
        public string filename = "";
        private int cardIndex = -1;
        public bool speechOn = false;
        private string titleOfStack = "New Stack";
        private char delimiter = Strings.ChrW(31);
      
        public Form1()
        {
            InitializeComponent();
        }

        private void initialiseSpeechRecognition()
        {
           
        }

        //Display management:
        private void disableDisplay()
        {
            
            //Make all the text boxes display nothing.
            clearDisplay();

            //disable all the text boxes;
            qnTB.Enabled = false;
            anTB.Enabled = false;
            ntTB.Enabled = false;
        }
        private void startQuiz()
        {
            if (currentStack.Count != 0)
            {
               
                TestView x = new TestView();
                x.currentCardStack = currentStack;
                x.Show();
            }
            else
                MessageBox.Show("There are no cards for testing.","Flashcards");

        }
        private void clearDisplay()
        {
            //make the text box test contain nothing.
            qnTB.Text = "";
            anTB.Text = "";
            ntTB.Text = "";
        }
        private void enableDisplay()
        {
            //enable all the text boxes;
            qnTB.Enabled = true;
            anTB.Enabled = true;
            ntTB.Enabled = true;
        }
        private void displayCard(Card cardToDisplay)
        {
            qnTB.Text = cardToDisplay.Q;
            anTB.Text = cardToDisplay.A;
            ntTB.Text = cardToDisplay.N;
        }

        //File Management:
        private void saveStackToFile(string fileName)
        { 
        //1st line: Name Of Stack
        //2..n line: Question, ANSWER, NOTES using delimiter of ASC 32 (end of unit)    

            System.IO.StreamWriter writer = null;
            try
            {
                writer =  new System.IO.StreamWriter(fileName,false);

                writer.WriteLine(titleOfStack);
                for (int i = 0; i < currentStack.Count; i++)
                {
                    //write card at index i to file
                    string output = "";
                    output += currentStack[i].Q + delimiter;
                    output += currentStack[i].A + delimiter;
                    output += currentStack[i].N + delimiter;
                    output += currentStack[i].score;
                    writer.WriteLine(output);
                }
            }
            catch (Exception)
            {
                //an error occured.
                MessageBox.Show("An error occured!","Flashcards");
               
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                    statusLabel.Text = "Saving Successful.";
                }

            }
     



        }
        private void openStackFromFile(string fileName)
        {
            System.IO.StreamReader reader = null;
            currentStack.Clear(); //ensure that the card list is empty, so that we can proceed
            cardDisplayListBox.Items.Clear(); //also clear the user display.

            try 
	            {	        
		reader = new System.IO.StreamReader(fileName);

                 titleOfStack = reader.ReadLine();
                 stackTitle.Text = titleOfStack;
                 int i = 0;
                 do
                 {
                     Card cardToAdd = new Card();
                     string line = reader.ReadLine();
                     string[] A = line.Split(delimiter);
                     cardToAdd.Q = A[0];
                     cardToAdd.A = A[1];
                     cardToAdd.N = A[2];
                     cardToAdd.score = int.Parse(A[3]);
                     cardToAdd.index = i;
                     currentStack.Add(cardToAdd);
                     cardDisplayListBox.Items.Add(cardToAdd.Q);
                     i += 1;
                 } while (reader.EndOfStream == false);
	        }
	catch (Exception)
	{

        MessageBox.Show("Error!");
	}
            finally
            {

                if (reader != null)
                {
                    reader.Close();


                }

            }
        
        }

        //Card Management
        private void AddCard(string Q, string A, string N)
        {
            cardIndex +=1;
            Card myNewCard = new Card();
            enableDisplay();
            myNewCard.New(Q, A, N, cardIndex);
            currentStack.Add(myNewCard);
            cardDisplayListBox.Items.Add("Card " + currentStack.Count);
        }
        private void DeleteCard(int index)
        {
            try
            {
                currentStack.RemoveAt(index);
                cardDisplayListBox.Items.RemoveAt(index);
         //       Microsoft.VisualBasic.Interaction.MsgBox(cardDisplayListBox.Items.Count);



                if (currentStack.Count == 0)
                {
                    disableDisplay();
                    cardIndex = -1;
                }
                else
                {
                    clearDisplay(); //while we don't want to disable the display, we do want to make it devoid of text.
                    cardDisplayListBox.SelectedIndex = cardDisplayListBox.Items.Count - 1; //display the last item on the listbox.
                    cardIndex -= 1;
                }
            }
            catch (Exception)
            {   
            }
        
       
        }

        private void changeTitle()
        {
            string newTitle = Microsoft.VisualBasic.Interaction.InputBox("Please enter the Stack Title", "Stack Title", titleOfStack);
           if (newTitle != "")
           {
               titleOfStack= newTitle;
           }
           else
           {
               titleOfStack = "New Stack";
           }
           stackTitle.Text = titleOfStack;
        }



        private void Form1_Load(object sender, EventArgs e)
        {

            initialiseSpeechRecognition();

            if (currentStack.Count == 0)
            {
                disableDisplay();
            }
        }

       

       

        private void addCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this will add a new item to the list, which can be modified.
            AddCard("", "", ""); //add a blank card.
            cardDisplayListBox.SelectedIndex = cardDisplayListBox.Items.Count - 1;
            qnTB.Focus();

        }



        private void cardDisplayListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //when a new index is selected.
            try
            {
                displayCard(currentStack[cardDisplayListBox.SelectedIndex]);
            }
            catch (Exception)
            {
               
            }
        }


        //this code will edit the cards.
        private void qnTB_TextChanged(object sender, EventArgs e)
        {
           currentStack[cardDisplayListBox.SelectedIndex].Q = qnTB.Text;
        }

        private void anTB_TextChanged(object sender, EventArgs e)
        {
            currentStack[cardDisplayListBox.SelectedIndex].A = anTB.Text;
        }

        private void ntTB_TextChanged(object sender, EventArgs e)
        {
            currentStack[cardDisplayListBox.SelectedIndex].N = ntTB.Text;
        }

        private void cardDisplayListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteCard(cardDisplayListBox.SelectedIndex);
            }
        }

        private void stackTitle_Click(object sender, EventArgs e)
        {
            changeTitle();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savefile();
            
        }
        
        private void savefile()
        {

            if (filename == "")
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filename = saveFileDialog1.FileName;
                }
            }
            saveStackToFile(filename);

        }
        
        private void openFile()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                openStackFromFile(filename);
                enableDisplay();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void quizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startQuiz();
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void deleteCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cardDisplayListBox.SelectedIndex >= 0)
            {
                DeleteCard(cardDisplayListBox.SelectedIndex);
            }
            }

        private void button1_Click(object sender, EventArgs e)
        {
            AddCard("", "", ""); //add a blank card.
            cardDisplayListBox.SelectedIndex = cardDisplayListBox.Items.Count - 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cardDisplayListBox.SelectedIndex >= 0)
            {
                DeleteCard(cardDisplayListBox.SelectedIndex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            startQuiz();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Flashcards 1.00\nCopyright Ryan Collins 2014.\nAll Rights Reserved.","About");
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            //here, we resize the text boxes, so that they are in the correct proportion.
            qnTB.Width = panel4.Width - 5;
            anTB.Width = panel4.Width - 5;
            ntTB.Width = panel4.Width - 5;

            //labels too so that text is centred.
            qnLbl.Width = panel4.Width - 5;
            anLbl.Width = panel4.Width -5;
            ntLbl.Width = panel4.Width - 5;

            qnTB.Height = anLbl.Location.Y - qnTB.Top - 10;
            anTB.Height = ntLbl.Location.Y - anTB.Top - 10;
            ntTB.Height = panel4.Height - ntTB.Top - 10;

        }
        

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void printPreviewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics G = e.Graphics;
            e.PageSettings.Landscape = true;

            G.DrawString("Question:", new Font("Arial",70), Brushes.Black, new Rectangle(0,100,e.MarginBounds.Width,e.MarginBounds.Height));

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;

        }

    }
}
