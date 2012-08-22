


$(function () { 
    function Category(data) {
        this.name = ko.observable(data.name);
    }
     
    function CategoryListViewModel() {
        // Data
        var self = this;
        self.categories = ko.observableArray([]);
        self.newCategoryText = ko.observable();
        self.existingcategories = ko.computed(function () {
            return ko.utils.arrayFilter(self.categories(), function (category) { return !category._destroy; });
        });


        // Operations
        self.addCategory = function () {
            self.categories.push(new Category({ name: this.newCategoryText() }));
            self.newCategoryText("");
        };
        self.removeCategory = function (category) { self.categories.destroy(category); };
        self.save = function () {
            $('#CategoryPartial').block({ message: '<h3><img src="/Images/busy.gif" /> Just a moment...</h3>' });
            $.ajax("/Knockout/Main/SaveCategories", {
                data: ko.toJSON({ categories: self.existingcategories }),
                type: "post", contentType: "application/json",
                success: function (result) {
                    $('#CategoryPartial').unblock();
                },
                error: function () { alert('error'); }
            });
        };
        self.cancel = function () {
            self.load();
        };
        self.load = function () {
            $('#CategoryPartial').block({ message: '<h3><img src="/Images/busy.gif" /> Just a moment...</h3>' });
            // Load initial state from server, convert it to Category instances, then populate self.categories 
            $.getJSON("/Knockout/Main/GetCategories", function (allData) { 
                    $('#CategoryPartial').unblock(); 
                    var mappedcategories = $.map(allData,function (item) {return new Category(item);}
                );
                self.categories(mappedcategories);
            });
        };
        self.load();
    } 
     
    ko.applyBindings(new CategoryListViewModel(), $('#CategoryPartial')[0]);

});

