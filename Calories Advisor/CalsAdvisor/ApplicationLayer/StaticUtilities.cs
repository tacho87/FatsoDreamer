using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace CalsAdvisor.ApplicationLayer
{
	[Serializable()]
	static public class StaticUtilities
	{
		static Random Rnd = new Random();

		//Burned Pounds
		static public void BurnedPounds(ref ProfileStruct Current)
		{
			Current.Weight -= ((Current.BMR_Physical - Current.CaloriesConsumedToday) / 3500);
		}

		static public void HeightToInches(ref int HeightInInches, int HeightFoot, int HeightInches)
		{
			HeightInInches = (HeightFoot * 12) + HeightInches;
		}


		//Pre:  current weight, current height converted to inche
		//Post: Changes the Current Bmi (gives a ratio)
		static public void BMI(ref ProfileStruct Current, int HeightInInches, ref double IdealWeightLow, ref double IdealWeightHigh)
		{
			Current.BMI = ((Current.Weight * 703) / (HeightInInches * HeightInInches)); //Gets current BMI

			IdealWeightHigh = (24.9 * HeightInInches * HeightInInches) / 703; //Gets Ideal weight High
			IdealWeightLow = (18.5 * HeightInInches * HeightInInches) / 703; //Gets Ideal Weight Low
		}

		static public int RandomValue(int Min, int Max)
		{

			int Value = Rnd.Next(Min, Max);

			return Value;

		}


		static public void BMR_Harris(ref ProfileStruct Current, bool Gender, int Age, int HeightInInches)
		{

			double HeightInCentimeters = HeightInInches * 2.54; //Inches total * constant to get centimeters
			double WeightInKilograms = Current.Weight / 2.2;			//Pounds / 2.2 to get kilograms

			if (Gender == true) //	Male
			{

				Current.BMR = 66 + (13.7 * WeightInKilograms) + (5 * HeightInCentimeters) - (6.8 * Age);
				Current.BMR_Physical = Current.BMR * (Current.ActivityLevel + 1);

			}
			else if (Gender == false) //Female
			{
				Current.BMR = 655 + (9.6 * WeightInKilograms) + (1.8 * HeightInCentimeters) - (4.7 * Age);
				Current.BMR_Physical = Current.BMR * (Current.ActivityLevel + 1);

			}
			else
			{
				Current.BMR = 0.000;
				Current.BMR_Physical = 0.0000;
			}

		}

	}
}
