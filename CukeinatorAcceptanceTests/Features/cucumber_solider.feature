Feature: Cucumber Soldier

  Scenario: Take damage to shields
    Given Cucumber soldier has shields
    When Cucumber soldier's shields is attacked
    Then Cucumber soldier will take damage to shields

  Scenario: Take damage to health when shields are down
    Given Cucumber soldier has depleted shields
    When Cucumber soldier's health is attacked
    Then Cucumber soldier will take damage to health

  Scenario: Take no damage to health when shields are up
    Given Cucumber soldier has shields
    When Cucumber soldier's health is attacked with shields
    Then Cucumber soldier will take no damage to health

# Given Steps
# {Cucumber/ Fruit soldier} {has/ has depleted} {shields/ health}

# When Steps
# {Cucumber/ Fruit soldier}'s {health/ shields} is attacked

# Then Steps
# {Cucumber/ Fruit soldier} will take {damage/ no damage} to {shields/ health}