using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using System.Net;

namespace TestStrategies.Tests
{
    [TestFixture]
    public class IntegrationTests
    {
        private WebApplicationFactory<Program> _factory;
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        [TearDown]
        public void TearDown()
        {
            _client?.Dispose();
            _factory?.Dispose();
        }

        #region Tests d'intégration de l'API - À COMPLÉTER

        [Test]
        public async Task CreateAccount_ValidRequest_ShouldReturnCreated()
        {
            // Arrange
            var request = new CreateAccountRequest("John Doe", 100m);

            // Act
            // TODO: Effectuez un appel POST à /accounts avec le request

            // Assert
            // TODO: Vérifiez que le statut est Created (201)
            // TODO: Désérialisez la réponse et vérifiez les propriétés du compte créé
            Assert.Fail("À implémenter : testez la création d'un compte via l'API");
        }

        [Test]
        public async Task CreateAccount_EmptyOwner_ShouldReturnBadRequest()
        {
            // TODO: Implémentez ce test complètement
            // 1. Créez un request avec un propriétaire vide
            // 2. Effectuez l'appel POST
            // 3. Vérifiez que le statut est BadRequest (400)
            Assert.Fail("À implémenter complètement");
        }

        [Test]
        public async Task GetAccount_ExistingId_ShouldReturnAccount()
        {
            // Arrange - Créez d'abord un compte
            var createRequest = new CreateAccountRequest("Jane Doe", 150m);
            var createResponse = await _client.PostAsJsonAsync("/accounts", createRequest);
            var createdAccount = await createResponse.Content.ReadFromJsonAsync<Account>();

            // Act
            // TODO: Effectuez un appel GET à /accounts/{id}
            
            // Assert
            // TODO: Vérifiez que le statut est OK et que l'account retourné est correct
            Assert.Fail("À implémenter : testez la récupération d'un compte existant");
        }

        [Test]
        public async Task GetAccount_NonExistingId_ShouldReturnNotFound()
        {
            // TODO: Implémentez ce test complètement
            // Testez l'appel GET avec un GUID qui n'existe pas
            Assert.Fail("À implémenter complètement");
        }

        [Test]
        public async Task Deposit_ValidRequest_ShouldUpdateBalance()
        {
            // Arrange - Créez un compte d'abord
            var createRequest = new CreateAccountRequest("Bob Smith", 200m);
            var createResponse = await _client.PostAsJsonAsync("/accounts", createRequest);
            var account = await createResponse.Content.ReadFromJsonAsync<Account>();
            
            var depositRequest = new DepositRequest(50m);

            // Act
            // TODO: Effectuez un appel POST à /accounts/{id}/deposit
            
            // Assert
            // TODO: Vérifiez que le solde a été mis à jour (200 + 50 = 250)
            Assert.Fail("À implémenter : testez le dépôt via l'API");
        }

        [Test]
        public async Task Withdraw_ValidRequest_ShouldUpdateBalance()
        {
            // TODO: Implémentez ce test complètement
            // Similaire au dépôt mais pour un retrait
            Assert.Fail("À implémenter complètement");
        }

        [Test]
        public async Task Withdraw_InsufficientFunds_ShouldReturnBadRequest()
        {
            // TODO: Implémentez ce test complètement
            // 1. Créez un compte avec peu de fonds
            // 2. Tentez de retirer plus que le solde
            // 3. Vérifiez que le statut est BadRequest
            Assert.Fail("À implémenter complètement");
        }

        [Test]
        public async Task GetAllAccounts_ShouldReturnAccountsList()
        {
            // Arrange - Créez quelques comptes
            await _client.PostAsJsonAsync("/accounts", new CreateAccountRequest("Alice", 100m));
            await _client.PostAsJsonAsync("/accounts", new CreateAccountRequest("Charlie", 200m));

            // Act
            // TODO: Effectuez un appel GET à /accounts
            
            // Assert
            // TODO: Vérifiez que la liste contient au moins les comptes créés
            Assert.Fail("À implémenter : testez la récupération de tous les comptes");
        }

        [Test]
        public async Task CalculateInterest_ShouldReturnCorrectAmount()
        {
            // TODO: Implémentez ce test complètement
            // 1. Créez un compte
            // 2. Effectuez un appel GET à /accounts/{id}/interest
            // 3. Vérifiez que le calcul d'intérêts est correct
            // Note: L'API retourne { "Interest": 10.0 }, pas juste un decimal
            Assert.Fail("À implémenter complètement");
        }

        #endregion

        #region Tests de bout en bout - À COMPLÉTER

        [Test]
        public async Task CompleteWorkflow_CreateDepositWithdraw_ShouldWorkCorrectly()
        {
            // TODO: Implémentez un test de workflow complet
            // 1. Créez un compte
            // 2. Effectuez plusieurs dépôts
            // 3. Effectuez un retrait
            // 4. Vérifiez le solde final
            // 5. Calculez les intérêts
            Assert.Fail("À implémenter : testez un workflow complet de bout en bout");
        }

        #endregion
    }

    // DTOs pour les tests (doivent correspondre à ceux du projet principal)
    public record CreateAccountRequest(string Owner, decimal InitialDeposit = 0);
    public record DepositRequest(decimal Amount);
    public record WithdrawRequest(decimal Amount);
    public record InterestResponse(decimal Interest);
}
