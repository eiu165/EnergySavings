
$(function () {

    function Result(data) {
        this.year = ko.observable(data.year);
        this.annual = ko.observable(data.annual);
        this.weekly = ko.observable(data.weekly);
        this.daily = ko.observable(data.daily);
        this.percent = ko.observable(data.percent)  ;
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

