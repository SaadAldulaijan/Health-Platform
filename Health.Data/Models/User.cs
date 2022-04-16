namespace Health.Data.Models
{
    public class User : BaseMode<string>
    {
        public string Username { get; set; }
        public string Image { get; set; }

        //public int SecurityGroupId { get; set; }
        //public SecurityGroup SecurityGroup { get; set; }
    }
}
