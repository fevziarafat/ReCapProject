namespace Core.Entities.Concrete
{
    public class UserOperationClaim:IEntity
    {
        public int Id { get; set; }
        public int UserForJwtId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
