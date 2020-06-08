using OperatiiLimbaje.Models;

namespace OperatiiLimbaje.Contracts
{
    public interface IAutomatReader
    {
        Automat ReadAutomat(string filePath);
    }
}