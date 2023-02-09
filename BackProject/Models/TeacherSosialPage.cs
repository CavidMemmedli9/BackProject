namespace BackProject.Models
{
    public class TeacherSosialPage
    {
        public int Id { get; set; }

        public Teachers Teachers { get; set; }
        public int TeacherId { get; set; }

        public SocialPage SocialPage { get; set; }
        public int SocialPageId { get; set; }
    }
}
