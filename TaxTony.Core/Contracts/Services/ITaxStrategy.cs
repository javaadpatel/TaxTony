namespace TaxTony.Core.Contracts.Services
{
    public interface ITaxStrategy
    {

        decimal CalculateTax(decimal annualSalary);
    }
}
