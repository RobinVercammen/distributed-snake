import { GameLoop } from "./GameLoop.js";
import { Input } from "./Input.js";
import { Map } from './Map.js';
import { Snake } from "./Snake.js";

export class App {
    constructor() {
        var snake = new Snake('robin', 5, 5);
        this.map = new Map([snake]);
        this.gameLoop = new GameLoop(
            () => {
                this.map.next();
                document.getElementById('map').innerHTML = this.map.render();
            }
        );
        this.input = new Input(
            snake.moveUp,
            snake.moveRight,
            snake.moveDown,
            snake.moveLeft
        );
    }
} 