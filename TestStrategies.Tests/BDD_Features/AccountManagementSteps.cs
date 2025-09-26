using Microsoft.AspNetCore.Mvc.Testing;
using TechTalk.SpecFlow;

namespace TestStrategies.Tests.BDD_Features
{
    /// <summary>
    /// EXERCICE BDD - Steps Definitions pour les tests SpecFlow
    /// 
    /// Instructions pour les étudiants :
    /// 1. Complétez les méthodes marquées avec TODO
    /// 2. Implémentez les steps manquantes pour les scénarios @todo
    /// 3. Utilisez les attributs SpecFlow appropriés ([Given], [When], [Then])
    /// 4. Gérez le contexte entre les étapes avec les propriétés de classe
    /// </summary>
    [Binding]
    public class AccountManagementSteps
    {
        private AccountService _accountService;
        private Account _currentAccount;
        private Exception _lastException;
        private WebApplicationFactory<Program> _factory;
        private HttpClient _client;
        private HttpResponseMessage _lastResponse;

        [BeforeScenario]
        public void Setup()
        {
            _accountService = new AccountService();
            _lastException = null;
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        [AfterScenario]
        public void Cleanup()
        {
            _client?.Dispose();
            _factory?.Dispose();
        }

        #region Background Steps

        [Given(@"the banking system is available")]
        public void GivenTheBankingSystemIsAvailable()
        {
            // Le service est déjà initialisé dans Setup()
            Assert.That(_accountService, Is.Not.Null);
        }

        #endregion

        #region Account Creation Steps

        [When(@"I create a new account for ""(.*)"" with initial deposit of (.*) euros")]
        public void WhenICreateANewAccountForWithInitialDepositOfEuros(string owner, decimal initialDeposit)
        {
            try
            {
                _currentAccount = _accountService.CreateAccount(owner, initialDeposit);
            }
            catch (Exception ex)
            {
                _lastException = ex;
            }
        }

        [Then(@"the account should be created successfully")]
        public void ThenTheAccountShouldBeCreatedSuccessfully()
        {
            Assert.That(_currentAccount, Is.Not.Null, "Account should be created");
            Assert.That(_lastException, Is.Null, "No exception should be thrown");
        }

        [Then(@"the account balance should be (.*) euros")]
        public void ThenTheAccountBalanceShouldBeEuros(decimal expectedBalance)
        {
            Assert.That(_currentAccount, Is.Not.Null, "Account should exist");
            Assert.That(_currentAccount.Balance, Is.EqualTo(expectedBalance), 
                $"Balance should be {expectedBalance} but was {_currentAccount.Balance}");
        }

        [Then(@"the account owner should be ""(.*)""")]
        public void ThenTheAccountOwnerShouldBe(string expectedOwner)
        {
            // TODO: Complétez cette méthode
            // Vérifiez que le propriétaire du compte est correct
            Assert.Fail("TODO: Implémentez la vérification du propriétaire du compte");
        }

        #endregion

        #region Deposit and Withdrawal Steps

        [Given(@"I have an account with balance (.*) euros")]
        public void GivenIHaveAnAccountWithBalanceEuros(decimal balance)
        {
            _currentAccount = _accountService.CreateAccount("Test User", balance);
        }

        [When(@"I deposit (.*) euros")]
        public void WhenIDepositEuros(decimal amount)
        {
            try
            {
                _currentAccount.Deposit(amount);
            }
            catch (Exception ex)
            {
                _lastException = ex;
            }
        }

        [When(@"I withdraw (.*) euros")]
        public void WhenIWithdrawEuros(decimal amount)
        {
            try
            {
                _currentAccount.Withdraw(amount);
            }
            catch (Exception ex)
            {
                _lastException = ex;
            }
        }

        [When(@"I attempt to withdraw (.*) euros")]
        public void WhenIAttemptToWithdrawEuros(decimal amount)
        {
            // TODO: Complétez cette méthode
            // Similaire à WhenIWithdrawEuros mais capture l'exception
            Assert.Fail("TODO: Implémentez la tentative de retrait avec gestion d'exception");
        }

        [When(@"I attempt to deposit (.*) euros")]
        public void WhenIAttemptToDepositEuros(decimal amount)
        {
            // TODO: Complétez cette méthode
            // Similaire à WhenIDepositEuros mais capture l'exception
            Assert.Fail("TODO: Implémentez la tentative de dépôt avec gestion d'exception");
        }

        [Then(@"the withdrawal should be rejected")]
        public void ThenTheWithdrawalShouldBeRejected()
        {
            Assert.That(_lastException, Is.Not.Null, "An exception should have been thrown");
        }

        [Then(@"I should receive an ""(.*)"" error")]
        public void ThenIShouldReceiveAnError(string errorType)
        {
            Assert.That(_lastException, Is.Not.Null, "An exception should have been thrown");
            
            switch (errorType.ToLower())
            {
                case "insufficient funds":
                    Assert.That(_lastException, Is.TypeOf<InvalidOperationException>());
                    break;
                // TODO: Ajoutez d'autres types d'erreurs selon les besoins
                default:
                    Assert.Fail($"TODO: Gérez le type d'erreur '{errorType}'");
                    break;
            }
        }

        [Then(@"the account balance should remain (.*) euros")]
        public void ThenTheAccountBalanceShouldRemainEuros(decimal expectedBalance)
        {
            // TODO: Complétez cette méthode
            // Vérifiez que le solde n'a pas changé après une opération échouée
            Assert.Fail("TODO: Implémentez la vérification que le solde n'a pas changé");
        }

        [Then(@"the operation should be (.*)")]
        public void ThenTheOperationShouldBe(string result)
        {
            switch (result.ToLower())
            {
                case "accepted":
                    Assert.That(_lastException, Is.Null, "Operation should succeed");
                    break;
                case "rejected":
                    Assert.That(_lastException, Is.Not.Null, "Operation should fail");
                    break;
                default:
                    Assert.Fail($"Unknown result type: {result}");
                    break;
            }
        }

        #endregion

        #region Integration Test Steps (API)

        [Given(@"the web API is running")]
        public void GivenTheWebAPIIsRunning()
        {
            // Le client HTTP est déjà configuré dans Setup()
            Assert.That(_client, Is.Not.Null);
        }

        [When(@"I send a POST request to create account for ""(.*)"" with (.*) euros")]
        public void WhenISendAPOSTRequestToCreateAccountForWithEuros(string owner, decimal initialDeposit)
        {
            // TODO: Complétez cette méthode
            // 1. Créez un objet CreateAccountRequest
            // 2. Envoyez une requête POST à /accounts
            // 3. Stockez la réponse dans _lastResponse
            Assert.Fail("TODO: Implémentez l'appel API pour créer un compte");
        }

        [Then(@"I should receive a ""(.*)"" response")]
        public void ThenIShouldReceiveAResponse(string expectedStatus)
        {
            // TODO: Complétez cette méthode
            // Vérifiez le code de statut HTTP de _lastResponse
            Assert.Fail("TODO: Implémentez la vérification du statut HTTP");
        }

        [Then(@"the response should contain the account details")]
        public void ThenTheResponseShouldContainTheAccountDetails()
        {
            // TODO: Complétez cette méthode
            // 1. Désérialisez la réponse JSON
            // 2. Vérifiez que les détails du compte sont présents
            Assert.Fail("TODO: Implémentez la vérification du contenu de la réponse");
        }

        #endregion

        #region Steps à implémenter par les étudiants

        // TODO: Ajoutez les steps pour les scénarios @todo du fichier .feature
        // Exemples de steps à implémenter :

        /*
        [Given(@"I have an account with balance (.*) euros and interest rate (.*) %")]
        public void GivenIHaveAnAccountWithBalanceEurosAndInterestRate(decimal balance, decimal rate)
        {
            // TODO: Créez un compte avec un taux d'intérêt spécifique
            Assert.Fail("TODO: Implémentez la création d'un compte avec taux d'intérêt personnalisé");
        }

        [When(@"I calculate the interest")]
        public void WhenICalculateTheInterest()
        {
            // TODO: Calculez les intérêts du compte courant
            Assert.Fail("TODO: Implémentez le calcul d'intérêts");
        }

        [Then(@"the calculated interest should be (.*) euros")]
        public void ThenTheCalculatedInterestShouldBeEuros(decimal expectedInterest)
        {
            // TODO: Vérifiez que les intérêts calculés sont corrects
            Assert.Fail("TODO: Implémentez la vérification du calcul d'intérêts");
        }
        */

        #endregion
    }

    // DTOs pour les tests d'intégration
    public record CreateAccountRequest(string Owner, decimal InitialDeposit = 0);
    public record DepositRequest(decimal Amount);
    public record WithdrawRequest(decimal Amount);
}

/*
 * INSTRUCTIONS POUR LES ÉTUDIANTS :
 * 
 * 1. Complétez toutes les méthodes marquées "TODO"
 * 2. Exécutez les tests SpecFlow : dotnet test --filter Category=unit
 * 3. Ajoutez les steps manquantes pour les scénarios @todo
 * 4. Créez des scénarios d'intégration pour tester l'API web
 * 5. Utilisez les tags pour organiser vos tests (@unit, @integration, @validation)
 * 
 * CONSEILS :
 * - Utilisez _currentAccount pour maintenir l'état entre les étapes
 * - Capturez les exceptions dans _lastException pour les tester
 * - Pour les tests d'intégration, utilisez _client pour les appels HTTP
 * - N'oubliez pas de vérifier les codes de statut HTTP et le contenu JSON
 */
