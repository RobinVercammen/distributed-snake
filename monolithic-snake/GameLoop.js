export class GameLoop {
    constructor(onTick) {
        this.onTick = onTick;
        this.interval = setInterval(this.onTick, 1000);
        this.dispose.bind(this);
    }
    dispose() {
        clearInterval(this.interval);
    }
}