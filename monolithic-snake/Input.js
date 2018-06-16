export class Input {
    constructor(onUp, onRight, onDown, onLeft) {
        this.onUp = onUp;
        this.onRight = onRight;
        this.onDown = onDown;
        this.onLeft = onLeft;
        self.onkeyup = (ev) => this.handleKeyPress(ev.code);
    }
    /**
     *
     * @param {string} keyCode
     */
    handleKeyPress(keyCode) {
        if (keyCode === 'ArrowLeft') {
            this.onLeft();
        }
        if (keyCode === 'ArrowUp') {
            this.onUp();
        }
        if (keyCode === 'ArrowRight') {
            this.onRight();
        }
        if (keyCode === 'ArrowDown') {
            this.onDown();
        }
    }
}