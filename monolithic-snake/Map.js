import { EmptyTile } from './Tile.js';
import { Position } from './Position.js';
import { Snake } from './Snake.js';


export class Map {
    /**
     * 
     * @param {Snake[]} snakes 
     */
    constructor(snakes) {
        const range = [...Array(10).keys()];
        this.tiles = range.map(row => range.map(column => new EmptyTile(new Position(column, row))));
        this.snakes = snakes;
    }

    next() {
        this.snakes.forEach(m => m.move());
    }

    render() {
        const allSnakePositions = this.snakes.reduce((acc, curr) => [...acc, ...curr.tiles], []);
        const tiles = this.tiles.map(row => row.map(col => allSnakePositions.find(s => s.onSamePlace(col)) || col))
        return tiles.map(row => `
        <div class="row">
        ${row.map(column => column.htmlRepresentation()).join('')}
        </div>
        `).join('');
    }
}