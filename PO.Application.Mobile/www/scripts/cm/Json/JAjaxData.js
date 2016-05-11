var JDataProcess = function () {
    var batchId = 0;
    var description = null;
    var startDate = '';
    var startDateString = null;
    var taskType = null;
    var tnName = '';
    var tnCode = 0;
    var tnId = 0;
};

JDataProcess.prototype.initData = function (data) {
    this.batchId = data.BatchId,
    this.description = data.Description,
    this.startDate = data.StartDate,
    this.startDateString = data.StartDateString,
    this.taskType = data.TaskType,
    this.tnCode = data.TnCode,
    this.tnName = data.TnName,
    this.tnId = data.TnId
};

var JDataChartProcess = function () {
    var batchCount = 0;
    var doneCount = 0;
    var errorCount = 0;
    var executeCount = 0;
    var otherCount = 0;
    var processingCount = 0;
    var TaskType = "";
};

JDataChartProcess.prototype.initData = function (data) {
    this. batchCount = data.BatchCount;
    this. doneCount = data.DoneCount;
    this. errorCount = data.ErrorCount;
    this. executeCount = data.ExecuteCount;
    this. otherCount = data.OtherCount;
    this. processingCount = data.ProcessingCount;
    this. taskType = data.TaskType;
};

var JDataChartData = function () {
    var viewCount = 0;
    var viewType = "";
};

JDataChartData.prototype.initData = function (data) {
    this.viewCount = data.ViewCount;
    this.viewType = data.ViewType;
};

var JDataChartProcessYear = function () {
    var data = {};
    var drillSetting = {};
};

JDataChartProcessYear.prototype.initData = function (data, drillSetting) {

    console.dir(data);
    this.data.viewTimeDesc = data.ViewTimeDesc;
    this.data.viewTime = data.ViewTime;
    this.data.execute = data.Execute;
    this.data.done = data.Done;

    this.drillSetting.level = drillSetting.level;
    this.drillSetting.quater = drillSetting.quater;
    this.drillSetting.year = drillSetting.year;
};