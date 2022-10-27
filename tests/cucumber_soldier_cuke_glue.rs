// use cucumber::{given, then, when, World as _};
//
// #[derive(cucumber::World, Debug, Default)]
// struct World {
//     user: Option<String>,
//     capacity: usize,
// }
//
// #[given(expr = "{word} is hungry")] // Cucumber Expression
// async fn someone_is_hungry(w: &mut World, user: String) {
//     w.user = Some(user);
// }
//
// #[when(regex = r"^(?:he|she|they) eats? (\d+) cucumbers?$")]
// async fn eat_cucumbers(w: &mut World, count: usize) {
//     w.capacity += count;
//
//     assert!(w.capacity < 4, "{} exploded!", w.user.as_ref().unwrap());
// }
//
// #[then("she is full")]
// async fn is_full(w: &mut World) {
//     assert_eq!(w.capacity, 3, "{} isn't full!", w.user.as_ref().unwrap());
// }
//
// #[tokio::main]
// async fn main() {
//     World::run("tests/features/readme.feature").await;
// }
//
//
//
//
// 
//
//
//
//
//
//
//
//
//
//
//
//
//
//
// use cucumber::{given, then, when, World as _};
// use crate::models::cucumber_soldier::CucumberSoldier;
//
// #[derive(cucumber::World, Debug, Default)]
// struct World {
//     cucumber_soldier: CucumberSoldier,
// }
//
// #[given(expr = "Cucumber soldier {word} shields")] // Cucumber Expression
// async fn shield_status(world: &mut World, shield_state: String) {
//     match shield_state.as_str() {
//         "functional" => world.cucumber_soldier.shields = 100,
//         "depleted" => world.cucumber_soldier.shields = 0,
//         s => panic!("expected 'functional' or 'depleted', found: {s}"),
//     }
// }
//
// #[when(expr = "Cucumber soldier is attacked")]
// fn attacked(world: &mut World) {
//     assert!(world.cucumber_soldier.health > 0, "HP:{} Dead!", world.cucumber_soldier.health);
// }
//
// #[then("Cucumber soldier will take damage to {word}")]
// async fn takes_damage(world: &mut World, health_system: String) {
//     match shield_state.as_str() {
//         "health" => {
//             world.cucumber_soldier.take_damage_to_health(15);
//             assert_eq!(95, world.cucumber_soldier.health);
//         }
//         "shield" => {
//             world.cucumber_soldier.take_damage_to_shields(15);
//             assert_eq!(95, world.cucumber_soldier.shields);
//         }
//         s => panic!("expected 'health' or 'shields', found: {s}"),
//     }
// }
//
// #[tokio::main]
// async fn main() {
//     World::run("src/tests/features/cucumber_soldier.feature").await;
// }