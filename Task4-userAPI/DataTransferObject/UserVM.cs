namespace Task4_userAPI.DataTransferObject
{
    public class UserVM
    {
        public int Id { get; set; }
        public string fname { get; set; }
            public string lname { get; set; }
             public ICollection<int> postId { get; set; }
    
    }
}
