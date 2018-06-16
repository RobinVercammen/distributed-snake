import { SnakeTile } from "./Tile.js";
import { Position } from './Position.js';

export class Snake {
    constructor(name, x, y) {
        this.name = name;
        this.tiles = [new SnakeTile(new Position(x, y))];
        this.moveRight();
        this.moveUp = this.moveUp.bind(this);
        this.moveDown = this.moveDown.bind(this);
        this.moveLeft = this.moveLeft.bind(this);
        this.moveRight = this.moveRight.bind(this);
        this.move = this.move.bind(this);
    }

    moveUp() {
        this.nextAction = () => {
            const currentHead = this.tiles[0];
            const next = new SnakeTile(new Position(currentHead.position.x, currentHead.position.y - 1));
            this.tiles = [next, ...this.tiles.slice(0, -1)];
        }
    }

    moveDown() {
        this.nextAction = () => {
            const currentHead = this.tiles[0];
            const next = new SnakeTile(new Position(currentHead.position.x, currentHead.position.y + 1));
            this.tiles = [next, ...this.tiles.slice(0, -1)];
        }
    }

    moveLeft() {
        this.nextAction = () => {
            const currentHead = this.tiles[0];
            const next = new SnakeTile(new Position(currentHead.position.x - 1, currentHead.position.y));
            this.tiles = [next, ...this.tiles.slice(0, -1)];
        }
    }

    moveRight() {
        this.nextAction = () => {
            const currentHead = this.tiles[0];
            const next = new SnakeTile(new Position(currentHead.position.x + 1, currentHead.position.y));
            this.tiles = [next, ...this.tiles.slice(0, -1)];
        }
    }

    move() {
        this.nextAction && this.nextAction();
    }

}