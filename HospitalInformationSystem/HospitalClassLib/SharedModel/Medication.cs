
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLib.SharedModel
{
    public class Medication
    {

        public string MedicineID { get; set; }
        public string MedicineName { get; set; }
        public List<Allergen> Components { get; set; }
        public string IDSubstitution { get; set; }

        public MedicineApprovalStatus ApprovalStatus { get; set; }

        public Medication()
        {
            Components = new List<Allergen>();
            ApprovalStatus = MedicineApprovalStatus.Waiting;
        }

        public Medication(string id, string name, List<Allergen> components, string iDSubstitution)
        {
            MedicineID = id;
            MedicineName = name;
            Components = components;
            ApprovalStatus = MedicineApprovalStatus.Waiting;
            IDSubstitution = iDSubstitution; 
        }

        public String GetComponentsList()
        {
            string componentsString = "";
            if (Components.Count == 0)
                return "Nije navedeno";

            foreach (var a in Components)
                componentsString += a.Name + ", ";
            return componentsString.Remove(componentsString.Length - 2);
        }

 
        public String ApprovalStatusString
        {
            get
            {
                if (ApprovalStatus == MedicineApprovalStatus.Accepted)
                    return "Prihvaćen";
                else if (ApprovalStatus == MedicineApprovalStatus.Waiting)
                    return "Na čekanju";
                else return "Odbijen";
            }
        }

        public Boolean IncludesAllergen(Allergen allergen) 
        {
            foreach(Allergen currentAllergen in Components)
            {
                if (currentAllergen.Id == allergen.Id)
                    return true;
            }

            return false;
        }

        public void RemoveComponent(Allergen allergen)
        {
            for (int i = 0; i < Components.Count; i++)
            {
                Allergen currentComponent = Components[i];
                if (currentComponent.Id == allergen.Id)
                {
                    Components.Remove(currentComponent);
                    i--;
                }
            }
        }
    }

    public enum MedicineApprovalStatus
    {
        Accepted = 0,
        Denied, 
        Waiting
    }
    
}
