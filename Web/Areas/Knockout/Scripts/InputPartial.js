
$(function () {

    function Result(data) {
        this.year = ko.observable(data.year);
        this.hours = ko.observable(data.hours);
        this.month = ko.observable(data.month);
        this.day = ko.observable(data.day);
        this.week = ko.observable(data.week);
    }

    function InputViewModel() {
        var self = this;
        self.qty = ko.observable("30");
        self.kw = ko.observable("0.1200");
        self.rate = ko.observable("0.100");
        self.cost = ko.observable("2000");
        self.weeks = ko.observable("50");
        self.days = ko.observable("5");
        self.hours = ko.observable("12");
        self.results = ko.observableArray([]);

        // Operations
        self.calc = function () { 
            self.results.removeAll();
            $.ajax("/Knockout/Input/Calc", {
                data: ko.toJSON(self),
                type: "post", contentType: "application/json",
                success: function (allData) {
                    console.log('success');
                    var allresults = $.map(allData, function (item) { return new Result(item); });
                    self.results(allresults);
                },
                error: function () { alert('error'); },
                complete: function () {
                }
            });

        };
    }
    // Activates knockout.js
    ko.applyBindings(new InputViewModel(), $('#inputForm')[0]);
});

