using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CalsAdvisor.ApplicationLayer;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using CalsAdvisor.DataLayer;
using System.Windows.Forms;

namespace CalsAdvisor
{
	[Serializable()]
	public class AppLayer
	{
		//Client Layer GUI data

		//Create New Profile Data
		public string m_firstName;
		public string m_lastName;
		public int m_age;
		public int m_heightFoots;
		public int m_heightInches;
		public bool m_gender_trueMale_FalseFemale;
		public double m_weight;
		public double m_activityLevel;
		//New Day
		public double CaloriesConsumedTextBox;
		public double WeightTextBox;
		public double SumOfCaloriesAday; //Used to hold CaloriesConsumed 


		//
		public ProfileControl Person;


		public bool CreateNewProfile()
		{
			Person = new ProfileControl(m_firstName, m_lastName, m_age, m_heightFoots, m_heightInches, m_gender_trueMale_FalseFemale, m_weight, m_activityLevel);
			DataController.SaveFile(ref Person);
			return true;
		}
		public bool FinishDayCalories()
		{
			Person.NewDay(CaloriesConsumedTextBox);
			DataController.SaveFile(ref Person);
			return true;
		}
		public bool FinishDayWeight()
		{
			Person.NewDay(WeightTextBox, true);
			DataController.SaveFile(ref Person);
			return true;
		}
		public bool SaveProfile()
		{
			bool Sucessful = DataController.SaveFile(ref Person);

			return Sucessful;
		}
		public bool SaveTextProfileInformation()
		{
			bool Sucessful = DataController.SaveTextFileInformation(ref Person);

			return Sucessful;
		}
		public bool SaveTextPredictionInformation(ref ProfileControl Prediction, ref RichTextBox richs)
		{
			bool Sucessful = DataController.SaveTextFilePrediction(ref Prediction, ref richs);

			return Sucessful;
		}
		//MOVE IT TO THE DATACONTROLLER CLASS LATER... TESTING ONLY
		public bool LoadProfile()
		{

			Person = DataController.ReadFile();
			if (Person == null)
			{
				return false;
			}
			else
				return true;


		}

	}
}
