namespace HospitalAPI.Dto
{
    public class MedicationDto
    {
        public MedicationDto(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
