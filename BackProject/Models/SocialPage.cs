namespace BackProject.Models
{
    public class SocialPage
    {
        public int Id { get; set; }

        public string Whatsapp { get; set; }

        public string LinkedIn { get; set; }

        public string Instagram { get; set; }

        public string Facebook { get; set; }


        public Teachers Teacher { get; set; }

        public int TeacherId { get; set; }

    }
}
