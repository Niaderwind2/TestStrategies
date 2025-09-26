# API de Gestion de Comptes Bancaires

## Description
Cette API ASP.NET Core permet de gérer des comptes bancaires avec des fonctionnalités de dépôt, de retrait et de calcul d'intérêts.

## Endpoints disponibles

### 1. Créer un nouveau compte
- **POST** `/accounts`
- **Body**: 
```json
{
  "owner": "Nom du propriétaire",
  "initialDeposit": 100.0
}
```
- **Réponse**: Compte créé avec ID unique

### 2. Récupérer un compte par ID
- **GET** `/accounts/{id}`
- **Réponse**: Détails du compte ou 404 si non trouvé

### 3. Récupérer tous les comptes
- **GET** `/accounts`
- **Réponse**: Liste de tous les comptes

### 4. Déposer de l'argent
- **POST** `/accounts/{id}/deposit`
- **Body**:
```json
{
  "amount": 50.0
}
```
- **Réponse**: Compte mis à jour

### 5. Retirer de l'argent
- **POST** `/accounts/{id}/withdraw`
- **Body**:
```json
{
  "amount": 30.0
}
```
- **Réponse**: Compte mis à jour ou erreur si solde insuffisant

### 6. Calculer les intérêts
- **GET** `/accounts/{id}/interest`
- **Réponse**: Montant des intérêts calculés

## Structure des données

### Account
```json
{
  "id": "guid",
  "owner": "string",
  "balance": "decimal",
  "interestRate": "decimal (défaut: 0.01)"
}
```

## Gestion des erreurs
- **400 Bad Request**: Paramètres invalides (montant négatif, propriétaire vide)
- **404 Not Found**: Compte non trouvé
- **500 Internal Server Error**: Erreur serveur

## Tests
Le projet inclut une suite complète de tests unitaires couvrant :
- Tests de la classe Account (constructeur, dépôt, retrait, calcul d'intérêts)
- Tests de la classe AccountService (création, récupération, opérations)

Pour exécuter les tests : `dotnet test`

## Démarrage
1. Naviguer vers le dossier du projet
2. Exécuter `dotnet run`
3. L'API sera disponible sur `https://localhost:5001` ou `http://localhost:5000`
4. Documentation Swagger disponible à `/swagger` en mode développement
