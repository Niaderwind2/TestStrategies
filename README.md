# 🎓 GUIDE DE TRAVAUX PRATIQUES - Stratégies de Tests

## 📋 Vue d'ensemble du TP

Ce TP vous permettra de maîtriser les différentes stratégies de tests dans un projet .NET :
- **Tests Unitaires** avec NUnit
- **Tests d'Intégration** avec TestServer
- **TDD (Test-Driven Development)**
- **BDD (Behavior-Driven Development)** avec SpecFlow

**Prérequis :** Connaissance de base de C# et .NET

## 🎯 Objectifs d'apprentissage

À la fin de ce TP, vous saurez :
1. ✅ Écrire des tests unitaires efficaces
2. ✅ Créer des tests d'intégration pour une API
3. ✅ Appliquer la méthodologie TDD (Red-Green-Refactor)
4. ✅ Utiliser SpecFlow pour le BDD
5. ✅ Organiser et exécuter différents types de tests

## 🚀 Mise en route

### 1. Vérification de l'environnement
```bash
# Restaurer les packages
dotnet restore

# Compiler le projet
dotnet build

# Vérifier que les tests se lancent (ils vont échouer, c'est normal !)
dotnet test
```

### 2. Structure du projet
```
TestStrategies/
├── Account.cs              # Modèle de domaine
├── AccountService.cs       # Logique métier
├── Program.cs             # API Web
└── Tests/
    ├── UnitTest1.cs       # Tests unitaires à compléter
    ├── IntegrationTests.cs # Tests d'intégration à compléter
    ├── TDD_Exercise.cs    # Exercice TDD
    └── BDD_Features/      # Tests BDD avec SpecFlow
        ├── AccountManagement.feature
        └── AccountManagementSteps.cs
```

## 📚 Partie 1 : Tests Unitaires

### 🎯 Objectif
Compléter les tests unitaires dans `UnitTest1.cs` pour les classes `Account` et `AccountService`.

### 📝 Instructions
1. Ouvrez le fichier `TestStrategies.Tests/UnitTest1.cs`
2. Complétez les tests marqués avec `Assert.Fail("À implémenter...")`
3. Utilisez les commentaires TODO comme guide
4. Exécutez vos tests après chaque implémentation

### 💡 Conseils
- Utilisez `Assert.That()` pour les assertions
- `Assert.Throws<ExceptionType>()` pour tester les exceptions
- Suivez le pattern **Arrange-Act-Assert**

### ✅ Tests à implémenter
- [ ] `Account_Constructor_ShouldCreateAccountWithDefaultValues`
- [ ] `Deposit_ValidAmount_ShouldIncreaseBalance`
- [ ] `Deposit_NegativeAmount_ShouldThrowArgumentException`
- [ ] `Deposit_ZeroAmount_ShouldThrowArgumentException`
- [ ] `Withdraw_ValidAmount_ShouldDecreaseBalance`
- [ ] `Withdraw_AmountGreaterThanBalance_ShouldThrowInvalidOperationException`
- [ ] `CalculateInterest_ShouldReturnCorrectInterest`
- [ ] `CreateAccount_ValidParameters_ShouldCreateAccount`
- [ ] `CreateAccount_EmptyOwner_ShouldThrowArgumentException`
- [ ] `GetAccount_ExistingId_ShouldReturnAccount`
- [ ] `GetAccount_NonExistingId_ShouldReturnNull`
- [ ] `Deposit_ValidAmount_ShouldIncreaseBalance` (via service)
- [ ] `Withdraw_ValidAmount_ShouldDecreaseBalance` (via service)

### 🔍 Commandes utiles
```bash
# Exécuter uniquement les tests unitaires
dotnet test --filter TestCategory=Unit

# Exécuter avec détails
dotnet test --logger:detailed
```

---

## 🌐 Partie 2 : Tests d'Intégration

### 🎯 Objectif
Implémenter les tests d'intégration dans `IntegrationTests.cs` pour tester l'API HTTP complète.

### 📝 Instructions
1. Ouvrez le fichier `TestStrategies.Tests/IntegrationTests.cs`
2. Complétez les tests d'API HTTP
3. Utilisez `HttpClient` pour les appels REST
4. Testez les codes de statut et le contenu JSON

### 💡 Conseils
- Utilisez `PostAsJsonAsync()` et `ReadFromJsonAsync()` 
- Vérifiez les codes de statut HTTP (200, 201, 400, 404)
- Les tests d'intégration utilisent un serveur de test in-memory

### ✅ Tests à implémenter
- [ ] `CreateAccount_ValidRequest_ShouldReturnCreated`
- [ ] `CreateAccount_EmptyOwner_ShouldReturnBadRequest`
- [ ] `GetAccount_ExistingId_ShouldReturnAccount`
- [ ] `GetAccount_NonExistingId_ShouldReturnNotFound`
- [ ] `Deposit_ValidRequest_ShouldUpdateBalance`
- [ ] `Withdraw_ValidRequest_ShouldUpdateBalance`
- [ ] `Withdraw_InsufficientFunds_ShouldReturnBadRequest`
- [ ] `GetAllAccounts_ShouldReturnAccountsList`
- [ ] `CalculateInterest_ShouldReturnCorrectAmount`
- [ ] `CompleteWorkflow_CreateDepositWithdraw_ShouldWorkCorrectly`

---

## 🔴🟢🔵 Partie 3 : Exercice TDD

### 🎯 Objectif
Développer une nouvelle fonctionnalité "Transfert entre comptes" en suivant la méthodologie TDD.

### 📝 Processus TDD
1. **🔴 RED** : Écrivez un test qui échoue
2. **🟢 GREEN** : Écrivez le code minimal pour faire passer le test
3. **🔵 REFACTOR** : Améliorez le code sans casser les tests
4. **Répétez** pour chaque nouveau comportement

### 📋 Étapes détaillées

#### ÉTAPE 1 : Test basique 
1. Ouvrez `TDD_Exercise.cs`
2. Implémentez `Transfer_ValidAmountBetweenAccounts_ShouldTransferMoney()`
3. ▶️ Lancez le test → Il doit échouer (RED)
4. Créez la méthode `Transfer()` dans `AccountService` (code minimal)
5. ▶️ Le test doit passer (GREEN)
6. Refactorisez si nécessaire (REFACTOR)

#### ÉTAPE 2 : Validation des paramètres 
- [ ] `Transfer_FromNonExistentAccount_ShouldThrowException`
- [ ] `Transfer_ToNonExistentAccount_ShouldThrowException`
- [ ] `Transfer_NegativeAmount_ShouldThrowException`
- [ ] `Transfer_ZeroAmount_ShouldThrowException`

#### ÉTAPE 3 : Gestion des fonds insuffisants 
- [ ] `Transfer_InsufficientFunds_ShouldThrowException`
- [ ] `Transfer_ExactBalance_ShouldTransferSuccessfully`

#### ÉTAPE 4 : Cas particuliers 
- [ ] `Transfer_SameAccount_ShouldThrowException`
- [ ] `Transfer_MultipleTransfers_ShouldMaintainCorrectBalances`

### 💡 Signature de méthode suggérée
```csharp
public void Transfer(Guid fromAccountId, Guid toAccountId, decimal amount)
{
    // TODO: Implémentez cette méthode étape par étape
}
```

---

## 🥒 Partie 4 : BDD avec SpecFlow 

### 🎯 Objectif
Compléter les scénarios BDD en langage naturel et leurs implémentations.

### 📝 Instructions

#### Phase 1 : Compléter les Steps 
1. Ouvrez `BDD_Features/AccountManagementSteps.cs`
2. Complétez toutes les méthodes marquées `Assert.Fail("TODO...")`
3. Implémentez les steps manquantes

#### Phase 2 : Créer de nouveaux scénarios 
1. Ouvrez `BDD_Features/AccountManagement.feature`
2. Complétez les scénarios marqués `@todo`
3. Créez les steps correspondantes

### 💡 Syntaxe Gherkin
```gherkin
Scenario: Nom du scénario
    Given [condition initiale]
    When [action déclenchée]
    Then [résultat attendu]
    And [condition supplémentaire]
```

### ✅ Scénarios à compléter
- [ ] `Calculate interest on account`
- [ ] `Transfer between accounts`
- [ ] `Account operations through web interface`
- [ ] `Account creation validation` (Scenario Outline)

### 🔍 Commandes SpecFlow
```bash
# Exécuter uniquement les tests BDD
dotnet test --filter TestCategory=unit

# Exécuter les tests d'intégration BDD  
dotnet test --filter TestCategory=integration

# Générer un rapport SpecFlow (optionnel)
dotnet test --logger:"trx" --results-directory ./TestResults
```

---

## 🧪 Tests et Validation

### Commandes de test par type
```bash
# Tous les tests
dotnet test

# Tests unitaires seulement
dotnet test --filter FullyQualifiedName~UnitTests

# Tests d'intégration seulement  
dotnet test --filter FullyQualifiedName~IntegrationTests

# Tests TDD seulement
dotnet test --filter FullyQualifiedName~TDD_Exercise

# Tests BDD seulement
dotnet test --filter FullyQualifiedName~AccountManagement
```

### Critères de réussite
- ✅ Tous les tests unitaires passent
- ✅ Tous les tests d'intégration passent
- ✅ La fonctionnalité Transfer est implémentée en TDD
- ✅ Les scénarios BDD sont complets et passent
- ✅ Le code compile sans erreurs

---

## 📚 Ressources et Aide

### Documentation
- [NUnit Documentation](https://docs.nunit.org/)
- [SpecFlow Documentation](https://docs.specflow.org/)
- [ASP.NET Core Testing](https://docs.microsoft.com/en-us/aspnet/core/test/)

### Patterns de test utiles
```csharp
// Test d'exception
Assert.Throws<ArgumentException>(() => method());

// Test avec message personnalisé
Assert.That(actual, Is.EqualTo(expected), "Message d'erreur personnalisé");

// Test de propriétés multiples
Assert.Multiple(() => 
{
    Assert.That(account.Balance, Is.EqualTo(100));
    Assert.That(account.Owner, Is.EqualTo("John"));
});
```

---

## ❓ FAQ

**Q: Mes tests SpecFlow ne sont pas reconnus**
R: Assurez-vous que les packages SpecFlow sont installés et que le fichier .feature est bien configuré.

**Q: Les tests d'intégration échouent**
R: Vérifiez que les DTOs (CreateAccountRequest, etc.) correspondent à ceux utilisés dans l'API.

**Q: Comment déboguer un test qui échoue ?**
R: Utilisez le débogueur de Visual Studio/Rider ou ajoutez des `Console.WriteLine()` pour tracer l'exécution.

**Q: Puis-je modifier les classes Account/AccountService ?**
R: Oui, surtout pour l'exercice TDD où vous devez ajouter la méthode Transfer.

---

## 🏆 Bonus (Optionnel)

Si vous terminez en avance :

### 🔒 Tests de Sécurité
1. **Validation des entrées** : 
   - Tests d'injection SQL (même si on n'utilise pas de base de données)
   - Validation des limites numériques (decimal overflow, montants négatifs)
   - Tests de robustesse avec des chaînes vides, nulls, caractères spéciaux

2. **Tests d'autorisation** :
   - Vérification qu'on ne peut pas accéder aux comptes d'autres utilisateurs
   - Tests avec des IDs invalides ou malformés
   - Validation des montants (pas de montants astronomiques)

3. **Tests de concurrence** :
   - Plusieurs opérations simultanées sur le même compte
   - Tests de race conditions avec `ConcurrentDictionary`

**Exemple de test de sécurité :**
```csharp
[Test]
public void CreateAccount_MaliciousInput_ShouldBeHandledSafely()
{
    // Test avec des caractères spéciaux, scripts, etc.
    var maliciousInput = "<script>alert('xss')</script>";
    
    // Vérifier que l'input est échappé ou rejeté
    var account = _accountService.CreateAccount(maliciousInput, 100m);
    Assert.That(account.Owner, Does.Not.Contain("<script>"));
}

[Test]
public void Deposit_ExtremelyLargeAmount_ShouldThrowException()
{
    var account = _accountService.CreateAccount("Test", 0);
    
    // Test avec des montants irréalistes
    Assert.Throws<ArgumentException>(() => 
        account.Deposit(decimal.MaxValue));
}
```

### 🛡️ Tests de Non-Régression
1. **Snapshot testing** :
   - Sauvegarder l'état d'un compte après plusieurs opérations
   - Comparer avec des résultats attendus sauvegardés

2. **Tests de compatibilité** :
   - Vérifier que les anciennes données restent compatibles
   - Tests avec différentes versions de sérialisation JSON

3. **Tests de performances** :
   - Mesurer le temps d'exécution des opérations critiques
   - Détecter les régressions de performance

**Exemple de test de non-régression :**
```csharp
[Test]
public void AccountOperations_ComplexScenario_ShouldMatchExpectedResult()
{
    // Scénario complexe reproductible
    var account = _accountService.CreateAccount("Regression Test", 1000m);
    
    // Série d'opérations prédéfinies
    account.Deposit(250m);
    account.Withdraw(100m);
    account.Deposit(50m);
    
    // Résultat attendu (sauvegardé lors du premier passage)
    var expectedBalance = 1200m;
    var expectedInterest = 12m; // 1% de 1200
    
    Assert.Multiple(() =>
    {
        Assert.That(account.Balance, Is.EqualTo(expectedBalance));
        Assert.That(account.CalculateInterest(), Is.EqualTo(expectedInterest));
    });
}
```

### 📊 Autres Améliorations
1. **Couverture de code** : Générez un rapport de couverture avec dotnet-coverage ou Coverlet
2. **Tests de charge** : Utilisez NBomber ou similaire pour tester la performance
3. **Mocking avancé** : Utilisez Moq ou NSubstitute pour simuler des services externes
4. **Tests paramétrés** : Créez des tests avec `[TestCase]` pour tester plusieurs valeurs
5. **Tests de mutation** : Utilisez Stryker.NET pour détecter les lacunes dans vos tests

### 🎯 Suggestions d'implémentation par priorité

**Priorité 1 - Tests de Sécurité Essentiels :**
- Validation des entrées malveillantes
- Tests de limites numériques
- Vérification des autorisations d'accès

**Priorité 2 - Tests de Non-Régression :**
- Scénarios de workflow complets
- Tests de compatibilité des données
- Mesures de performance basiques

**Priorité 3 - Tests Avancés :**
- Tests de concurrence
- Mutation testing
- Tests de charge

Bon travail ! 🚀
