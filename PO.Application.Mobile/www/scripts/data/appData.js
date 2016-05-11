var LocalDataManager = {
    loadData: function (key) {
        var returnData = JSON.parse(localStorage.getItem(key)) || [];
        return returnData;
    },
    saveData: function (key, data) {
        var oldItems = JSON.parse(localStorage.getItem(key)) || [];
        oldItems.push(data);
        localStorage.setItem(key, JSON.stringify(oldItems));
    }
};




