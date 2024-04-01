namespace MegaApp.Domain.Common
{
    // public class SuperBaseEntity
    // {
    // }
    public abstract class BaseEntity //<T>  //: SuperBaseEntity
    {
        public virtual int Id { get; set; }
    }
}