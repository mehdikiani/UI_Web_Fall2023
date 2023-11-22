namespace Ticketing.Core.Models
{
    public class Message
    {
        public string Content { get; set; }
        public MessageType Type { get; set; }

        public static Message New(string content, MessageType type)
            => new Message { Content = content , Type = type};
       
        public static Message Warning(string content)=>New(content, MessageType.Warning);
        
        public static Message Info(string content) => New(content, MessageType.Info);
        
        public static Message Error(string content) => New(content, MessageType.Error);
        
        public static Message Success(string content) => New(content, MessageType.Success);
    }
    public enum MessageType
    {
        Warning,
        Info,
        Error,
        Success
    }
}
