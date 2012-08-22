
$(function () {
    function InputViewModel() {
        var self = this;
        this.qty = ko.observable("aaaa");


        // Operations
        self.calc = function () {
            console.log('calc');
            var input = new InputViewModel({ qty: self.qty._latestValue });
            $.ajax("/Knockout/Input/Calc", {
                data: ko.toJSON(  input ),
                type: "post", contentType: "application/json",
                success: function (allData) {
                    console.log('success');
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

