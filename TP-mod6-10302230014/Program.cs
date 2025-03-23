namespace TP_mod6_10302230014
{

    class SayaTubeVideo
    {
        private int id;
        private string title;
        private int playCount;

        public SayaTubeVideo(string title)
        {
            if (title == null || title.Length > 100)
                throw new ArgumentException("Judul video tidak boleh null dan maksimal 100 karakter.");

            Random rand = new Random();
            this.id = rand.Next(10000, 99999);
            this.title = title;
            this.playCount = 0;
        }

        public void IncreasePlayCount(int count)
        {
            if (count > 10000000)
                throw new ArgumentException("Penambahan play count maksimal 10.000.000 per panggilan.");

            try
            {
                checked
                {
                    this.playCount += count;
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: Play count melebihi batas maksimum integer!");
            }
        }

        public void PrintVideoDetails()
        {
            Console.WriteLine("Video ID: " + this.id);
            Console.WriteLine("Title: " + this.title);
            Console.WriteLine("Play Count: " + this.playCount);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract - [Rahmah Aisyah]");

                for (int i = 0; i < 100; i++)
                {
                    video.IncreasePlayCount(10000000);
                }

                video.PrintVideoDetails();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Terjadi kesalahan: " + ex.Message);
            }
        }
    }
}
