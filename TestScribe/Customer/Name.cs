using RattrapDev.Scribe.Term;

namespace TestScribe.Customer
{
    [ValueObject("Name", "A person's name", "Customer")]
    public class Name
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
