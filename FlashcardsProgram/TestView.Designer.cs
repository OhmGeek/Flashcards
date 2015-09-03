namespace FlashcardsProgram
{
    partial class TestView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cardPanel = new System.Windows.Forms.Panel();
            this.questionLB = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.answerLB = new System.Windows.Forms.Label();
            this.notesLB = new System.Windows.Forms.Label();
            this.answerPanel = new System.Windows.Forms.Panel();
            this.checkAnswerButton = new System.Windows.Forms.Button();
            this.userPrompt = new System.Windows.Forms.Label();
            this.userInputTB = new System.Windows.Forms.TextBox();
            this.timeLBL = new System.Windows.Forms.Label();
            this.clockTimer = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cardPanel.SuspendLayout();
            this.answerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cardPanel
            // 
            this.cardPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cardPanel.Controls.Add(this.questionLB);
            this.cardPanel.Controls.Add(this.label1);
            this.cardPanel.Controls.Add(this.label3);
            this.cardPanel.Controls.Add(this.label2);
            this.cardPanel.Controls.Add(this.answerLB);
            this.cardPanel.Controls.Add(this.notesLB);
            this.cardPanel.Location = new System.Drawing.Point(164, 45);
            this.cardPanel.Name = "cardPanel";
            this.cardPanel.Size = new System.Drawing.Size(472, 280);
            this.cardPanel.TabIndex = 0;
            // 
            // questionLB
            // 
            this.questionLB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.questionLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionLB.Location = new System.Drawing.Point(3, 33);
            this.questionLB.Name = "questionLB";
            this.questionLB.Size = new System.Drawing.Size(466, 65);
            this.questionLB.TabIndex = 3;
            this.questionLB.Text = "text";
            this.questionLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(208, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Question:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(208, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Notes:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(208, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Answer:";
            // 
            // answerLB
            // 
            this.answerLB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.answerLB.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.answerLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answerLB.Location = new System.Drawing.Point(3, 136);
            this.answerLB.Name = "answerLB";
            this.answerLB.Size = new System.Drawing.Size(466, 48);
            this.answerLB.TabIndex = 4;
            this.answerLB.Text = "label5";
            this.answerLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // notesLB
            // 
            this.notesLB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.notesLB.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.notesLB.Location = new System.Drawing.Point(3, 229);
            this.notesLB.Name = "notesLB";
            this.notesLB.Size = new System.Drawing.Size(466, 48);
            this.notesLB.TabIndex = 5;
            this.notesLB.Text = "label6";
            this.notesLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // answerPanel
            // 
            this.answerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.answerPanel.BackColor = System.Drawing.Color.Peru;
            this.answerPanel.Controls.Add(this.checkAnswerButton);
            this.answerPanel.Controls.Add(this.userPrompt);
            this.answerPanel.Controls.Add(this.userInputTB);
            this.answerPanel.Location = new System.Drawing.Point(0, 360);
            this.answerPanel.Name = "answerPanel";
            this.answerPanel.Size = new System.Drawing.Size(779, 109);
            this.answerPanel.TabIndex = 1;
            // 
            // checkAnswerButton
            // 
            this.checkAnswerButton.Location = new System.Drawing.Point(642, 38);
            this.checkAnswerButton.Name = "checkAnswerButton";
            this.checkAnswerButton.Size = new System.Drawing.Size(126, 48);
            this.checkAnswerButton.TabIndex = 2;
            this.checkAnswerButton.Text = "Check";
            this.checkAnswerButton.UseVisualStyleBackColor = true;
            this.checkAnswerButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // userPrompt
            // 
            this.userPrompt.AutoSize = true;
            this.userPrompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userPrompt.Location = new System.Drawing.Point(286, 14);
            this.userPrompt.Name = "userPrompt";
            this.userPrompt.Size = new System.Drawing.Size(172, 20);
            this.userPrompt.TabIndex = 1;
            this.userPrompt.Text = "What is the answer?";
            // 
            // userInputTB
            // 
            this.userInputTB.Font = new System.Drawing.Font("Comic Sans MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInputTB.Location = new System.Drawing.Point(78, 38);
            this.userInputTB.Name = "userInputTB";
            this.userInputTB.Size = new System.Drawing.Size(555, 48);
            this.userInputTB.TabIndex = 0;
            this.userInputTB.TextChanged += new System.EventHandler(this.userInputTB_TextChanged);
            this.userInputTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userInputTB_KeyDown);
            // 
            // timeLBL
            // 
            this.timeLBL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeLBL.AutoSize = true;
            this.timeLBL.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLBL.Location = new System.Drawing.Point(670, 9);
            this.timeLBL.Name = "timeLBL";
            this.timeLBL.Size = new System.Drawing.Size(98, 38);
            this.timeLBL.TabIndex = 2;
            this.timeLBL.Text = "16:12";
            // 
            // clockTimer
            // 
            this.clockTimer.Enabled = true;
            this.clockTimer.Tick += new System.EventHandler(this.clockTimer_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 16.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(253, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "Correct and Remaining:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // TestView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(780, 471);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.timeLBL);
            this.Controls.Add(this.answerPanel);
            this.Controls.Add(this.cardPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TestView";
            this.Text = "TestView";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TestView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TestView_KeyDown);
            this.cardPanel.ResumeLayout(false);
            this.cardPanel.PerformLayout();
            this.answerPanel.ResumeLayout(false);
            this.answerPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel cardPanel;
        private System.Windows.Forms.Panel answerPanel;
        private System.Windows.Forms.Label userPrompt;
        private System.Windows.Forms.TextBox userInputTB;
        private System.Windows.Forms.Button checkAnswerButton;
        private System.Windows.Forms.Label notesLB;
        private System.Windows.Forms.Label answerLB;
        private System.Windows.Forms.Label questionLB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label timeLBL;
        private System.Windows.Forms.Timer clockTimer;
        private System.Windows.Forms.Label label4;
    }
}