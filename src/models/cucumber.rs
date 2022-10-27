pub struct Cucumber {
    shields: u8,
    health: u8,
    attack: u8,
    special_attack: u8,
    defence: u8,
}

impl Default for Cucumber {
    fn default() -> Self {
        Self {
            shields: 100,
            health: 100,
            attack: 25,
            special_attack: 50,
            defence: 10,
        }
    }
}

impl Cucumber {
    pub fn take_damage_to_shields(&mut self, damage: u8) {
        if damage >= self.shields {
            self.shields = 0;
        } else {
            self.shields -= damage;
        }
    }

    pub fn take_damage_to_health(&mut self, damage: u8) {
        if self.shields > 0 {
            return;
        } else if damage >= self.health {
            self.health = 0;
        } else {
            self.health -= damage;
        }
    }
}

#[cfg(test)]
mod cucumber_should {
    use super::*;

    #[test]
    fn have_a_default_state() {
        let cucumber = Cucumber::default();

        assert_eq!(100, cucumber.shields);
        assert_eq!(100, cucumber.health);
        assert_eq!(25, cucumber.attack);
        assert_eq!(50, cucumber.special_attack);
        assert_eq!(10, cucumber.defence);
    }

    #[test]
    fn be_able_to_take_damage_to_shields() {
        let mut cucumber = Cucumber::default();

        cucumber.take_damage_to_shields(99);

        assert_eq!(1, cucumber.shields)
    }

    #[test]
    fn be_able_to_take_extreme_damage_to_shields() {
        let mut cucumber = Cucumber::default();

        cucumber.take_damage_to_shields(200);

        assert_eq!(0, cucumber.shields)
    }

    #[test]
    fn be_able_to_resist_damage_to_health_when_shields_are_active() {
        let mut cucumber = Cucumber::default();

        cucumber.take_damage_to_health(99);

        assert_eq!(100, cucumber.health)
    }

    #[test]
    fn be_able_to_take_damage_to_health_when_shields_are_depleted() {
        let mut cucumber = Cucumber::default();
        cucumber.shields = 0;

        cucumber.take_damage_to_health(99);

        assert_eq!(1, cucumber.health)
    }

    #[test]
    fn be_able_to_take_extreme_damage_to_health_when_shields_are_depleted() {
        let mut cucumber = Cucumber::default();
        cucumber.shields = 0;

        cucumber.take_damage_to_health(200);

        assert_eq!(0, cucumber.health)
    }
}