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

namespace FlashcardsProgram
{
    public partial class TestView : Form
    {

    private int numberOfSwaps = 50; //enter the number of swaps. This will be dynamic at a later date, but static system will work for now.
    private bool buttonstuff = false;
    private int currentIndex = 0;
    private int correct = 0;
    private int questionCounter = 0;
    private Panel antiCheatingDevice = new Panel();
    private Point defaultCardSize;
    const int cardsBeforeBreak = 50;
    
    public List<Card> currentCardStack; //this is essentially a pointer towards the original data. We can use this to modify the scores at the end.
       
    private List<Card> quizCardStack = new List<Card>(); //this is the one we use for displaying - it means that we don't cause issues with original data.

    private Button[] ynButtons = new Button[2];

    SpVoice speechGenerator = new SpVoice();

    private Random rand = new Random();

    public TestView()
        {
            
            InitializeComponent();
        }
    


    private int generateNumberOfSwaps()
        {
            return (currentCardStack.Count / 2);
        }

    private void initialise()
        {
            
            
            for (int i = 0; i < currentCardStack.Count; i++)
            {
                quizCardStack.Add(currentCardStack[i]);
            }

            
            numberOfSwaps = generateNumberOfSwaps();

            

            System.Random randomGenerator = new System.Random();
            for (int i = 0; i < numberOfSwaps; i++)
            {
                
                //generate the random indexes, so we can do swaps (this means that we can make the quiz more random.)
                int j = randomGenerator.Next(quizCardStack.Count - 1);
                int k = randomGenerator.Next(quizCardStack.Count - 1);

                //carry out the swapping.
                Card temp = quizCardStack[j];
                quizCardStack[j] = quizCardStack[k];
                quizCardStack[k] = temp;


            }
            
            displayNewCard(quizCardStack[currentIndex]);
        }


    private void nextQuestion()
        {
            userInputTB.Enabled = true;
            questionCounter++;
            if (questionCounter >= cardsBeforeBreak)
            {
                questionCounter = 0;
             
                MessageBox.Show("You have completed " + cardsBeforeBreak + " cards! Grab a cup of coffee before continuing :)", "Health and Safety Officer");
                speechGenerator.Speak("Have a break before continuing!");
                questionCounter = 1;
            }

            answerPanel.Controls.Remove(ynButtons[0]);
            answerPanel.Controls.Remove(ynButtons[1]);

            if (ynButtons[0] != null)
            {

                ynButtons[0].Hide();
                ynButtons[1].Hide();

                ynButtons[0].Dispose();
                ynButtons[1].Dispose();

            }

            checkAnswerButton.Show();
            checkAnswerButton.Text = "Check";
            checkAnswerButton.Enabled = true;

            if (quizCardStack.Count != 0) {
            if (currentIndex < quizCardStack.Count - 1)
            {
                currentIndex += 1;
            }
            else
            {
                currentIndex = 0;
            }

            
            displayNewCard(quizCardStack[currentIndex]);
            userInputTB.Focus();
        }
            else
            {
                speechGenerator.Speak("You have completed this test!", SpeechVoiceSpeakFlags.SVSFlagsAsync);
                MessageBox.Show("You have completed the test. Well done! :D");
                this.Close();
            }
        }

    private void displayYNButtons()
        {
            //hide the check button, so that it cannot be clicked.
            checkAnswerButton.Hide();

            //create button objects
            ynButtons[0] = new Button();
            ynButtons[1] = new Button();

            //add this to the panel.

            answerPanel.Controls.Add(ynButtons[0]);
            answerPanel.Controls.Add(ynButtons[1]);

            //set location
            ynButtons[0].Location = new Point(checkAnswerButton.Location.X, checkAnswerButton.Location.Y);
            ynButtons[1].Location = new Point(checkAnswerButton.Location.X + (checkAnswerButton.Width / 2), checkAnswerButton.Location.Y);

            //Sets button 0 diemnsions.
            ynButtons[0].Width = Convert.ToInt32(0.5 * checkAnswerButton.Width);
            ynButtons[0].Height = checkAnswerButton.Height;

            //this sets button 1 dimensions. Takes up half of the button space
            ynButtons[1].Width = checkAnswerButton.Width;
            ynButtons[1].Height = checkAnswerButton.Height;

            ynButtons[0].Click += YButton_Click;
            ynButtons[1].Click += NButton_Click;

            ynButtons[0].KeyDown += TestView_KeyDown;
            ynButtons[1].KeyDown += TestView_KeyDown;

            //text to display (this will be changed to images later on.
            ynButtons[0].Text = "Y";
            ynButtons[1].Text = "N";
        }

    void TestView_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Y)
        {
            correctRoutine();
            buttonstuff = false;
            nextQuestion();

        }
        else if (e.KeyCode == Keys.N)
        {
            speechGenerator.Speak("Incorrect.", SpeechVoiceSpeakFlags.SVSFlagsAsync);
            currentCardStack[quizCardStack[currentIndex].index].score -= 1;
            buttonstuff = false;
            nextQuestion();
        }
        else if (e.KeyCode == Keys.Escape)
            this.Close();
    }

    void YButton_Click(object sender, EventArgs e)
        {
            //correct
            correctRoutine();
            
        }

    void NButton_Click(object sender, EventArgs e)
        {
            //incorrect
            speechGenerator.Speak("Incorrect.", SpeechVoiceSpeakFlags.SVSFlagsAsync);
            currentCardStack[quizCardStack[currentIndex].index].score -= 1;
            buttonstuff = false;
            nextQuestion();
            
        }

    void antiCheatingMethodHide()
    {
        userInputTB.Enabled = false; //prevent the user from inputting anything, thus changing their answer.
        antiCheatingDevice.Hide();
    }
    void antiCheatingMethodReveal()
    {

        

        antiCheatingDevice.BackColor = this.BackColor;
        antiCheatingDevice.BringToFront();
        
        cardPanel.Controls.Add(antiCheatingDevice);
        antiCheatingDevice.Width = cardPanel.Width;
        antiCheatingDevice.Height = cardPanel.Height - (questionLB.Top + questionLB.Height);

        antiCheatingDevice.Top = (questionLB.Top + questionLB.Height);
        antiCheatingDevice.Left = 0;
        
        antiCheatingDevice.Show();
        antiCheatingDevice.BringToFront();
    }
    private void displayNewCard(Card cardToDisplay)
        {
            
            questionLB.Text = cardToDisplay.Q;
            answerLB.Text = cardToDisplay.A;
            notesLB.Text = cardToDisplay.N;

            speechGenerator.Speak("question: " + cardToDisplay.Q,SpeechVoiceSpeakFlags.SVSFlagsAsync);
         
            userInputTB.Text = ""; //clear the input, so that people can easily enter text.
            userInputTB.Focus(); //put cursor in here, so that the next answer can be easily entered.
            userInputTB.Enabled = true;

            antiCheatingMethodReveal();

        }

    bool determineIfCorrect(string answer, string userInput)
        {
            if (answer.ToLower() == userInput.ToLower())
            {
                //correct
                return true;
            }
            else
            {
                return false;
            }
        }
    
    private void correctRoutine()
    {
        correct++;
        speechGenerator.Speak("Correct!", SpeechVoiceSpeakFlags.SVSFlagsAsync);
        try
        {
            currentCardStack[quizCardStack[currentIndex].index].score += 1;
            
        }
        catch
        {
            speechGenerator.Speak("Score not updated due to error.", SpeechVoiceSpeakFlags.SVSFlagsAsync);
        }

        if (rand.Next(10) < 9)
        {
            quizCardStack.RemoveAt(currentIndex);
        }

        speechGenerator.Speak("Answer: " + answerLB.Text,SpeechVoiceSpeakFlags.SVSFlagsAsync);


    }
    
    private void checkingRoutine()
    {

        antiCheatingMethodHide();

        bool correct = determineIfCorrect(quizCardStack[currentIndex].A, userInputTB.Text);

        if (correct)
        {
            correctRoutine();

        }
        else
        {
            
            displayYNButtons();
            userInputTB.Enabled = false;

        }
        buttonstuff = true;
        checkAnswerButton.Text = "Continue";
    }

    private void TestView_Load(object sender, EventArgs e)
        {
            defaultCardSize = new Point(this.Width / 2,this.Height / 2);
            cardPanel.Width = this.Width / 2;
            cardPanel.Height = this.Height / 2;
            cardPanel.Location = new Point(this.Width / 2 - cardPanel.Width / 2, (this.Height / 2) - (cardPanel.Height / 2)- answerPanel.Height);
            initialise();
        }

    private void button1_Click(object sender, EventArgs e)
        {
            if (buttonstuff)
            {
                buttonstuff = false;
                nextQuestion();
            }
            else
            {
                
                checkingRoutine();
                
            }
        }

    private void userInputTB_TextChanged(object sender, EventArgs e)
        {

        }

    private void userInputTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (buttonstuff)
                {
                    buttonstuff = false;
                    nextQuestion();
                }
                
                else
                    checkingRoutine();
            }
            else if (e.KeyCode == Keys.Escape)
                this.Close();
        }

    private void clockTimer_Tick(object sender, EventArgs e)
    {
            DateTime current = DateTime.Now;
            if (current.Minute < 10)
            {
                timeLBL.Text = current.Hour + ":0" + current.Minute;
            }
            else
            {
                timeLBL.Text = current.Hour + ":" + current.Minute;
            }
            label4.Text = "Correct: " + correct;
            label4.Text += " Remaining: " + quizCardStack.Count;
    }


    private void label4_Click(object sender, EventArgs e)
    {

    }

    
        
    }
}
