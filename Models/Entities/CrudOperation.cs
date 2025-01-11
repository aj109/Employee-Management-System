namespace CrudOperationCore.Models.Entities
{
    public class CrudOperation
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }

        public string Phone {  get; set; }
        public decimal Salary {  get; set; }

    }
}
