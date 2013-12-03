using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
///Anastacio Gianareas
///6/16/2010
///Calorie Advisor
///General Purpose: software that tracks calories intake and reduction (Basic for personal use)
///File Purpose: Profile Class controls all the aspects of the person instance. Everything will be store here.
///                                    No Inheritance just a basic class. Can be exapanded with polumorphism.
///Open Source except for pro version


namespace CalsAdvisor
{
	public class Profile
	{

		//Constructor
		public Profile(string FirstName, string LastName, int age, int heightFoots, int HeightInches, bool gender_trueMale_FalseFemale, double weight, double activityLevel )
		{
			M_FIRST_TIME = true; //turns the update method to run the Initial History

			m_FirstName = FirstName;
			m_LastName = LastName;
			m_Age = age;
			m_HeightFoot = heightFoots;
			m_HeightInches = HeightInches;
			m_Gender = gender_trueMale_FalseFemale;
			m_Weight_DontUse = weight;
			m_Current_Activity_Level = activityLevel;
			m_Current_Calories_Consumed = 0;
		}




		///Variable Members
		///All public and accesed via properties (using m_ notation for consistency with c++) *iT IS COMMENTED IN ORDER TO USE PROPERTIES (USE THIS FOR PERFORMANCE)


		/// <summary>
		/// Initial Information of the profile when being created 
		/// </summary>
		public string m_FirstName;                                                                         ///Name of the person for displaying
		public string m_LastName;                                                                         ///Last name for next iteration 
		public int m_Age;                                                                                    ///Age used for calculations. May change
		public int m_HeightFoot, m_HeightInches;                                       ///HeightFoot * 12 + HeightInches... EX. 5" 7'     ---> 5*12 = 60 ----> 60 + 7 = 67
		public int m_HeightInInches;                                                              ///Stores the value for quick operation 
		
		public bool m_Gender;                                                                            /// True - Male , False = female
		public double m_Weight_DontUse;                                                          ///For storing when the object is created. It will copy to CurrentWeight and if it first time to InitialWeight. This is kept for editing options of the profile




		///<summary>
		///For Creation control (internally by constructor and update)
		/// </summary>    
		public bool M_FIRST_TIME;                                                                       ///Used by constructor when adding all the data so when the update() is called it knows that needs to calculate the new information


		/// <summary>
		/// Initial Data of the profile (It is kept for the lifetime of the profile or unless the player desides to restart the tracking)
		/// Purpose: use to compare since begining to current timeframe
		///  </summary>
		public double m_Initial_BMI;                                                                        ///Stores the Initial BMI from the BIM method Permantly;
		public double m_Initial_Weight;                                                                   //Stores Initial weight permantly of the profile
		public int m_Initial_Age;
		
		public double m_Initial_BMR;                                                                        ///Stores the initial BRM from BRM METHOD (How many calories can eat)
		public double m_Initial_BMR_WithPhysical;		
		public double m_Initial_Activity_Level;                                                        ///Stores the % in decimal of the activity level for BMR calculation.
		public double m_Initial_Ideal_Weight_BMI_LOW;
		public double m_Initial_Ideal_Weight_BMI_HIGH;


		///<summary>
		///Current Data of the profile (this data changes and it is used for updating the statics)
		///</summary>
		public double m_Current_BMI;                                                                        ///Stores the Initial BMI from the BIM method Permantly;
		public double m_Current_Weight;                                                                   //Stores Initial weight permantly of the profile
		public int m_Current_Age;
		
		public double m_Current_BMR;                                                                        ///Stores the initial BRM from BRM METHOD (How many calories can eat)
		public double m_Current_BMR_WithPhysical;														
		public double m_Current_Activity_Level;                                                        ///Stores the % in decimal of the activity level for BMR calculation.
		public double m_Current_Calories_Consumed;                                          ///Used for subtracting from BMR Cals to calculate new weight
		public double m_Current_Ideal_Weight_BMI_LOW;
		public double m_Current_Ideal_Weight_BMI_HIGH;
		public double m_Current_Amount_Pounds_Lost;

		///Extras

		public int m_Days_Passed;                                                                                  ///Used for storing how many days passed. This only gets + 1 when a new days begin. No calendar tracker since violates simplicity.
		///



		///<summary>
		///Methods 
		///</summary>
		///
		//Calculates BMR

		//Pre:  current weight, current height converted to inches, current age, current activity level
		//Post: Changes the Current BMR
		void BMR_Harris()
		{

			double HeightInCentimeters = m_HeightInInches * 2.54; //Inches total * constant to get centimeters
			double WeightInKilograms = m_Current_Weight / 2.2;			//Pounds / 2.2 to get kilograms

			if (m_Gender == true) //	Male
			{

				m_Current_BMR = 66 + (13.7 * WeightInKilograms) + (5 * HeightInCentimeters) - (6.8 * m_Current_Age);
				m_Current_BMR_WithPhysical =  m_Current_BMR * m_Current_Activity_Level;		

			}
			else if (m_Gender == false) //Female
			{
				m_Current_BMR = 655 + (9.6 * WeightInKilograms) + (1.8 * HeightInCentimeters) - (4.7 * m_Current_Age);
				m_Current_BMR_WithPhysical = m_Current_BMR * m_Current_Activity_Level;		
				
			}
			else
			{
				m_Current_BMR = 0.000;
				m_Current_BMR_WithPhysical = 0.0000;
			}

		}


		void HeightToInches()
		{
			m_HeightInInches = (m_HeightFoot * 12) + m_HeightInches;
			
		}
		///

		//Pre:  current weight, current height converted to inche
		//Post: Changes the Current Bmi (gives a ratio)
		void BMI()
		{
			m_Current_BMI = ((m_Current_Weight * 703) / (m_HeightInInches * m_HeightInInches)); //Gets current BMI

			m_Current_Ideal_Weight_BMI_HIGH = (24.9 * m_HeightInInches * m_HeightInInches) / 703; //Gets Ideal weight High
			m_Current_Ideal_Weight_BMI_LOW = (18.5 * m_HeightInInches * m_HeightInInches) / 703; //Gets Ideal Weight Low
			
			

		}

		void BurnedPounds()
		{
			m_Current_Weight -= ((m_Current_BMR_WithPhysical - m_Current_Calories_Consumed) / 3500);
			
		}



		public bool Update()
		{
			if (!M_FIRST_TIME)
			{
				//if (m_Current_Calories_Consumed <= 0)
				//      m_Current_Calories_Consumed *= -1;
				
				//new day
				m_Days_Passed += 1;

				//bnr
				BMR_Harris();

				//
				BurnedPounds();
				BMR_Harris();

				BMI();

				m_Current_Amount_Pounds_Lost = m_Initial_Weight - m_Current_Weight;

				return true;

			}
			else
			{


				m_Days_Passed = 0;
				
				HeightToInches();

				//age
				m_Current_Age = m_Age;
				m_Initial_Age = m_Current_Age;

				//weight

				m_Current_Weight = m_Weight_DontUse;
				m_Initial_Weight = m_Current_Weight;

				//Activity
				m_Initial_Activity_Level = m_Current_Activity_Level;

				//convert to inches
				


				//BMR
				BMR_Harris();
				m_Initial_BMR =  m_Current_BMR;
				m_Initial_BMR_WithPhysical = m_Current_BMR_WithPhysical;

				//BMI
				BMI();
				m_Initial_BMI = m_Current_BMI;
				m_Initial_Ideal_Weight_BMI_LOW = m_Current_Ideal_Weight_BMI_LOW;
				m_Initial_Ideal_Weight_BMI_HIGH = m_Current_Ideal_Weight_BMI_HIGH;






				//change cheker
				M_FIRST_TIME = false;
				
				return true;

			}

			

			return false;

		}

        public override string ToString()
        {
            return string.Format(" Day: {0},  Name:{1},  Age: {2},  Height: {3}, Gender: {4}, CURRENT: Weight: {5},  BMI : {6},  BRM: {7},  Burned Cals: {8}...... INITIAL: Weight: {9}     BMI : {10}      BRM: {11}............... Pounds Lost: {12} ",
                  m_Days_Passed,
                  m_FirstName,
                  m_Age,
                  m_HeightInInches,
            m_Gender,


            m_Current_Weight,
            m_Current_BMI,

            m_Current_BMR_WithPhysical,

            m_Current_Calories_Consumed,

            m_Initial_Weight,
            m_Initial_BMI,
            m_Initial_BMR_WithPhysical, m_Current_Amount_Pounds_Lost);



        }








	} //End of class
}// end of namespace
