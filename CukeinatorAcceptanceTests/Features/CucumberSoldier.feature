Feature: Cucumber Soldier

  Scenario: Take damage to shields
    Given Cucumber soldier has shields
    When Cucumber soldier is attacked
    Then Cucumber soldier will take damage to shields

  Scenario: Take damage to health when shields are down
    Given Cucumber soldier has depleted shields
    When Cucumber soldier is attacked
    Then Cucumber soldier will take damage to health

  Scenario: Take no damage to health when shields are up
    Given Cucumber soldier has shields
    When Cucumber soldier is attacked
    Then Cucumber soldier will take no damage to health