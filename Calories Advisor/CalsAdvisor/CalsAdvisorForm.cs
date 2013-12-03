using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CalsAdvisor.ApplicationLayer;
using CalsAdvisor.DataLayer;

namespace CalsAdvisor
{
    public partial class CalsAdvisorForm : Form
    {
		AppLayer CaloriesApplication;
        ProfileControl Prediction;
        bool NewDayPanel_WeightLinkButton = true;
        public CalsAdvisorForm()
        {
            InitializeComponent();
			
			CaloriesApplication = new AppLayer();

        }

        private void CalsAdvisorForm_Load(object sender, EventArgs e)
        {
			

            //Change For Cheker of Profile
            ShowPanel("HideAll");


            CaloriesApplication.LoadProfile();
            if (CaloriesApplication.Person != null)
            {

                ShowPanel("panel_Profile");
				comboBox_ProfileSelection.Text = CaloriesApplication.Person.LastName + ", " + CaloriesApplication.Person.FirstName;
                
            }
            else
            {
                button_Menu_Profile.Enabled = false;
                button_Menu_NewDay.Enabled = false;
                button_Menu_Prediction.Enabled = false;
                ShowPanel("Panel_CreateProfile");
            }


        }


        #region //Starts *****************Windows Form Gui stuff*********************************************************************** (Extra stuff, Hover etc?


        private void button_Menu_Profile_MouseEnter(object sender, EventArgs e)
        {
            //Changes when Mouse Hoovers the button

            //button_Menu_Profile.FlatAppearance.BorderSize = 1;
            button_Menu_Profile.ImageIndex = 1;

        }

        private void button_Menu_Profile_MouseLeave_1(object sender, EventArgs e)
        {
            //Changes when Mouse moves out of button

            //button_Menu_Profile.FlatAppearance.BorderSize = 0; //Change size
            button_Menu_Profile.ImageIndex = 0;

        }

        private void button_Menu_NewDay_MouseEnter(object sender, EventArgs e)
        {
            //Changes when Mouse Hoovers the button

            // button_Menu_NewDay.FlatAppearance.BorderSize = 1;
            button_Menu_NewDay.ImageIndex = 3;
        }

        private void button_Menu_NewDay_MouseLeave_1(object sender, EventArgs e)
        {
            //Changes when Mouse moves out of button


            // button_Menu_NewDay.FlatAppearance.BorderSize = 0; //Change size
            button_Menu_NewDay.ImageIndex = 2; //Change Image		
        }

        private void button_Menu_Prediction_MouseEnter(object sender, EventArgs e)
        {

            //Changes when Mouse Hoovers the button

            //button_Menu_Prediction.FlatAppearance.BorderSize = 1;
            button_Menu_Prediction.ImageIndex = 5;
        }

        private void button_Menu_Prediction_MouseLeave_1(object sender, EventArgs e)
        {

            //Changes when Mouse moves out of button

            //button_Menu_Prediction.FlatAppearance.BorderSize = 0; //Change size
            button_Menu_Prediction.ImageIndex = 4;
        }


        #region //PROFILE SUMMARY PANEL HOVER EFFECTS
        private void panel9_MouseEnter(object sender, EventArgs e)
        {
            //    panel8.BackColor = System.Drawing.SystemColors.ControlDark;
            //    panel3.BackColor = System.Drawing.SystemColors.ControlDark;
            //    panel12.BackColor = System.Drawing.SystemColors.ControlDark;
        }

        private void panel9_MouseLeave(object sender, EventArgs e)
        {
            //panel8.BackColor = System.Drawing.SystemColors.Control;
            //panel3.BackColor = System.Drawing.SystemColors.Control;
            //panel12.BackColor = System.Drawing.SystemColors.Control;

        }

        private void panel8_MouseEnter(object sender, EventArgs e)
        {
            //panel9.BackColor = System.Drawing.SystemColors.ControlDark;
            //panel3.BackColor = System.Drawing.SystemColors.ControlDark;
            //panel12.BackColor = System.Drawing.SystemColors.ControlDark;
        }

        private void panel8_MouseLeave(object sender, EventArgs e)
        {
            //panel9.BackColor = System.Drawing.SystemColors.Control;
            //panel3.BackColor = System.Drawing.SystemColors.Control;
            //panel12.BackColor = System.Drawing.SystemColors.Control;
        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            //panel9.BackColor = System.Drawing.SystemColors.ControlDark;
            //panel8.BackColor = System.Drawing.SystemColors.ControlDark;
            //panel12.BackColor = System.Drawing.SystemColors.ControlDark;
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            //panel9.BackColor = System.Drawing.SystemColors.Control;
            //panel8.BackColor = System.Drawing.SystemColors.Control;
            //panel12.BackColor = System.Drawing.SystemColors.Control;
        }

        private void panel12_MouseEnter(object sender, EventArgs e)
        {
            //panel9.BackColor = System.Drawing.SystemColors.ControlDark;
            //panel8.BackColor = System.Drawing.SystemColors.ControlDark;
            //panel3.BackColor = System.Drawing.SystemColors.ControlDark;
        }

        private void panel12_MouseLeave(object sender, EventArgs e)
        {
            //panel9.BackColor = System.Drawing.SystemColors.Control;
            //panel8.BackColor = System.Drawing.SystemColors.Control;
            //panel3.BackColor = System.Drawing.SystemColors.Control;
        }
        #endregion

        private void panel3_Click(object sender, EventArgs e)
        {
            panel3.BackColor = System.Drawing.SystemColors.Control;
            panel9.BackColor = System.Drawing.SystemColors.ControlDark;
            panel8.BackColor = System.Drawing.SystemColors.ControlDark;
            panel12.BackColor = System.Drawing.SystemColors.ControlDark;

        }

        private void panel8_Click(object sender, EventArgs e)
        {
            panel8.BackColor = System.Drawing.SystemColors.Control;
            panel9.BackColor = System.Drawing.SystemColors.ControlDark;
            panel12.BackColor = System.Drawing.SystemColors.ControlDark;
            panel3.BackColor = System.Drawing.SystemColors.ControlDark;
        }

        private void panel12_Click(object sender, EventArgs e)
        {
            panel12.BackColor = System.Drawing.SystemColors.Control;
            panel9.BackColor = System.Drawing.SystemColors.ControlDark;
            panel8.BackColor = System.Drawing.SystemColors.ControlDark;
            panel3.BackColor = System.Drawing.SystemColors.ControlDark;
        }

        private void panel9_Click(object sender, EventArgs e)
        {
            panel9.BackColor = System.Drawing.SystemColors.Control;
            panel8.BackColor = System.Drawing.SystemColors.ControlDark;
            panel3.BackColor = System.Drawing.SystemColors.ControlDark;
            panel12.BackColor = System.Drawing.SystemColors.ControlDark;
        }


        private void panel_Profile_MouseClick(object sender, MouseEventArgs e)
        {
            panel9.BackColor = System.Drawing.SystemColors.Control;
            panel8.BackColor = System.Drawing.SystemColors.Control;
            panel3.BackColor = System.Drawing.SystemColors.Control;
            panel12.BackColor = System.Drawing.SystemColors.Control;
        }
        private void panel6_Click(object sender, EventArgs e)
        {
            panel9.BackColor = System.Drawing.SystemColors.Control;
            panel8.BackColor = System.Drawing.SystemColors.Control;
            panel3.BackColor = System.Drawing.SystemColors.Control;
            panel12.BackColor = System.Drawing.SystemColors.Control;
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            panel9.BackColor = System.Drawing.SystemColors.Control;
            panel8.BackColor = System.Drawing.SystemColors.Control;
            panel3.BackColor = System.Drawing.SystemColors.Control;
            panel12.BackColor = System.Drawing.SystemColors.Control;
        }



        #endregion//Ends  *****************Windows Form Gui stuff***********************************************************************


        //Methods*******************************************************************************************************************************
       


        void ShowPanel(string PanelToShow)
        {

            //Hide Every Panel
            Panel_CreateProfile.Visible = false;
            panel_Profile.Visible = false;
            panel_NewDay.Visible = false;
            panel_Prediction.Visible = false;
            Panel_Options.Visible = false;
            panel_Help.Visible = false;



            //Show Passed Panel
            switch (PanelToShow)
            {
                case "HideAll":
                    break;
                case "Panel_CreateProfile":
                    Panel_CreateProfile.Visible = true;
                    comboBox_CreateProfile_ActivityLevel.SelectedIndex = 1;
                    break;
                case "panel_Profile":
                    panel_Profile.Visible = true;
                    UpdateProfileSummary();
                    break;
                case "panel_NewDay":
                    panel_NewDay.Visible = true;
                    groupBox_NewDay_WeightUpdate.Enabled = false;
                    button_NewDay_FinishDay.Enabled = true;
                    textbox_NewDay_AddCaloriesPerMeal.Enabled = true;
                    CaloriesApplication.SumOfCaloriesAday = CaloriesApplication.Person.SumOfCaloriesHolder;
                    textbox_NewDay_CaloriesConsumed.Text = CaloriesApplication.SumOfCaloriesAday.ToString();
                    ComboBox_NewDay_CurrentActivityLevel.SelectedIndex = 1;
                    break;
                case "panel_Prediction":
                    panel_Prediction.Visible = true;
                    panel_Prediction_LOADING.Visible = false;
                    break;
                case "Panel_Options":
                    Panel_Options.Visible = true;
                    break;
                case "panel_Help":
                    panel_Help.Visible = true;
                    break;



            }// END SWITCH			

        }// END SHOWPANEL()

        void UpdateProfileSummary()
        {
            //User Info Panel
            label_Profile_CompleteName.Text = CaloriesApplication.Person.FirstName.ToString() + " " + CaloriesApplication.Person.LastName.ToString();
            label_Profile_Age.Text = CaloriesApplication.Person.Age.ToString();
            if (CaloriesApplication.Person.Gender == true)
            {
                label_Profile_Gender.Text = "Male";
            }
            else if (CaloriesApplication.Person.Gender == false)
            {
                label_Profile_Gender.Text = "Female";
            }
            label_Profile_HeightFoot.Text = CaloriesApplication.Person.HeightFoot.ToString();
            label_Profile_HeightInches.Text = CaloriesApplication.Person.HeightInches.ToString();

            //Initial Panel
			label_Profile_Initial_Weight.Text = CaloriesApplication.Person.InitialProfile.Weight.ToString("F2");
			label_Profile_Initial_ActivityLevel.Text = CaloriesApplication.Person.InitialProfile.ActivityLevel.ToString();
			label_Profile_Initial_BRMWithoutActivity.Text = CaloriesApplication.Person.InitialProfile.BMR.ToString("F2");
			label_Profile_Initial_BRMwithActivity.Text = CaloriesApplication.Person.InitialProfile.BMR_Physical.ToString("F2");
			label_Profile_Initial_BMI.Text = CaloriesApplication.Person.InitialProfile.BMI.ToString("F2");
            label_Profile_Initial_BMIstatus.Text = CaloriesApplication.Person.InitialBMIstatus;
            label_Profile_Initial_Date.Text = CaloriesApplication.Person.InitialDate.ToString();

            //BMI Tracker Panel
			label_Profile_bmiTracker_CurrentBMI.Text = CaloriesApplication.Person.CurrentProfile.BMI.ToString("F2");
			label_Profile_bmiTracker_CurrentWeight.Text = CaloriesApplication.Person.CurrentProfile.Weight.ToString("F2");
			label_Profile_bmiTracker_IdealWeightHigh.Text = CaloriesApplication.Person.IdealWeightHigh.ToString("F2");
			label_Profile_bmiTracker_IdealWeightLow.Text = CaloriesApplication.Person.IdealWeightLow.ToString("F2");
            label_Profile_BMITRACKER_Status.Text = CaloriesApplication.Person.CurrentBMIstatus.ToString();


            if (CaloriesApplication.Person.CurrentBMIstatus == "Obese")
            {
                label_Profile_BMITRACKER_Status.ForeColor = Color.Red;
            }
            else if (CaloriesApplication.Person.CurrentBMIstatus == "Overweight")
            {
                label_Profile_BMITRACKER_Status.ForeColor = Color.Yellow;
            }
            else if (CaloriesApplication.Person.CurrentBMIstatus == "Healthy")
            {
                label_Profile_BMITRACKER_Status.ForeColor = Color.Green;
            }
            else if (CaloriesApplication.Person.CurrentBMIstatus == "UnderWeight")
            {
                label_Profile_BMITRACKER_Status.ForeColor = Color.Gray;
            }
            else
            {
                label_Profile_BMITRACKER_Status.ForeColor = Color.White;
            }




            //Current Panel
            label_Profile_Current_Date.Text = CaloriesApplication.Person.CurrentDate.ToString();
            label_Profile_Current_Day.Text = CaloriesApplication.Person.daysPassed.ToString();
			label_Profile_Current_Weight.Text = CaloriesApplication.Person.CurrentProfile.Weight.ToString("F2");
			label_Profile_Current_CaloriesConsumed.Text = CaloriesApplication.Person.CurrentProfile.CaloriesConsumedToday.ToString("F2");
			label_Profile_Current_PoundLost.Text = CaloriesApplication.Person.PoundLost.ToString("F2");
			label_Profile_Current_BRMwithActivity.Text = CaloriesApplication.Person.CurrentProfile.BMR_Physical.ToString("F2");
			label_Profile_Current_BRMwithoutActivity.Text = CaloriesApplication.Person.CurrentProfile.BMR.ToString("F2");
            label_Profile_Current_BMI.Text = CaloriesApplication.Person.CurrentProfile.BMI.ToString("F2");
            label_Profile_Current_BMIstatus.Text = CaloriesApplication.Person.CurrentBMIstatus.ToString();
            label_Profile_Current_ActivityLevel.Text = CaloriesApplication.Person.CurrentProfile.ActivityLevel.ToString();
        }

        //METHODS END *************************************************************************************************




        //EVENTS DELEGATES***********************************************************************************************
        //MENU................................................................................

        #region //Click Events from GUi
        private void button_CreateNewProfileTop_Click(object sender, EventArgs e)
        {
            ShowPanel("Panel_CreateProfile");

        }

        private void button_Menu_Profile_Click(object sender, EventArgs e)
        {
            ShowPanel("panel_Profile");
        }

        private void button_Menu_NewDay_Click(object sender, EventArgs e)
        {
            ShowPanel("panel_NewDay");
        }

        private void button_Menu_Prediction_Click(object sender, EventArgs e)
        {
            ShowPanel("panel_Prediction");

            if (Prediction == null)
            {


                textBox_Prediction_FirstName.Text = CaloriesApplication.Person.FirstName.ToString();
                textBox_Prediction_LastName.Text = CaloriesApplication.Person.LastName.ToString();
                if (CaloriesApplication.Person.Gender == true)
                {
                    radioButton_Prediction_GenderMale.Checked = true;
                }
                else if (CaloriesApplication.Person.Gender == false)
                {
                    radioButton_Prediction_GenderFemale.Checked = true; ;
                }
                textBox_Prediction_HeightFeets.Text = CaloriesApplication.Person.HeightFoot.ToString();
                textBox_Prediction_HeightInches.Text = CaloriesApplication.Person.HeightInches.ToString();
                textBox_Prediction_Age.Text = CaloriesApplication.Person.Age.ToString();
				textBox_Prediction_Weight.Text = Convert.ToInt32(CaloriesApplication.Person.CurrentProfile.Weight).ToString();
                comboBox_Prediction_ActivityLevel.SelectedIndex = 1;
				textBox_Prediction_CaloriesPerDay_Min.Text = "1200";
				textBox_Prediction_CaloriesPerDay_Max.Text = "2000";
				textBox_Prediction_DaysToRun.Text = "90";
            }
            else
            {
                textBox_Prediction_FirstName.Text = Prediction.FirstName.ToString();
                textBox_Prediction_LastName.Text = Prediction.LastName.ToString();
                if (Prediction.Gender == true)
                {
                    radioButton_Prediction_GenderMale.Checked = true;
                }
                else if (Prediction.Gender == false)
                {
                    radioButton_Prediction_GenderFemale.Checked = true; ;
                }
                textBox_Prediction_HeightFeets.Text = Prediction.HeightFoot.ToString();
                textBox_Prediction_HeightInches.Text = Prediction.HeightInches.ToString();
                textBox_Prediction_Age.Text = Prediction.Age.ToString();
				textBox_Prediction_Weight.Text = Convert.ToInt32(CaloriesApplication.Person.CurrentProfile.Weight).ToString();
                comboBox_Prediction_ActivityLevel.SelectedIndex = 1;
				textBox_Prediction_CaloriesPerDay_Min.Text = "1200";
				textBox_Prediction_CaloriesPerDay_Max.Text = "2000";
				textBox_Prediction_DaysToRun.Text = "90";


            }



        }
        //EndOfMenu..........................................................................

        private void button_CreateProfile_Create_Click(object sender, EventArgs e)
        {
            try
            {

                CaloriesApplication.m_firstName = textBox_CreateProfile_FirstName.Text;
                CaloriesApplication.m_lastName = textBox_CreateProfile_LastName.Text;
                CaloriesApplication.m_age = int.Parse(textBox_CreateProfile_Age.Text);
                CaloriesApplication.m_weight = double.Parse(textBox_CreateProfile_Weight.Text);
                CaloriesApplication.m_heightFoots = int.Parse(textBox_CreateProfile_Height_Feets.Text);
                CaloriesApplication.m_heightInches = int.Parse(textBox_CreateProfile_Height_Inches.Text);
                if (radioButton_CreateProfile_Gender_Male.Checked)
                {
                    CaloriesApplication.m_gender_trueMale_FalseFemale = true;
                }
                else if (radioButton_CreateProfile_Gender_Female.Checked)
                {
                    CaloriesApplication.m_gender_trueMale_FalseFemale = false;
                }
                CaloriesApplication.m_activityLevel = double.Parse(comboBox_CreateProfile_ActivityLevel.SelectedItem.ToString());

                CaloriesApplication.CreateNewProfile();
                ShowPanel("panel_Profile");
                comboBox_ProfileSelection.Text = CaloriesApplication.Person.LastName + ", " + CaloriesApplication.Person.FirstName;
                button_Menu_Profile.Enabled = true;
                button_Menu_NewDay.Enabled = true;
                button_Menu_Prediction.Enabled = true;
                CaloriesApplication.Person.SumOfCaloriesHolder = 0;
            }
            catch
            {
                MessageBox.Show("Wrong Information", "Formatting Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linklabel_NewDay_WeightUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (NewDayPanel_WeightLinkButton == true)
            {
                groupBox_NewDay_WeightUpdate.Enabled = true;
                NewDayPanel_WeightLinkButton = false;
                button_NewDay_FinishDay.Enabled = false;
                textbox_NewDay_AddCaloriesPerMeal.Enabled = false;



            }
            else
            {
                groupBox_NewDay_WeightUpdate.Enabled = false;
                NewDayPanel_WeightLinkButton = true;
                button_NewDay_FinishDay.Enabled = true;
                textbox_NewDay_AddCaloriesPerMeal.Enabled = true;

            }
        }
        //Error - text is actually a button (dont change or the project will be broken)
        private void textbox_NewDay_AddCaloriesPerMeal_Click(object sender, EventArgs e)
        {
            try
            {

				CaloriesApplication.SumOfCaloriesAday += double.Parse(textbox_NewDay_CaloriesperMeal.Text.ToString());
                textbox_NewDay_CaloriesConsumed.Text = CaloriesApplication.SumOfCaloriesAday.ToString();
                CaloriesApplication.Person.SumOfCaloriesHolder = CaloriesApplication.SumOfCaloriesAday;
                CaloriesApplication.SaveProfile();

            }
            catch 
            {
                MessageBox.Show("Formatting Issue", "FORMAT ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button_NewDay_FinishDay_Click(object sender, EventArgs e)
        {
            try
            {
                CaloriesApplication.SumOfCaloriesAday = double.Parse(textbox_NewDay_CaloriesConsumed.Text.ToString());
                CaloriesApplication.CaloriesConsumedTextBox = CaloriesApplication.SumOfCaloriesAday;
                CaloriesApplication.Person.CurrentProfile.ActivityLevel = double.Parse(ComboBox_NewDay_CurrentActivityLevel.SelectedItem.ToString());
                bool holder = CaloriesApplication.FinishDayCalories();
                if (holder == true)
                {
                    MessageBox.Show("Calories added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Opps, try again", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                ShowPanel("panel_Profile");
                CaloriesApplication.Person.SumOfCaloriesHolder = 0;

            }
            catch
            {

                MessageBox.Show("Formatting Issue", "FORMAT ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Weight end day
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                CaloriesApplication.WeightTextBox = double.Parse(textbox_NewDay_Weight.Text.ToString());
                bool holder = CaloriesApplication.FinishDayWeight();
                if (holder == true)
                {
                    MessageBox.Show("Weight added succesfully, going to Profile", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Something Went Wrong Saving", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                ShowPanel("panel_Profile");
                CaloriesApplication.Person.SumOfCaloriesHolder = 0;
            }
            catch
            {

                MessageBox.Show("Please write numbers only! (No characters)", "FORMAT ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void button_CreateProfile_Cancel_Click(object sender, EventArgs e)
        {
            ShowPanel("HideAll");
        }

        private void button_Prediction_Predict_Click(object sender, EventArgs e)
        {
            try
            {

                panel_Prediction_LOADING.Visible = true;
                string firstN = textBox_Prediction_FirstName.Text.ToString();
                string lastN = textBox_Prediction_LastName.Text.ToString();
                int a_age = int.Parse(textBox_Prediction_Age.Text.ToString());
                int Feets = int.Parse(textBox_Prediction_HeightFeets.Text.ToString());
                int inches = int.Parse(textBox_Prediction_HeightInches.Text.ToString());
                bool gender = radioButton_Prediction_GenderMale.Checked;
                double w_weight = double.Parse(textBox_Prediction_Weight.Text);
                double AL = double.Parse(comboBox_Prediction_ActivityLevel.SelectedItem.ToString());

                Prediction = new ProfileControl(firstN, lastN, a_age, Feets, inches, gender, w_weight, AL);



                int CaloriesCon = 0;
                int MinCals = int.Parse(textBox_Prediction_CaloriesPerDay_Min.Text);
                int MaxCals = int.Parse(textBox_Prediction_CaloriesPerDay_Max.Text);
                int DaysToPredict = int.Parse(textBox_Prediction_DaysToRun.Text);



                label_Prediction_Name.Text = Prediction.FirstName.ToString() + " " + Prediction.LastName.ToString();
                label_Prediction_Age.Text = Prediction.Age.ToString();
                if (Prediction.Gender == true)
                {
                    label_Prediction_Gender.Text = "Male";
                }
                else if (Prediction.Gender == false)
                {
                    label_Prediction_Gender.Text = "Female";
                }
                label_Prediction_HeightFeets.Text = Prediction.HeightFoot.ToString();
                label_Prediction_HeightInches.Text = Prediction.HeightInches.ToString();
                label_Prediction_ActivityLevel.Text = Prediction.CurrentProfile.ActivityLevel.ToString();



                // Loop Initial
				label_Prediction_Weight_Initial.Text = Prediction.InitialProfile.Weight.ToString("F2");
                label_Prediction_PoundLost_Initial.Text = "0";
				label_Prediction_BMI_Initial.Text = Prediction.InitialProfile.BMI.ToString("F2");
				label_Prediction_Status_Initial.Text = Prediction.InitialBMIstatus.ToString();
                label_Prediction_BRM_Initial.Text =  Prediction.InitialProfile.BMR.ToString("F2");
				label_Prediction_BRMphysical_Initial.Text = Prediction.InitialProfile.BMR_Physical.ToString("F2");
                label_Prediction_DaysPassed.Text = DaysToPredict.ToString();

                richTextBox_Prediction_Results.Text = "";

                Font FontHeader = new Font("Calibri", (float)14.00, FontStyle.Regular);
                Font FontTitles = new Font("Calibri", (float)9.00, FontStyle.Bold);
                Font FontResults = new Font("Calibri", (float)8.00, FontStyle.Bold);
                Color ColorHeader = Color.White;
                Color HighLightHeader = Color.MidnightBlue;
                Color ColorTitle = Color.Maroon;
                Color ColorResults = Color.Black;

                richTextBox_Prediction_Results.SelectionFont = FontHeader;
                richTextBox_Prediction_Results.SelectionColor = ColorHeader;
                richTextBox_Prediction_Results.Text = "Prediction for " + DaysToPredict + " days..." + Environment.NewLine + "Calories Range of " + MinCals.ToString() + " to " + MaxCals + Environment.NewLine + Environment.NewLine + Environment.NewLine;
             
                
                for (int i = 1; i <= DaysToPredict; i++)
                {

                    CaloriesCon = StaticUtilities.RandomValue(MinCals, MaxCals);
                    Prediction.NewDay(CaloriesCon);


                    ////////////////// Formating


                    richTextBox_Prediction_Results.SelectionFont = FontHeader;
                    richTextBox_Prediction_Results.SelectionColor = ColorHeader;
                    richTextBox_Prediction_Results.SelectionBackColor = HighLightHeader;

                    richTextBox_Prediction_Results.SelectedText += System.Environment.NewLine + "Day:  " + i + "\t\t\t\t\t\tCalories Consumed Today:   " + CaloriesCon.ToString() + "      " + Environment.NewLine + Environment.NewLine;





                    ///////////////////////////////////////////////////////////////////////////////////////////
                    richTextBox_Prediction_Results.SelectionFont = FontTitles;
                    richTextBox_Prediction_Results.SelectionColor = ColorTitle;

                    richTextBox_Prediction_Results.SelectedText += "\tWeight:\t";

                    richTextBox_Prediction_Results.SelectionFont = FontResults;
                    richTextBox_Prediction_Results.SelectionColor = ColorResults;

                    richTextBox_Prediction_Results.SelectedText += Prediction.CurrentProfile.Weight.ToString();

                    richTextBox_Prediction_Results.SelectionFont = FontTitles;
                    richTextBox_Prediction_Results.SelectionColor = ColorTitle;

                    richTextBox_Prediction_Results.SelectedText += "\t\tPound Lost:\t";

                    richTextBox_Prediction_Results.SelectionFont = FontResults;
                    richTextBox_Prediction_Results.SelectionColor = ColorResults;

                    richTextBox_Prediction_Results.SelectedText += Prediction.PoundLost.ToString() + System.Environment.NewLine + System.Environment.NewLine;

                    //////////////////////////////////////////////////////////



                    richTextBox_Prediction_Results.SelectionFont = FontTitles;
                    richTextBox_Prediction_Results.SelectionColor = ColorTitle;

                    richTextBox_Prediction_Results.SelectedText += "\tBMI:\t";

                    richTextBox_Prediction_Results.SelectionFont = FontResults;
                    richTextBox_Prediction_Results.SelectionColor = ColorResults;

                    richTextBox_Prediction_Results.SelectedText += Prediction.CurrentProfile.BMI.ToString();

                    richTextBox_Prediction_Results.SelectionFont = FontTitles;
                    richTextBox_Prediction_Results.SelectionColor = ColorTitle;

                    richTextBox_Prediction_Results.SelectedText += "\t\tStatus:\t\t";

                    richTextBox_Prediction_Results.SelectionFont = FontResults;
                    richTextBox_Prediction_Results.SelectionColor = ColorResults;

                    richTextBox_Prediction_Results.SelectedText += Prediction.CurrentBMIstatus.ToString() + System.Environment.NewLine + System.Environment.NewLine;

                    //////////////////////////////////////////////////////////////////////

                    richTextBox_Prediction_Results.SelectionFont = FontTitles;
                    richTextBox_Prediction_Results.SelectionColor = ColorTitle;

                    richTextBox_Prediction_Results.SelectedText += "\tBRM:\t";

                    richTextBox_Prediction_Results.SelectionFont = FontResults;
                    richTextBox_Prediction_Results.SelectionColor = ColorResults;

                    richTextBox_Prediction_Results.SelectedText += Prediction.CurrentProfile.BMR.ToString();

                    richTextBox_Prediction_Results.SelectionFont = FontTitles;
                    richTextBox_Prediction_Results.SelectionColor = ColorTitle;

                    richTextBox_Prediction_Results.SelectedText += "\t\tBRM With Physical: ";

                    richTextBox_Prediction_Results.SelectionFont = FontResults;
                    richTextBox_Prediction_Results.SelectionColor = ColorResults;

                    richTextBox_Prediction_Results.SelectedText += Prediction.CurrentProfile.BMR_Physical.ToString() + System.Environment.NewLine + System.Environment.NewLine;



                }

				label_Prediction_Weight_Final.Text = Prediction.CurrentProfile.Weight.ToString("F2");
				label_Prediction_PoundLost_Final.Text = Prediction.PoundLost.ToString("F2");
				label_Prediction_BMI_Final.Text = Prediction.CurrentProfile.BMI.ToString("F2");
                label_Prediction_Status_Final.Text = Prediction.CurrentBMIstatus.ToString();
				label_Prediction_BRM_Final.Text = Prediction.CurrentProfile.BMR.ToString("F2");
				label_Prediction_BRMphysical_Final.Text = Prediction.CurrentProfile.BMR_Physical.ToString("F2");
                panel_Prediction_LOADING.Visible = false;
            }
            catch
            {
                panel_Prediction_LOADING.Visible = false;
                MessageBox.Show("Please Correct your information.", "FORMATING ERROR...", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CaloriesApplication.Person.SumOfCaloriesHolder = 0;
            CaloriesApplication.SumOfCaloriesAday = CaloriesApplication.Person.SumOfCaloriesHolder;
            textbox_NewDay_CaloriesConsumed.Text = CaloriesApplication.SumOfCaloriesAday.ToString();
            CaloriesApplication.SaveProfile();
        }

        private void ConextMenu_SaveProfile_Click(object sender, EventArgs e)
        {
            CaloriesApplication.SaveTextProfileInformation();
        }

        private void ConextMenu_SavePredictionResults_Click(object sender, EventArgs e)
        {
            CaloriesApplication.SaveTextPredictionInformation(ref Prediction, ref richTextBox_Prediction_Results);
        }

        private void button_OptionsTop_Click(object sender, EventArgs e)
        {
            ShowPanel("Panel_Options");
        }

        private void button_HelpTop_Click(object sender, EventArgs e)
        {
            ShowPanel("panel_Help");
        }

        private void ConextMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ConextMenu_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ConextMenu_Properties_Click(object sender, EventArgs e)
        {
            ShowPanel("Panel_Options");
        }

        private void ConextMenu_help_Click(object sender, EventArgs e)
        {
            ShowPanel("panel_Help");
        }

		private void Panel_Options_Paint(object sender, PaintEventArgs e)
		{

		}

     

    } //Ends Class
}//Ends Namespace
