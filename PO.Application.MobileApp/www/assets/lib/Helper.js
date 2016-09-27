if (typeof jQuery === 'undefined') {

    console.dir("Lib Error: jQuery is not implemented.");
}



function inherit(proto) {
    function F() {
    }
    F.prototype = proto
    return new F
}

function generateGuid() {
    function s4() {
        return Math.floor((1 + Math.random()) * 0x10000)
            .toString(16)
            .substring(1);
    }
    return s4() + s4() + '-' + s4() + '-' + s4() + '-' +
           s4() + '-' + s4() + s4() + s4();
}


function getElementInArrayWithObjectId(array, id) {

    return $.grep(array, function (e) {
        return e.id == id;
    });

}



function removeElementInArrayWithObjectId(array, key) {
    var data = $.grep(array, function (e) {
        return e.id != key;
    });
    return data;
}