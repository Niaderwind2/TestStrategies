# TP - Stratégies de Tests
## Système de Gestion de Comptes Bancaires

### Objectifs pédagogiques
- Comprendre et implémenter différents types de tests (unitaires, intégration)
- Pratiquer le développement piloté par les tests (TDD)
- Découvrir le développement piloté par le comportement (BDD) avec SpecFlow
- Maîtriser les frameworks de test .NET (NUnit, SpecFlow)

### Structure du projet
```
TestStrategies/
├── Account.cs                    # Classe de domaine
├── AccountService.cs             # Service métier
├── Program.cs                    # API Web
├── Tests/
│   ├── UnitTests.cs             # Tests unitaires à compléter
│   ├── IntegrationTests.cs      # Tests d'intégration à compléter
│   ├── TDD_Exercise.cs          # Exercice TDD
│   └── BDD_Features/            # Tests BDD avec SpecFlow
│       ├── AccountManagement.feature
│       └── AccountManagementSteps.cs
```

### Partie 1 : Tests Unitaires (30 min)
Complétez les tests unitaires manquants dans `UnitTests.cs` pour :
- Classe Account : constructeur, dépôts, retraits, calcul d'intérêts
- Classe AccountService : création, récupération, opérations

### Partie 2 : Tests d'Intégration (20 min)
Implémentez les tests d'intégration dans `IntegrationTests.cs` pour :
- Tests de l'API HTTP
- Tests de bout en bout avec TestServer

### Partie 3 : TDD Exercise (45 min)
Développez une nouvelle fonctionnalité "Transfert entre comptes" en TDD :
1. Écrivez les tests d'abord
2. Implémentez le code minimal
3. Refactorisez

### Partie 4 : BDD avec SpecFlow (30 min)
Complétez les scénarios BDD en langage naturel et leurs implémentations.

### Instructions détaillées
Voir les fichiers individuels pour les exercices spécifiques.
