namespace InsertJsonData.Dto
{
    public class CakeDto
    {
       

            public string id { get; set; }
            public string type { get; set; }
            public string name { get; set; }
            public double ppu { get; set; }
            public Batters batters { get; set; }
            public List<Topping> Topping { get; set; }


        }

        public class Batters
        {
            public List<Batter> batter { get; set; }
        }
        public class Batter
        {
            public string id { get; set; }
            public string type { get; set; }
        }

        public class Topping
        {
            public string id { get; set; }
            public string type { get; set; }
        }
    
}
