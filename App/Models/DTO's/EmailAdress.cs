namespace Models.DTO_s
{
    public class EmailAdress
    {
        public string UserName { get; set; }
        public string Adress { get; set; }

        public EmailAdress(string userName, string adress)
        {
            this.UserName = userName;
            this.Adress = adress;
        }
    }
}
