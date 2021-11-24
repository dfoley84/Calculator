using System;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace BPCalculator
{
    // BP categories
    public enum BPCategory
    {
        [Display(Name="Low Blood Pressure")] Low,
        [Display(Name="Ideal Blood Pressure")]  Ideal,
        [Display(Name="Pre-High Blood Pressure")] PreHigh,
        [Display(Name ="High Blood Pressure")]  High,
        [Display(Name = "No Blood Pressure Found")] Unknown //Throw Expection is Breaking the Code 
    };

    public class BloodPressure
    {
        public const int SystolicMin = 70;
        public const int SystolicMax = 190;
        public const int DiastolicMin = 40;
        public const int DiastolicMax = 100;
        public const int AgeAdult = 1;
        public const int AgeTeen = 2;

        [Range(SystolicMin, SystolicMax, ErrorMessage = "Invalid Systolic Value")]
        public int Systolic { get; set; }                       // mmHG

        [Range(DiastolicMin, DiastolicMax, ErrorMessage = "Invalid Diastolic Value")]
        public int Diastolic { get; set; }                      // mmHG
     
       public int AgeType { get; set; }
     


        // calculate BP category
        public BPCategory Category
        {
            get 
            {   
                //Getting Low BP 
                if ((AgeType == 1 && Systolic >= 70 && Systolic <= 90) && (Diastolic >= 40 && Diastolic <= 60))
                {
                    return BPCategory.Low;
                }
                else if ((AgeType == 2 && Systolic >= 70 && Systolic <= 105) && (Diastolic >= 40 && Diastolic <= 77))
                {
                    return BPCategory.Low;
                }

                // Getting Ideal BP
                else if ((AgeType == 1 && Systolic >= 90 && Systolic <= 120) && (Diastolic >= 60 && Diastolic <= 80))
                {
                    return BPCategory.Ideal;
                }
                else if ((AgeType == 2 && Systolic >= 105 && Systolic <= 117) && (Diastolic >= 77 && Diastolic <= 80))
                {
                    return BPCategory.Ideal;
                }

                // Getting Pre-High BP
                else if ((AgeType == 1 && Systolic >= 120 && Systolic <= 140) && (Diastolic >= 80 && Diastolic <= 90)) 
                {
                    return BPCategory.PreHigh;
                }
                //Getting High
                else if ((AgeType == 1 &&  Systolic >= 140 && Systolic <= 190) && (Diastolic >= 90 && Diastolic <= 100))
                {
                    return BPCategory.High;
                }
                else if ((AgeType == 2 && Systolic >= 117 && Systolic <= 120) && (Diastolic >= 80 && Diastolic <= 81))
                {
                    return BPCategory.High;
                }

                else
                {
                    return BPCategory.Unknown;
                }
            }
        }

        
    }
}
