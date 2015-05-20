
Array.prototype.remove = function (item) {
    var index = this.indexOf(item);
    if (index >= 0) this.splice(index, 1);
};

Array.prototype.contains = function (item) {
    return this.indexOf(item) >= 0;
};

Array.prototype.shuffle = function() {

    this.sort(function() {
        return Math.random() - 0.5;
    });

};