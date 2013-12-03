using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CalsAdvisor.ApplicationLayer;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace CalsAdvisor.DataLayer
{
	[Serializable()]
	static public class DataController
	{
		//Save Profile
		static public bool SaveFile(ref ProfileControl Person)
		{
			try
			{
				using (Stream stream = File.Open("atgcpp.dll", FileMode.Create))
				{
					BinaryFormatter bin = new BinaryFormatter();
					bin.Serialize(stream, Person);
				}
				return true;
			}
			catch (IOException)
			{
				MessageBox.Show("Problem Saving Profile, check ReadMe Doc for information...", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}



		}

		//Save Text Information Summary
		static public bool SaveTextFileInformation(ref ProfileControl Prof)
		{

			Stream myStream;
			SaveFileDialog saveFileDialog1 = new SaveFileDialog();

			saveFileDialog1.Filter = "Word Document files (*.Doc)|*.Doc|All files (*.*)|*.*";
			saveFileDialog1.FilterIndex = 1;
			saveFileDialog1.RestoreDirectory = true;

			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				if ((myStream = saveFileDialog1.OpenFile()) != null)
				{
					StreamWriter wText = new StreamWriter(myStream);

					wText.WriteLine("Calories Counter Application - Profile History:");
					wText.WriteLine();
					wText.WriteLine(Prof.FirstName + " " + Prof.LastName);
					wText.WriteLine("Age: " + Prof.Age + "\t\tHeight: " + Prof.HeightFoot + " " + Prof.HeightInches);

					if (Prof.Gender == true)
					{

						wText.WriteLine("Gender: Male");
					}
					else
						wText.WriteLine("Gender: Female");


					//Data To save in File
					wText.WriteLine();
					wText.WriteLine();
					wText.WriteLine("INITIAL" + "              Date Started:  " + Prof.InitialDate);
					wText.WriteLine();
					wText.WriteLine("   Weight:         " + Prof.InitialProfile.Weight);
					wText.WriteLine("   BMI:            " + Prof.InitialProfile.BMI);
					wText.WriteLine("   Status:         " + Prof.InitialBMIstatus);
					wText.WriteLine("   BRM:            " + Prof.InitialProfile.BMR);
					wText.WriteLine("   BRM_Physical:   " + Prof.InitialProfile.BMR);
					wText.WriteLine("   Activity Level: " + Prof.InitialProfile.ActivityLevel);

					wText.WriteLine();
					wText.WriteLine();
					wText.WriteLine();


					wText.WriteLine("CURRENT(NOW)" + "         Current Date:  " + Prof.CurrentDate);
					wText.WriteLine();
					wText.WriteLine("   Weight:         " + Prof.CurrentProfile.Weight);
					wText.WriteLine("   BMI:            " + Prof.CurrentProfile.BMI);
					wText.WriteLine("   Status:         " + Prof.CurrentBMIstatus);
					wText.WriteLine("   BRM:            " + Prof.CurrentProfile.BMR);
					wText.WriteLine("   BRM_Physical:   " + Prof.CurrentProfile.BMR);
					wText.WriteLine("   Activity Level: " + Prof.CurrentProfile.ActivityLevel);
					wText.WriteLine("   Pound Lost:     " + Prof.PoundLost);



					wText.Close();
					
					return true;

				}
			}
			return false;

		}


		//Save Prediction
		static public bool SaveTextFilePrediction(ref ProfileControl Prof, ref RichTextBox richtext)
		{
			try
			{
				Stream myStream;
				SaveFileDialog saveFileDialog1 = new SaveFileDialog();

				saveFileDialog1.Filter = "Word Document files (*.Doc)|*.Doc|All files (*.*)|*.*";
				saveFileDialog1.FilterIndex = 1;
				saveFileDialog1.RestoreDirectory = true;

				if (saveFileDialog1.ShowDialog() == DialogResult.OK)
				{
					if ((myStream = saveFileDialog1.OpenFile()) != null)
					{
						StreamWriter wText = new StreamWriter(myStream);

						wText.WriteLine("Calories Counter Application - Prediction History:");
						wText.WriteLine();
						wText.WriteLine(Prof.FirstName + " " + Prof.LastName);
						wText.WriteLine("Age: " + Prof.Age + "\t\tHeight: " + Prof.HeightFoot + " " + Prof.HeightInches);

						if (Prof.Gender == true)
						{

							wText.WriteLine("Gender: Male");
						}
						else
							wText.WriteLine("Gender: Female");

						wText.WriteLine();
						wText.WriteLine();
						wText.WriteLine("INITIAL" + "              Date Started:  " + Prof.InitialDate);
						wText.WriteLine();
						wText.WriteLine("   Weight:         " + Prof.InitialProfile.Weight);
						wText.WriteLine("   BMI:            " + Prof.InitialProfile.BMI);
						wText.WriteLine("   Status:         " + Prof.InitialBMIstatus);
						wText.WriteLine("   BRM:            " + Prof.InitialProfile.BMR);
						wText.WriteLine("   BRM_Physical:   " + Prof.InitialProfile.BMR_Physical);
						wText.WriteLine("   Activity Level: " + Prof.InitialProfile.ActivityLevel);

						wText.WriteLine();
						wText.WriteLine();
						wText.WriteLine();


						wText.WriteLine("CURRENT(NOW)" + "         Current Date:  " + Prof.CurrentDate);
						wText.WriteLine();
						wText.WriteLine("   Weight:         " + Prof.CurrentProfile.Weight);
						wText.WriteLine("   BMI:            " + Prof.CurrentProfile.BMI);
						wText.WriteLine("   Status:         " + Prof.CurrentBMIstatus);
						wText.WriteLine("   BRM:            " + Prof.CurrentProfile.BMR);
						wText.WriteLine("   BRM_Physical:   " + Prof.CurrentProfile.BMR_Physical);
						wText.WriteLine("   Activity Level: " + Prof.CurrentProfile.ActivityLevel);
						wText.WriteLine("   Pound Lost:     " + Prof.PoundLost);

						wText.WriteLine();
						wText.WriteLine();
						wText.WriteLine();
						wText.WriteLine();
						wText.WriteLine();
						wText.WriteLine("HISTORY");
						wText.WriteLine();
						wText.WriteLine();
						wText.WriteLine(richtext.Text);
						wText.Flush();


						wText.Close();
						
						return true;

					}
				}
			}
			catch
			{

				MessageBox.Show("Problem Saving File, Current Prediction does not exist! Please Redo the Prediction.", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			return false;

		}


		//Load File Profile
		static public ProfileControl ReadFile()
		{
			try
			{

				using (Stream stream = File.Open("atgcpp.dll", FileMode.Open))
				{

					BinaryFormatter bin = new BinaryFormatter();


					ProfileControl Person = (ProfileControl)bin.Deserialize(stream);

					return Person;
				}
			}
			catch (IOException)
			{

				return null;
			}


		}

	}
}
