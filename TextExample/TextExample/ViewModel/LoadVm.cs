namespace TextExample.ViewModel
{
    public class LoadVm
    {
       
        public string Description { get; set; }

        public int Amount { get; set; }

        public int Weight { get; set; }

        public LoadVm(string description, int amount, int weight)
        {
            Description = description;
            Amount = amount;
            Weight = weight;
        }

    }
}