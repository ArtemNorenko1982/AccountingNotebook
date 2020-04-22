namespace AccountingNotebook.Contract.Interfaces
{
    public interface IIdentified<TKey> : ISelectCriteria
    {
        TKey Id { get; set; }
    }
}
