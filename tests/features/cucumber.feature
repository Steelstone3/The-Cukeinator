Feature: Cucumber Soldier

  Scenario: Take damage to shields
    Given Cucumber has shields
    When Cucumber is attacked
    Then Cucumber will take damage to shields

  Scenario: Take damage to health when shields are down
    Given Cucumber has depleted shields
    When Cucumber is attacked
    Then Cucumber will take damage to health

  Scenario: Take no damage to health when shields are up
    Given Cucumber has shields
    When Cucumber is attacked
    Then Cucumber will take no damage to health