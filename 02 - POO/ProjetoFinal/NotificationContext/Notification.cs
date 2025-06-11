namespace ProjetoFinal.NotificationContext{
    public sealed class Notification{
        public Notification(string property, string message){
            this.Property = property;
            this.Message = message;
        }
        public Notification(){

        }

        public string Property {get;set;}
        public string Message{get;set;}
    }


}