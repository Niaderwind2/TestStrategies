namespace TestStrategies.Tests
{
    [TestFixture]
    public class UnitTests
    {
        #region Tests pour la classe Account - À COMPLÉTER

        [Test]
        public void Account_Constructor_ShouldCreateAccountWithDefaultValues()
        {
            // Arrange & Act
            var account = new Account();

            // Assert - TODO: Complétez les assertions
            // Vérifiez que l'ID n'est pas vide
            // Vérifiez que Owner est une chaîne vide
            // Vérifiez que Balance est à 0
            // Vérifiez que InterestRate est à 0.01m
            Assert.Fail("À implémenter : vérifiez les valeurs par défaut du compte");
        }

        [Test]
        public void Deposit_ValidAmount_ShouldIncreaseBalance()
        {
            // Arrange
            var account = new Account();
            decimal depositAmount = 100m;

            // Act
            // TODO: Effectuez le dépôt

            // Assert
            // TODO: Vérifiez que le solde a augmenté
            Assert.Fail("À implémenter : testez le dépôt d'un montant valide");
        }

        [Test]
        public void Deposit_NegativeAmount_ShouldThrowArgumentException()
        {
            // Arrange
            var account = new Account();

            // Act & Assert
            // TODO: Vérifiez qu'une exception ArgumentException est levée pour un montant négatif
            Assert.Fail("À implémenter : testez le dépôt d'un montant négatif");
        }

        [Test]
        public void Deposit_ZeroAmount_ShouldThrowArgumentException()
        {
            // TODO: Implémentez ce test complètement
            // Vérifiez qu'un dépôt de 0€ lève une ArgumentException
            Assert.Fail("À implémenter complètement");
        }

        [Test]
        public void Withdraw_ValidAmount_ShouldDecreaseBalance()
        {
            // TODO: Implémentez ce test complètement
            // 1. Créez un compte et déposez 100€
            // 2. Retirez 50€
            // 3. Vérifiez que le solde est à 50€
            Assert.Fail("À implémenter complètement");
        }

        [Test]
        public void Withdraw_AmountGreaterThanBalance_ShouldThrowInvalidOperationException()
        {
            // TODO: Implémentez ce test complètement
            // Testez le retrait d'un montant supérieur au solde
            Assert.Fail("À implémenter complètement");
        }

        [Test]
        public void CalculateInterest_ShouldReturnCorrectInterest()
        {
            // TODO: Implémentez ce test complètement
            // 1. Créez un compte avec un taux d'intérêt de 5%
            // 2. Déposez 1000€
            // 3. Vérifiez que les intérêts calculés sont de 50€
            Assert.Fail("À implémenter complètement");
        }

        #endregion

        #region Tests pour la classe AccountService - À COMPLÉTER

        private AccountService _accountService;

        [SetUp]
        public void SetUp()
        {
            _accountService = new AccountService();
        }

        [Test]
        public void CreateAccount_ValidParameters_ShouldCreateAccount()
        {
            // Arrange
            string owner = "John Doe";
            decimal initialDeposit = 100m;

            // Act
            var account = _accountService.CreateAccount(owner, initialDeposit);

            // Assert
            // TODO: Complétez les assertions
            // Vérifiez le propriétaire, le solde et l'ID
            Assert.Fail("À implémenter : vérifiez la création d'un compte valide");
        }

        [Test]
        public void CreateAccount_EmptyOwner_ShouldThrowArgumentException()
        {
            // TODO: Testez qu'un propriétaire vide lève une ArgumentException
            Assert.Fail("À implémenter complètement");
        }

        [Test]
        public void GetAccount_ExistingId_ShouldReturnAccount()
        {
            // TODO: 
            // 1. Créez un compte
            // 2. Récupérez-le par son ID
            // 3. Vérifiez qu'il est bien retourné
            Assert.Fail("À implémenter complètement");
        }

        [Test]
        public void GetAccount_NonExistingId_ShouldReturnNull()
        {
            // TODO: Testez qu'un ID inexistant retourne null
            Assert.Fail("À implémenter complètement");
        }

        [Test]
        public void ServiceDeposit_ValidAmount_ShouldIncreaseBalance()
        {
            // TODO: 
            // 1. Créez un compte avec un solde initial
            // 2. Effectuez un dépôt via le service
            // 3. Vérifiez que le solde a augmenté
            Assert.Fail("À implémenter complètement");
        }

        [Test]
        public void ServiceWithdraw_ValidAmount_ShouldDecreaseBalance()
        {
            // TODO: Similaire au dépôt mais pour un retrait
            Assert.Fail("À implémenter complètement");
        }

        #endregion
    }
}