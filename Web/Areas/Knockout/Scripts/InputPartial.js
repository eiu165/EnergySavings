﻿
$(function () {

    function Result(data) {

        this.year = ko.observable(data.year);
        this.month = ko.observable(data.month);
        this.day = ko.observable(data.day);
        this.week = ko.observable(data.week);
    }

    function InputViewModel() {
        var self = this;
        self.qty = ko.observable("aaaa");
        self.results = ko.observableArray([]);



        // Operations
        self.calc = function () {
            console.log('calc   ' + ko.toJSON(self));
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

