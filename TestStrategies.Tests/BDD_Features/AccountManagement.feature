Feature: Account Management
    En tant qu'utilisateur de la banque
    Je veux gérer mes comptes bancaires  
    Afin de pouvoir effectuer des opérations financières

Background: 
    Given the banking system is available

@unit
Scenario: Creating a new account
    When I create a new account for "John Doe" with initial deposit of 100 euros
    Then the account should be created successfully
    And the account balance should be 100 euros
    And the account owner should be "John Doe"

@unit  
Scenario: Making a deposit
    Given I have an account with balance 50 euros
    When I deposit 30 euros
    Then the account balance should be 80 euros

@unit
Scenario: Making a withdrawal with sufficient funds
    Given I have an account with balance 100 euros
    When I withdraw 40 euros
    Then the account balance should be 60 euros

@unit
Scenario: Attempting withdrawal with insufficient funds
    Given I have an account with balance 30 euros
    When I attempt to withdraw 50 euros
    Then the withdrawal should be rejected
    And I should receive an "insufficient funds" error
    And the account balance should remain 30 euros

@unit
Scenario Outline: Deposit validation
    Given I have an account with balance 50 euros
    When I attempt to deposit <amount> euros
    Then the operation should be <result>
    And the account balance should be <final_balance> euros

    Examples:
    | amount | result   | final_balance |
    | 25     | accepted | 75            |
    | 0      | rejected | 50            |
    | -10    | rejected | 50            |

@integration
Scenario: Creating account through API
    # TODO: Complétez ce scénario
    # Given the web API is running
    # When I send a POST request to create account for "Jane Smith" with 200 euros
    # Then I should receive a "201 Created" response
    # And the response should contain the account details

@integration  
Scenario: Complete banking workflow through API
    # TODO: Complétez ce scénario de bout en bout
    # Given the web API is running
    # When I create an account through API
    # And I deposit money through API  
    # And I withdraw money through API
    # Then all operations should be successful
    # And the final balance should be correct

# EXERCICES À COMPLÉTER PAR LES ÉTUDIANTS :

@unit @todo
Scenario: Calculate interest on account
    # TODO: Complétez ce scénario
    # Given I have an account with balance ??? euros and interest rate ??? %
    # When I calculate the interest
    # Then the calculated interest should be ??? euros

@unit @todo  
Scenario: Transfer between accounts
    # TODO: Créez un scénario pour tester les transferts entre comptes
    # (Après avoir implémenté la fonctionnalité en TDD)
    
@integration @todo
Scenario: Account operations through web interface
    # TODO: Créez un scénario d'intégration pour tester l'API web complète
    
@validation @todo
Scenario Outline: Account creation validation  
    # TODO: Créez un scénario outline pour tester différents cas de validation
    # lors de la création de comptes (propriétaires invalides, dépôts négatifs, etc.)
