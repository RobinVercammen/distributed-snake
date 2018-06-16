export class Tile {
    /**
     *
     * @param {Position} position
     */
    constructor(position) {
        this.position = position;
    }
    htmlRepresentation() {
        return '<div class="cell"></div>';
    }
    /**
     * 
     * @param {Tile} other 
     */
    onSamePlace(other) {
        return this.position.x === other.position.x && this.position.y === other.position.y;
    }
}

export class SnakeTile extends Tile {
    /**
     * 
     * @param {Position} position 
     */
    constructor(position) {
        super(position);
    }
    htmlRepresentation() {
        return '<div class="cell snake"></div>';
    }
}

export class EmptyTile extends Tile {
    /**
     * 
     * @param {Position} position 
     */
    constructor(position) {
        super(position);
    }
    htmlRepresentation() {
        return '<div class="cell empty"></div>';
    }
}
