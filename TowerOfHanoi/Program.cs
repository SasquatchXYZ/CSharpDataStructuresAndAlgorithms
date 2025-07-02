using TowerOfHanoi;

var game = new Game(10);
var viz = new Visualization(game);
game.MoveCompleted += (s, e) => viz.Show((Game) s!);
await game.MoveAsync(
    game.DiscsCount,
    game.From,
    game.To,
    game.Auxiliary);
