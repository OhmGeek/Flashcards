using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlashcardsProgram
{
    public partial class CustomTextBoxControl : TextBox
    {

        public override string Text
        {
            get
            {
               
                return base.Text.Replace(System.Environment.NewLine, ""); 
            }
            set
            {
                base.Text = value;
            }
        }
        
        public CustomTextBoxControl()
        {
            InitializeComponent();
        }


        
    }
}
