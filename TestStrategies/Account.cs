namespace TestStrategies;

public class Account
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Owner { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public decimal InterestRate { get; set; } = 0.01m; // 1% par défaut

    public void Deposit(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Le montant doit être positif.");
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Le montant doit être positif.");
        if (amount > Balance) throw new InvalidOperationException("Solde insuffisant.");
        Balance -= amount;
    }

    public decimal CalculateInterest()
    {
        return Balance * InterestRate;
    }
}
