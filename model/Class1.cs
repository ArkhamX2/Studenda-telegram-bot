namespace model
{
    public class ChatUser
    {
        public int ID { get; set; }
        public string name { get; set; }=string.Empty;
        public string password { get; set; } =string.Empty;
        public string? tglink { get; set; } =string.Empty;
        public long? chat_id { get; set; } 
        
    }
}