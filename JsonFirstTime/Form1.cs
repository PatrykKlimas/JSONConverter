using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace JsonFIrstTime
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region UI events

        private void Button_Deserialise_Click(object sender, EventArgs e)
        {
            //debugOutput(textInput.Text);
            deserialiseJSON(textInput.Text);
        }

        private void Button_Clear_Click(object sender, EventArgs e)
        {
            textOutput.Text = string.Empty;
        }

        #endregion

        #region JSON functions
        private void deserialiseJSON(string strJSON)
        {
            try
            {

                var jPerson = JsonConvert.DeserializeObject<dynamic>(strJSON);
                
                debugOutput("Here is the name: " + jPerson.name);
                debugOutput("Here is the surname: " + jPerson.surname);
                debugOutput("Here is the age: " + jPerson.age);
                debugOutput("Here are/is hobbies: ");

                //if we have hobbies
                try
                {
                    foreach (string item in jPerson.hobbies)
                    {
                        debugOutput(item.ToString());
                    }
                }
                catch(Exception ex)
                {
                    //do nothing
                }

                //if we have address
                try
                {
                    debugOutput("Here is the address: " + jPerson.address.city + ", " + jPerson.address.street + ", " + jPerson.address.code);
                }catch(Exception ex)
                {
                    //do nothing
                }


            }
            catch (Exception ex)
            {
                debugOutput("We have a problem: " + ex.Message.ToString());
            }
        }

        #endregion


        #region Debug Output

        private void debugOutput(string strDebugText)
        {
            try
            {
                textOutput.Text = textOutput.Text + strDebugText + Environment.NewLine;
                textOutput.SelectionStart = textOutput.TextLength;
                textOutput.ScrollToCaret();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message + Environment.NewLine);
            }

        }

        #endregion
    }
}
