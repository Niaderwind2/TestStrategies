namespace TestStrategies.Tests
{
    /// <summary>
    /// EXERCICE TDD - Développement d'une fonctionnalité de transfert entre comptes
    /// 
    /// Objectif : Développer une fonctionnalité permettant de transférer de l'argent entre deux comptes
    /// 
    /// Processus TDD à suivre :
    /// 1. RED : Écrivez un test qui échoue
    /// 2. GREEN : Écrivez le code minimal pour faire passer le test  
    /// 3. REFACTOR : Améliorez le code sans casser les tests
    /// 4. Répétez pour chaque nouveau comportement
    /// 
    /// Instructions :
    /// - Commencez par le test le plus simple
    /// - N'implémentez QUE le code nécessaire pour faire passer le test
    /// - Refactorisez après chaque étape
    /// </summary>
    [TestFixture]
    public class TDD_Exercise_TransferFunctionality
    {
        private AccountService _accountService;

        [SetUp]
        public void SetUp()
        {
            _accountService = new AccountService();
        }

        #region ÉTAPE 1 - Test basique de transfert

        [Test]
        public void Transfer_ValidAmountBetweenAccounts_ShouldTransferMoney()
        {
            // ÉTAPE 1A : Écrivez ce test (RED)
            // Arrange
            // TODO: Créez deux comptes avec des soldes initiaux
            // var fromAccount = ...
            // var toAccount = ...
            // decimal transferAmount = 50m;

            // Act  
            // TODO: Appelez la méthode Transfer (qui n'existe pas encore)
            // _accountService.Transfer(fromAccount.Id, toAccount.Id, transferAmount);

            // Assert
            // TODO: Vérifiez que les soldes ont été mis à jour correctement
            // Le compte source doit avoir perdu l'argent
            // Le compte destination doit avoir gagné l'argent

            Assert.Fail("ÉTAPE 1A : Implémentez ce test pour qu'il échoue (RED)");
            
            // ÉTAPE 1B : Après avoir écrit le test, implémentez la méthode Transfer 
            // dans AccountService pour faire passer ce test (GREEN)
            
            // ÉTAPE 1C : Refactorisez si nécessaire (REFACTOR)
        }

        #endregion

        #region ÉTAPE 2 - Validation des paramètres

        [Test]
        public void Transfer_FromNonExistentAccount_ShouldThrowException()
        {
            // ÉTAPE 2A : Écrivez ce test (RED)
            // TODO: Testez le transfert depuis un compte qui n'existe pas
            // Doit lever une KeyNotFoundException
            
            Assert.Fail("ÉTAPE 2A : Implémentez ce test - transfert depuis compte inexistant");
            
            // ÉTAPE 2B : Modifiez la méthode Transfer pour gérer ce cas (GREEN)
            // ÉTAPE 2C : Refactorisez si nécessaire
        }

        [Test]
        public void Transfer_ToNonExistentAccount_ShouldThrowException()
        {
            // TODO: Similaire au test précédent mais pour le compte destination
            Assert.Fail("ÉTAPE 2 : Implémentez ce test - transfert vers compte inexistant");
        }

        [Test]
        public void Transfer_NegativeAmount_ShouldThrowException()
        {
            // TODO: Testez qu'un montant négatif lève une ArgumentException
            Assert.Fail("ÉTAPE 2 : Implémentez ce test - montant négatif");
        }

        [Test]
        public void Transfer_ZeroAmount_ShouldThrowException()
        {
            // TODO: Testez qu'un montant de 0 lève une ArgumentException
            Assert.Fail("ÉTAPE 2 : Implémentez ce test - montant zéro");
        }

        #endregion

        #region ÉTAPE 3 - Gestion des fonds insuffisants

        [Test]
        public void Transfer_InsufficientFunds_ShouldThrowException()
        {
            // ÉTAPE 3A : Écrivez ce test (RED)
            // TODO: Créez un compte avec un solde insuffisant
            // Tentez de transférer plus que le solde disponible
            // Vérifiez qu'une InvalidOperationException est levée
            
            Assert.Fail("ÉTAPE 3A : Implémentez ce test - fonds insuffisants");
            
            // ÉTAPE 3B : Modifiez Transfer pour gérer ce cas (GREEN)
            // ÉTAPE 3C : Refactorisez si nécessaire
        }

        [Test]
        public void Transfer_ExactBalance_ShouldTransferSuccessfully()
        {
            // TODO: Testez qu'on peut transférer exactement le solde complet d'un compte
            Assert.Fail("ÉTAPE 3 : Implémentez ce test - transfert du solde exact");
        }

        #endregion

        #region ÉTAPE 4 - Cas particuliers

        [Test]
        public void Transfer_SameAccount_ShouldThrowException()
        {
            // ÉTAPE 4A : Écrivez ce test (RED)
            // TODO: Testez qu'on ne peut pas transférer vers le même compte
            // Doit lever une InvalidOperationException avec un message approprié
            
            Assert.Fail("ÉTAPE 4A : Implémentez ce test - transfert vers le même compte");
            
            // ÉTAPE 4B : Modifiez Transfer pour empêcher les auto-transferts (GREEN)
        }

        [Test]
        public void Transfer_MultipleTransfers_ShouldMaintainCorrectBalances()
        {
            // ÉTAPE 4 : Test plus complexe avec plusieurs transferts successifs
            // TODO: Effectuez plusieurs transferts entre 3 comptes différents
            // Vérifiez que tous les soldes sont corrects à chaque étape
            
            Assert.Fail("ÉTAPE 4 : Implémentez ce test - transferts multiples");
        }

        #endregion

        #region BONUS - Fonctionnalités avancées (optionnel)

        [Test]
        public void Transfer_WithTransactionFee_ShouldDeductFee()
        {
            // BONUS : Ajoutez une fonctionnalité de frais de transaction
            // TODO: Implémentez une surcharge de Transfer qui accepte des frais
            // Vérifiez que les frais sont déduits du compte source
            
            Assert.Fail("BONUS : Fonctionnalité avancée - frais de transaction");
        }

        [Test]
        public void Transfer_ShouldRecordTransactionHistory()
        {
            // BONUS : Ajoutez un historique des transactions
            // TODO: Chaque transfert doit être enregistré dans l'historique
            // Créez une classe Transaction et modifiez Account pour garder l'historique
            
            Assert.Fail("BONUS : Fonctionnalité avancée - historique des transactions");
        }

        #endregion
    }
}

/*
 * INSTRUCTIONS POUR LES ÉTUDIANTS :
 * 
 * 1. Commencez par l'ÉTAPE 1A - écrivez le test Transfer_ValidAmountBetweenAccounts_ShouldTransferMoney()
 * 2. Lancez le test - il doit échouer (RED) car la méthode Transfer n'existe pas
 * 3. Implémentez la méthode Transfer dans AccountService avec le minimum de code (GREEN)
 * 4. Le test doit maintenant passer
 * 5. Refactorisez si nécessaire (REFACTOR)
 * 6. Passez à l'étape suivante
 * 
 * Répétez ce processus RED-GREEN-REFACTOR pour chaque test !
 * 
 * SIGNATURE SUGGÉRÉE POUR LA MÉTHODE TRANSFER :
 * public void Transfer(Guid fromAccountId, Guid toAccountId, decimal amount)
 * 
 * CONSEILS :
 * - Ne sautez pas d'étapes !
 * - Écrivez toujours le test AVANT le code
 * - Implémentez seulement ce qui est nécessaire pour faire passer le test
 * - Refactorisez régulièrement pour améliorer le design
 */
