namespace model
{
    public class User
    {
        public int ID { get; set; }
        public string name { get; set; }=string.Empty;
        public string password { get; set; } =string.Empty;
        public string tglink { get; set; } =string.Empty;
        public int? chat_id { get; set; } 
        
    }
}