Feature: Fruit Soldier

  Scenario: Take damage to health
    Given Fruit soldier has health
    When Fruit soldier's health is attacked
    Then Fruit soldier will take damage to health