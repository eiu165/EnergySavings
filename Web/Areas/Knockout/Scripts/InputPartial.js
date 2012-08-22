
$(function () {
    function InputViewModel() {
        var self = this;
        self.qty = ko.observable("aaaa");
         
        // Operations
        self.calc = function () {
            console.log('calc   ' + ko.toJSON(self)); 
            $.ajax("/Knockout/Input/Calc", {
                data: ko.toJSON(self),
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

