namespace Notes.Views
{
    public partial class Page1
    {
        public class Planes
        {
            private string name;
            private int baseW;
            private int maxW;
            private int loading;
            private int takeoff;
            private int landing;

            public Planes(string name, int baseW, int maxW, int loading, int takeoff, int landing)
            {
                this.name = name;
                this.baseW = baseW;
                this.maxW = maxW;
                this.loading = loading;
                this.takeoff = takeoff;
                this.landing = landing;
            }
        }

        //public string name;
        //public int baseW, maxW, loading, takeoff, landing;
        //public List<object> ps = new List<object>();
        //Planes c5 = new Planes("c-5", 400000, 685000, 5, 8300, 4900);
        //Planes c17 = new Planes("c-17", 282400, 453300, 4, 8200, 3500);
        //Planes c130 = new Planes("c-130", 75840, 119840, 3, 3586, 2500);
        //Planes f15 = new Planes("F-15", 45000, 68000, 2, 1000, 1650);
        //Planes Boeing747 = new Planes("Boeing 747", 404600, 653200, 5, 10450, 6920);

    }


      
        

}
