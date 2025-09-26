using System.Collections.Concurrent;

namespace TestStrategies;

public class AccountService
{
    private readonly ConcurrentDictionary<Guid, Account> _accounts = new();

    public Account CreateAccount(string owner, decimal initialDeposit = 0)
    {
        if (string.IsNullOrWhiteSpace(owner))
            throw new ArgumentException("Le propriétaire ne peut pas être vide.", nameof(owner));
        if (initialDeposit < 0)
            throw new ArgumentException("Le dépôt initial ne peut pas être négatif.", nameof(initialDeposit));

        var acc = new Account { Owner = owner };
        if (initialDeposit > 0) acc.Deposit(initialDeposit);
        _accounts[acc.Id] = acc;
        return acc;
    }

    public Account? GetAccount(Guid id) => _accounts.TryGetValue(id, out var acc) ? acc : null;

    public void Deposit(Guid id, decimal amount)
    {
        var acc = GetAccount(id) ?? throw new KeyNotFoundException($"Compte avec l'ID {id} introuvable.");
        acc.Deposit(amount);
    }

    public void Withdraw(Guid id, decimal amount)
    {
        var acc = GetAccount(id) ?? throw new KeyNotFoundException($"Compte avec l'ID {id} introuvable.");
        acc.Withdraw(amount);
    }

    public IEnumerable<Account> GetAllAccounts()
    {
        return _accounts.Values.ToList();
    }
}
