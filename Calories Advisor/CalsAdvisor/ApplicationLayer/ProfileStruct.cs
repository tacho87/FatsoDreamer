using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CalsAdvisor.ApplicationLayer
{
    [Serializable()]
    public class ProfileStruct
    {
        //Profile Structure
        public double   BMI;                                                          
        public double   Weight;                                   
        public double   BMR;                                                          
        public double   BMR_Physical;
        public double   ActivityLevel;                                                
        public double   CaloriesConsumedToday;                              
        
    }
}
