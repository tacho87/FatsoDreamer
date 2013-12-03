using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CalsAdvisor.ApplicationLayer
{
	[Serializable()]
	public class ProfileControl
	{
		public ProfileControl(string firstName, string lastName, int age, int heightFoots, int heightInches, bool gender_trueMale_FalseFemale, double weight, double activityLevel)
		{
			FIRST_TIME = true; //turns the update method to run the Initial History
			Age = age;
			FirstName = firstName;
			LastName = lastName;
			HeightFoot = heightFoots;
			HeightInches = heightInches;
			Gender = gender_trueMale_FalseFemale;
			SumOfCaloriesHolder = 0;

			//Objects
			InitialProfile.Weight = weight;
			CurrentProfile.Weight = weight;
			InitialProfile.ActivityLevel = activityLevel;
			CurrentProfile.ActivityLevel = activityLevel;
			InitialProfile.CaloriesConsumedToday = 0;
			CurrentProfile.CaloriesConsumedToday = 0;

			//Methods

			StaticUtilities.HeightToInches(ref HeightInInches, HeightFoot, HeightInches);
			StaticUtilities.BMR_Harris(ref CurrentProfile, Gender, Age, HeightInInches);
			StaticUtilities.BMR_Harris(ref InitialProfile, Gender, Age, HeightInInches);
			StaticUtilities.BurnedPounds(ref CurrentProfile);
			StaticUtilities.BurnedPounds(ref InitialProfile);
			StaticUtilities.BMI(ref CurrentProfile, HeightInInches, ref IdealWeightLow, ref IdealWeightHigh);
			StaticUtilities.BMI(ref InitialProfile, HeightInInches, ref IdealWeightLow, ref IdealWeightHigh);

			InitialDate = DateTime.Now.ToString("D");
			CurrentDate = DateTime.Now.ToString("D");
			daysPassed = 0;
			if (InitialProfile.BMI >= 30)
			{
				InitialBMIstatus = "Obese";
			}
			else if (InitialProfile.BMI < 30 && InitialProfile.BMI >= 25)
			{
				InitialBMIstatus = "Overweight";
			}
			else if (InitialProfile.BMI < 25 && InitialProfile.BMI >= 18.5)
			{
				InitialBMIstatus = "Healthy";
			}
			else if (InitialProfile.BMI < 18.5)
			{
				InitialBMIstatus = "UnderWeight";
			}

			PoundLost = 0;
			CurrentBMISTATUS();

		}



		//Objects ProfileStruct

		public ProfileStruct InitialProfile = new ProfileStruct();
		public ProfileStruct CurrentProfile = new ProfileStruct();

		#region Basic Information
		//Internal Operation
		public bool FIRST_TIME;

		// Person Identification Variables
		public string FirstName;
		public string LastName;
		public int Age;
		public bool Gender;

		public double Weight_DontUse; //Gets the Initial Weight Temporary 
		public int HeightFoot, HeightInches; //HeightFoot * 12 + HeightInches... EX. 5" 7'     ---> 5*12 = 60 ----> 60 + 7 = 67
		public int HeightInInches;  // ^  

		public double IdealWeightLow;
		public double IdealWeightHigh;
		public string InitialDate;
		public string CurrentDate;

		public int daysPassed;

		public string InitialBMIstatus;
		public string CurrentBMIstatus;

		public double PoundLost;
		//RANDOM
		public double SumOfCaloriesHolder;

		#endregion

		public void NewDay(double caloriesConsumed)
		{
			CurrentDate = DateTime.Now.ToString("D");
			daysPassed += 1;

			CurrentProfile.CaloriesConsumedToday = caloriesConsumed;

			StaticUtilities.HeightToInches(ref HeightInInches, HeightFoot, HeightInches);
			StaticUtilities.BMR_Harris(ref CurrentProfile, Gender, Age, HeightInInches);
			StaticUtilities.BurnedPounds(ref CurrentProfile);
			StaticUtilities.BMI(ref CurrentProfile, HeightInInches, ref IdealWeightLow, ref IdealWeightHigh);


			PoundLost = InitialProfile.Weight - CurrentProfile.Weight;
			CurrentBMISTATUS();


		}
		public void NewDay(double weight, bool anything)
		{
			CurrentDate = DateTime.Now.ToString("D");
			daysPassed += 1;

			CurrentProfile.CaloriesConsumedToday = 0;
			CurrentProfile.Weight = weight;

			StaticUtilities.HeightToInches(ref HeightInInches, HeightFoot, HeightInches);
			StaticUtilities.BMR_Harris(ref CurrentProfile, Gender, Age, HeightInInches);
			StaticUtilities.BurnedPounds(ref CurrentProfile);
			StaticUtilities.BMI(ref CurrentProfile, HeightInInches, ref IdealWeightLow, ref IdealWeightHigh);

			PoundLost = InitialProfile.Weight - CurrentProfile.Weight;
			CurrentBMISTATUS();

		}
		void CurrentBMISTATUS()
		{
			if (CurrentProfile.BMI >= 30)
			{
				CurrentBMIstatus = "Obese";
			}
			else if (CurrentProfile.BMI < 30 && CurrentProfile.BMI >= 25)
			{
				CurrentBMIstatus = "Overweight";
			}
			else if (CurrentProfile.BMI < 25 && CurrentProfile.BMI >= 18.5)
			{
				CurrentBMIstatus = "Healthy";
			}
			else if (CurrentProfile.BMI < 18.5)
			{
				CurrentBMIstatus = "UnderWeight";
			}

		}


	}
}
